﻿// <auto-generated />
#pragma warning disable CS0618 // 'member' is obsolete: 'text'
#pragma warning disable CS0612 // 'member' is obsolete
#pragma warning disable CS8019 // Unnecessary using directive.

namespace TempProject
{
    partial class MagicOnionInitializer
    {
        static partial class MagicOnionGeneratedClient
        {
            [global::MagicOnion.Ignore]
            public class TempProject_MyServiceClient : global::MagicOnion.Client.MagicOnionClientBase<global::TempProject.IMyService>, global::TempProject.IMyService
            {
                class ClientCore
                {
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.List<global::TempProject.MyResponse>> MethodList;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.IList<global::TempProject.MyResponse>> MethodIList;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.IReadOnlyList<global::TempProject.MyResponse>> MethodIROList;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.Dictionary<global::System.String, global::TempProject.MyResponse>> MethodDictionary;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.IDictionary<global::System.String, global::TempProject.MyResponse>> MethodIDictionary;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::TempProject.MyResponse>> MethodIRODictionary;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.IEnumerable<global::TempProject.MyResponse>> MethodIEnumerable;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.ICollection<global::TempProject.MyResponse>> MethodICollection;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Collections.Generic.IReadOnlyCollection<global::TempProject.MyResponse>> MethodIROCollection;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Linq.ILookup<global::System.Int32, global::TempProject.MyResponse>> MethodILookup;
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::System.Linq.IGrouping<global::System.Int32, global::TempProject.MyResponse>> MethodIGrouping;
                    public ClientCore(global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider)
                    {
                        this.MethodList = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_RefType_RefType<global::System.Collections.Generic.List<global::System.Int32>, global::System.Collections.Generic.List<global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodList", serializerProvider);
                        this.MethodIList = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.IList<global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodIList", serializerProvider);
                        this.MethodIROList = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.IReadOnlyList<global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodIROList", serializerProvider);
                        this.MethodDictionary = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.Dictionary<global::System.String, global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodDictionary", serializerProvider);
                        this.MethodIDictionary = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.IDictionary<global::System.String, global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodIDictionary", serializerProvider);
                        this.MethodIRODictionary = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodIRODictionary", serializerProvider);
                        this.MethodIEnumerable = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.IEnumerable<global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodIEnumerable", serializerProvider);
                        this.MethodICollection = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.ICollection<global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodICollection", serializerProvider);
                        this.MethodIROCollection = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Collections.Generic.IReadOnlyCollection<global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodIROCollection", serializerProvider);
                        this.MethodILookup = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Linq.ILookup<global::System.Int32, global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodILookup", serializerProvider);
                        this.MethodIGrouping = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::System.Linq.IGrouping<global::System.Int32, global::TempProject.MyResponse>>(global::Grpc.Core.MethodType.Unary, "IMyService", "MethodIGrouping", serializerProvider);
                    }
                 }

                readonly ClientCore core;

                public TempProject_MyServiceClient(global::MagicOnion.Client.MagicOnionClientOptions options, global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider) : base(options)
                {
                    this.core = new ClientCore(serializerProvider);
                }

                private TempProject_MyServiceClient(global::MagicOnion.Client.MagicOnionClientOptions options, ClientCore core) : base(options)
                {
                    this.core = core;
                }

                protected override global::MagicOnion.Client.MagicOnionClientBase<global::TempProject.IMyService> Clone(global::MagicOnion.Client.MagicOnionClientOptions options)
                    => new TempProject_MyServiceClient(options, core);

                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.List<global::TempProject.MyResponse>> MethodList(global::System.Collections.Generic.List<global::System.Int32> args)
                    => this.core.MethodList.InvokeUnary(this, "IMyService/MethodList", args);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.IList<global::TempProject.MyResponse>> MethodIList()
                    => this.core.MethodIList.InvokeUnary(this, "IMyService/MethodIList", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.IReadOnlyList<global::TempProject.MyResponse>> MethodIROList()
                    => this.core.MethodIROList.InvokeUnary(this, "IMyService/MethodIROList", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.Dictionary<global::System.String, global::TempProject.MyResponse>> MethodDictionary()
                    => this.core.MethodDictionary.InvokeUnary(this, "IMyService/MethodDictionary", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.IDictionary<global::System.String, global::TempProject.MyResponse>> MethodIDictionary()
                    => this.core.MethodIDictionary.InvokeUnary(this, "IMyService/MethodIDictionary", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::TempProject.MyResponse>> MethodIRODictionary()
                    => this.core.MethodIRODictionary.InvokeUnary(this, "IMyService/MethodIRODictionary", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.IEnumerable<global::TempProject.MyResponse>> MethodIEnumerable()
                    => this.core.MethodIEnumerable.InvokeUnary(this, "IMyService/MethodIEnumerable", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.ICollection<global::TempProject.MyResponse>> MethodICollection()
                    => this.core.MethodICollection.InvokeUnary(this, "IMyService/MethodICollection", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Collections.Generic.IReadOnlyCollection<global::TempProject.MyResponse>> MethodIROCollection()
                    => this.core.MethodIROCollection.InvokeUnary(this, "IMyService/MethodIROCollection", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Linq.ILookup<global::System.Int32, global::TempProject.MyResponse>> MethodILookup()
                    => this.core.MethodILookup.InvokeUnary(this, "IMyService/MethodILookup", global::MessagePack.Nil.Default);
                public global::MagicOnion.UnaryResult<global::System.Linq.IGrouping<global::System.Int32, global::TempProject.MyResponse>> MethodIGrouping()
                    => this.core.MethodIGrouping.InvokeUnary(this, "IMyService/MethodIGrouping", global::MessagePack.Nil.Default);
            }
        }
    }
}