using Grpc.Core;
using MagicOnion.Internal;

namespace MagicOnion;

/// <summary>
/// Wrapped AsyncServerStreamingCall.
/// </summary>
public readonly struct ServerStreamingResult<TResponse> : IDisposable
{
    readonly IAsyncServerStreamingCallWrapper<TResponse> inner;

    public ServerStreamingResult(IAsyncServerStreamingCallWrapper<TResponse> inner)
    {
        this.inner = inner;
    }

    /// <summary>
    /// Async stream to read streaming responses.
    /// </summary>
    public IAsyncStreamReader<TResponse> ResponseStream
        => inner.ResponseStream;

    /// <summary>
    /// Asynchronous access to response headers.
    /// </summary>
    public Task<Metadata> ResponseHeadersAsync
        => inner.ResponseHeadersAsync;

    /// <summary>
    /// Gets the call status if the call has already finished.
    /// Throws InvalidOperationException otherwise.
    /// </summary>
    public Status GetStatus()
        => inner.GetStatus();

    /// <summary>
    /// Gets the call trailing metadata if the call has already finished.
    /// Throws InvalidOperationException otherwise.
    /// </summary>
    public Metadata GetTrailers()
        => inner.GetTrailers();

    /// <summary>
    /// Provides means to cleanup after the call.
    /// If the call has already finished normally (response stream has been fully read), doesn't do anything.
    /// Otherwise, requests cancellation of the call which should terminate all pending async operations associated with the call.
    /// As a result, all resources being used by the call should be released eventually.
    /// </summary>
    /// <remarks>
    /// Normally, there is no need for you to dispose the call unless you want to utilize the
    /// "Cancel" semantics of invoking <c>Dispose</c>.
    /// </remarks>
    public void Dispose()
        => inner?.Dispose();
}
