using Grpc.Core;
using MessagePack;
using System;
using System.Buffers;
using System.Linq;
using System.Reflection;

namespace MagicOnion.Internal
{
    // invoke from dynamic methods so must be public
    internal static class MagicOnionMarshallers
    {
        static readonly Type[] dynamicArgumentTupleTypes = typeof(DynamicArgumentTuple<,>).GetTypeInfo().Assembly
            .GetTypes()
            .Where(x => x.Name.StartsWith("DynamicArgumentTuple") && !x.Name.Contains("Formatter"))
            .OrderBy(x => x.GetGenericArguments().Length)
            .ToArray();

        internal static Marshaller<StreamingHubPayload> StreamingHubMarshaller { get; } = new(
            serializer: static (payload, context) =>
            {
                context.SetPayloadLength(payload.Length);
                var bufferWriter = context.GetBufferWriter();
                payload.Span.CopyTo(bufferWriter.GetSpan(payload.Length));
                bufferWriter.Advance(payload.Length);
                context.Complete();
                StreamingHubPayloadPool.Shared.Return(payload);
            },
            deserializer: static context =>
            {
                return StreamingHubPayloadPool.Shared.RentOrCreate(context.PayloadAsReadOnlySequence());
            }
        );

        internal static Type CreateRequestType(ParameterInfo[] parameters)
        {
            if (parameters.Length == 0)
            {
                return typeof(Nil);
            }
            else if (parameters.Length == 1)
            {
                var t = parameters[0].ParameterType;
                return t;
            }
            else if (parameters.Length >= 16)
            {
                throw new InvalidOperationException($"The method '{parameters[0].Member.DeclaringType!.FullName}.{parameters[0].Member.Name}' must have less than 16 parameters. (Length: {parameters.Length})");
            }
            else
            {
                // start from T2
                var tupleTypeBase = dynamicArgumentTupleTypes[parameters.Length - 2];
                var t = tupleTypeBase.MakeGenericType(parameters.Select(x => x.ParameterType).ToArray());
                return t;
            }
        }

        public static object InstantiateDynamicArgumentTuple(Type[] typeParameters, object[] arguments)
        {
            // start from T2
            var tupleTypeBase = dynamicArgumentTupleTypes[arguments.Length - 2];
            return Activator.CreateInstance(tupleTypeBase.MakeGenericType(typeParameters), arguments)!;
        }
    }

}
