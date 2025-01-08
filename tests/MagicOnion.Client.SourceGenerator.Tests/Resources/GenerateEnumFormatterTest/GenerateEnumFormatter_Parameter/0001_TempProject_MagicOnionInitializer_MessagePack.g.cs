﻿// <auto-generated />
#pragma warning disable CS0618 // 'member' is obsolete: 'text'
#pragma warning disable CS0612 // 'member' is obsolete
#pragma warning disable CS8019 // Unnecessary using directive.
#pragma warning disable CS1522 // Empty switch block

namespace TempProject
{
    using global::System;
    using global::MessagePack;

    partial class MagicOnionInitializer
    {
        /// <summary>
        /// Gets the generated MessagePack formatter resolver.
        /// </summary>
        public static global::MessagePack.IFormatterResolver Resolver => MessagePackGeneratedResolver.Instance;
        class MessagePackGeneratedResolver : global::MessagePack.IFormatterResolver
        {
            public static readonly global::MessagePack.IFormatterResolver Instance = new MessagePackGeneratedResolver();

            MessagePackGeneratedResolver() {}

            public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
                => FormatterCache<T>.formatter;

            static class FormatterCache<T>
            {
                public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

                static FormatterCache()
                {
                    var f = MessagePackGeneratedGetFormatterHelper.GetFormatter(typeof(T));
                    if (f != null)
                    {
                        formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                    }
                }
            }
        }
        static class MessagePackGeneratedGetFormatterHelper
        {
            static readonly global::System.Collections.Generic.Dictionary<global::System.Type, int> lookup;

            static MessagePackGeneratedGetFormatterHelper()
            {
                lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(1)
                {
                    {typeof(global::TempProject.MyEnum), 0},
                };
            }
            internal static object GetFormatter(global::System.Type t)
            {
                int key;
                if (!lookup.TryGetValue(t, out key))
                {
                    return null;
                }
            
                switch (key)
                {
                    case 0: return new MessagePackEnumFormatters.MyEnumFormatter();
                    default: return null;
                }
            }
        }
    }
}