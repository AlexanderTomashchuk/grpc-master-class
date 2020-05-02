// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: greeting.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Greet {
  public static partial class GreetingService
  {
    static readonly string __ServiceName = "greet.GreetingService";

    static readonly grpc::Marshaller<global::Greet.GreetManyTimesRequest> __Marshaller_greet_GreetManyTimesRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.GreetManyTimesRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Greet.GreetManyTimesResponse> __Marshaller_greet_GreetManyTimesResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.GreetManyTimesResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Greet.GreetManyTimesRequest, global::Greet.GreetManyTimesResponse> __Method_GreetManyTimes = new grpc::Method<global::Greet.GreetManyTimesRequest, global::Greet.GreetManyTimesResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GreetManyTimes",
        __Marshaller_greet_GreetManyTimesRequest,
        __Marshaller_greet_GreetManyTimesResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Greet.GreetingReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of GreetingService</summary>
    [grpc::BindServiceMethod(typeof(GreetingService), "BindService")]
    public abstract partial class GreetingServiceBase
    {
      public virtual global::System.Threading.Tasks.Task GreetManyTimes(global::Greet.GreetManyTimesRequest request, grpc::IServerStreamWriter<global::Greet.GreetManyTimesResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for GreetingService</summary>
    public partial class GreetingServiceClient : grpc::ClientBase<GreetingServiceClient>
    {
      /// <summary>Creates a new client for GreetingService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GreetingServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for GreetingService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GreetingServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GreetingServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GreetingServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::Greet.GreetManyTimesResponse> GreetManyTimes(global::Greet.GreetManyTimesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GreetManyTimes(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Greet.GreetManyTimesResponse> GreetManyTimes(global::Greet.GreetManyTimesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GreetManyTimes, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GreetingServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GreetingServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GreetingServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GreetManyTimes, serviceImpl.GreetManyTimes).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GreetingServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GreetManyTimes, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Greet.GreetManyTimesRequest, global::Greet.GreetManyTimesResponse>(serviceImpl.GreetManyTimes));
    }

  }
}
#endregion