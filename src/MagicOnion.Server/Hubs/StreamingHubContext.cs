using MessagePack;
using System.Collections.Concurrent;
using MagicOnion.Internal;
using Microsoft.Extensions.ObjectPool;
using MagicOnion.Server.Hubs.Internal;

namespace MagicOnion.Server.Hubs;

internal class StreamingHubContextPool
{
    const int MaxRetainedCount = 16;
    readonly ObjectPool<StreamingHubContext> pool = new DefaultObjectPool<StreamingHubContext>(new Policy(), MaxRetainedCount);

    public static StreamingHubContextPool Shared { get; } = new();

    public StreamingHubContext Get() => pool.Get();
    public void Return(StreamingHubContext ctx) => pool.Return(ctx);

    class Policy : IPooledObjectPolicy<StreamingHubContext>
    {
        public StreamingHubContext Create()
        {
            return new StreamingHubContext();
        }

        public bool Return(StreamingHubContext obj)
        {
            obj.Uninitialize();
            return true;
        }
    }
}

public class StreamingHubContext
{
    IStreamingServiceContext<StreamingHubPayload, StreamingHubPayload> streamingServiceContext = default!;
    ConcurrentDictionary<string, object>? items;
    StreamingHubHandler handler = default!;

    /// <summary>Object storage per invoke.</summary>
    public ConcurrentDictionary<string, object> Items
    {
        get
        {
            lock (this) // lock per self! is this dangerous?
            {
                if (items == null) items = new ConcurrentDictionary<string, object>();
            }
            return items;
        }
    }

    public string Path => handler.ToString();
    public ILookup<Type, Attribute> AttributeLookup => handler.AttributeLookup;

    public object HubInstance { get; private set; } = default!;

    public ReadOnlyMemory<byte> Request { get; private set; }
    public DateTime Timestamp { get; private set; }

    public Guid ConnectionId => streamingServiceContext.ContextId;

    public IServiceContext ServiceContext => streamingServiceContext;

    internal int MessageId { get; private set; }
    internal int MethodId => handler.MethodId;

    internal int ResponseSize { get; private set; } = -1;
    internal Type? ResponseType { get; private set; }

    internal void Initialize(StreamingHubHandler handler, IStreamingServiceContext<StreamingHubPayload, StreamingHubPayload> streamingServiceContext, object hubInstance, ReadOnlyMemory<byte> request, DateTime timestamp, int messageId)
    {
        this.handler = handler;
        this.streamingServiceContext = streamingServiceContext;
        HubInstance = hubInstance;
        Request = request;
        Timestamp = timestamp;
        MessageId = messageId;
    }

    internal void Uninitialize()
    {
        handler = default!;
        streamingServiceContext = default!;
        HubInstance = default!;
        Request = default!;
        Timestamp = default!;
        MessageId = default!;
        ResponseSize = -1;
        items?.Clear();
    }

    // helper for reflection
    internal ValueTask WriteResponseMessageNil(ValueTask value)
    {
        if (MessageId == -1) // No need to write a response. We do not write response.
        {
            return default;
        }

        ResponseType = typeof(Nil);
        if (value.IsCompletedSuccessfully)
        {
            WriteMessageCore(StreamingHubPayloadBuilder.Build(MethodId, MessageId));
            return default;
        }
        return Await(this, value);

        static async ValueTask Await(StreamingHubContext ctx, ValueTask value)
        {
            await value.ConfigureAwait(false);
            ctx.WriteMessageCore(StreamingHubPayloadBuilder.Build(ctx.MethodId, ctx.MessageId));
        }
    }

    internal ValueTask WriteResponseMessage<T>(ValueTask<T> value)
    {
        if (MessageId == -1) // No need to write a response. We do not write response.
        {
            return default;
        }

        ResponseType = typeof(T);
        if (value.IsCompletedSuccessfully)
        {
            WriteMessageCore(StreamingHubPayloadBuilder.Build(MethodId, MessageId, value.Result, ServiceContext.MessageSerializer));
            return default;
        }
        return Await(this, value);

        static async ValueTask Await(StreamingHubContext ctx, ValueTask<T> value)
        {
            var vv = await value.ConfigureAwait(false);
            ctx.WriteMessageCore(StreamingHubPayloadBuilder.Build(ctx.MethodId, ctx.MessageId, vv, ctx.ServiceContext.MessageSerializer));
        }
    }

    internal ValueTask WriteErrorMessage(int statusCode, string detail, Exception? ex, bool isReturnExceptionStackTraceInErrorDetail)
    {
        WriteMessageCore(StreamingHubPayloadBuilder.BuildError(MessageId, statusCode, detail, ex, isReturnExceptionStackTraceInErrorDetail));
        return default;
    }

    void WriteMessageCore(StreamingHubPayload payload)
    {
        ResponseSize = payload.Length; // NOTE: We cannot use the payload after QueueResponseStreamWrite.
        streamingServiceContext.QueueResponseStreamWrite(payload);
    }
}
