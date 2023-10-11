using MagicOnion.Client.SourceGenerator.CodeAnalysis;
using MagicOnion.Client.SourceGenerator.CodeGen.Extensions;

namespace MagicOnion.Client.SourceGenerator.CodeGen;

internal class MagicOnionInitializerGenerator
{
    public static string Build(GeneratorOptions options, MagicOnionServiceCollection serviceCollection)
    {
        var writer = new StringWriter();
        writer.WriteLine($$"""
            #pragma warning disable 618
            #pragma warning disable 612
            #pragma warning disable 414
            #pragma warning disable 219
            #pragma warning disable 168

            // NOTE: Disable warnings for nullable reference types.
            // `#nullable disable` causes compile error on old C# compilers (-7.3)
            #pragma warning disable 8603 // Possible null reference return.
            #pragma warning disable 8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
            #pragma warning disable 8625 // Cannot convert null literal to non-nullable reference type.

            namespace {{options.Namespace}}
            {
                using global::System;
                using global::System.Collections.Generic;
                using global::System.Linq;
                using global::MagicOnion;
                using global::MagicOnion.Client;

                public static partial class MagicOnionInitializer
                {
                    static bool isRegistered = false;

            """);
        if (!options.DisableAutoRegister)
        {
            writer.WriteLine($$"""
            #if UNITY_2019_4_OR_NEWER
                    [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
            #elif NET5_0_OR_GREATER
                    [System.Runtime.CompilerServices.ModuleInitializer]
            #endif
            """);
        }
        writer.WriteLine($$"""
                    public static void Register()
                    {
                        if (isRegistered) return;
                        isRegistered = true;

                        global::MagicOnion.Client.MagicOnionClientFactoryProvider.Default =
                            (global::MagicOnion.Client.MagicOnionClientFactoryProvider.Default is global::MagicOnion.Client.ImmutableMagicOnionClientFactoryProvider immutableMagicOnionClientFactoryProvider)
                                ? immutableMagicOnionClientFactoryProvider.Add(MagicOnionGeneratedClientFactoryProvider.Instance)
                                : new global::MagicOnion.Client.ImmutableMagicOnionClientFactoryProvider(MagicOnionGeneratedClientFactoryProvider.Instance);

                        global::MagicOnion.Client.StreamingHubClientFactoryProvider.Default =
                            (global::MagicOnion.Client.StreamingHubClientFactoryProvider.Default is global::MagicOnion.Client.ImmutableStreamingHubClientFactoryProvider immutableStreamingHubClientFactoryProvider)
                                ? immutableStreamingHubClientFactoryProvider.Add(MagicOnionGeneratedClientFactoryProvider.Instance)
                                : new global::MagicOnion.Client.ImmutableStreamingHubClientFactoryProvider(MagicOnionGeneratedClientFactoryProvider.Instance);
                    }
                }

                public partial class MagicOnionGeneratedClientFactoryProvider : global::MagicOnion.Client.IMagicOnionClientFactoryProvider, global::MagicOnion.Client.IStreamingHubClientFactoryProvider
                {
                    public static MagicOnionGeneratedClientFactoryProvider Instance { get; } = new MagicOnionGeneratedClientFactoryProvider();

                    MagicOnionGeneratedClientFactoryProvider() {}

                    bool global::MagicOnion.Client.IMagicOnionClientFactoryProvider.TryGetFactory<T>(out global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T> factory)
                        => (factory = MagicOnionClientFactoryCache<T>.Factory) != null;

                    bool global::MagicOnion.Client.IStreamingHubClientFactoryProvider.TryGetFactory<TStreamingHub, TReceiver>(out global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver> factory)
                        => (factory = StreamingHubClientFactoryCache<TStreamingHub, TReceiver>.Factory) != null;

                    static class MagicOnionClientFactoryCache<T> where T : global::MagicOnion.IService<T>
                    {
                        public readonly static global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T> Factory;

                        static MagicOnionClientFactoryCache()
                        {
                            object factory = default(global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T>);

            """);

        foreach (var serviceInfo in serviceCollection.Services)
        {
           writer.WriteLine($$"""
                            if (typeof(T) == typeof({{serviceInfo.ServiceType.FullName}}))
                            {
                                factory = ((global::MagicOnion.Client.MagicOnionClientFactoryDelegate<{{serviceInfo.ServiceType.FullName}}>)((x, y) => new {{serviceInfo.GetClientFullName()}}(x, y)));
                            }
            """);
        }

        writer.WriteLine($$"""
                            Factory = (global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T>)factory;
                        }
                    }
                    
                    static class StreamingHubClientFactoryCache<TStreamingHub, TReceiver> where TStreamingHub : global::MagicOnion.IStreamingHub<TStreamingHub, TReceiver>
                    {
                        public readonly static global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver> Factory;

                        static StreamingHubClientFactoryCache()
                        {
                            object factory = default(global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver>);

            """);
        foreach (var hubInfo in serviceCollection.Hubs)
        {
            writer.WriteLine($$"""
                            if (typeof(TStreamingHub) == typeof({{hubInfo.ServiceType.FullName}}) && typeof(TReceiver) == typeof({{hubInfo.Receiver.ReceiverType.FullName}}))
                            {
                                factory = ((global::MagicOnion.Client.StreamingHubClientFactoryDelegate<{{hubInfo.ServiceType.FullName}}, {{hubInfo.Receiver.ReceiverType.FullName}}>)((a, _, b, c, d, e) => new {{hubInfo.GetClientFullName()}}(a, b, c, d, e)));
                            }
            """);
        }

        writer.WriteLine($$"""

                            Factory = (global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver>)factory;
                        }
                    }
                }

            }

            #pragma warning restore 168
            #pragma warning restore 219
            #pragma warning restore 414
            #pragma warning restore 612
            #pragma warning restore 618
            """);

        return writer.ToString();
    }
}
