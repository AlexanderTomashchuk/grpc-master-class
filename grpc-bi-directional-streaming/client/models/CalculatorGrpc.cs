// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: calculator.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Calculator {
  public static partial class CalculatorService
  {
    static readonly string __ServiceName = "calculator.CalculatorService";

    static readonly grpc::Marshaller<global::Calculator.FindMaximumRequest> __Marshaller_calculator_FindMaximumRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.FindMaximumRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.FindMaximumResponse> __Marshaller_calculator_FindMaximumResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.FindMaximumResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Calculator.FindMaximumRequest, global::Calculator.FindMaximumResponse> __Method_FindMaximum = new grpc::Method<global::Calculator.FindMaximumRequest, global::Calculator.FindMaximumResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "FindMaximum",
        __Marshaller_calculator_FindMaximumRequest,
        __Marshaller_calculator_FindMaximumResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Calculator.CalculatorReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CalculatorService</summary>
    [grpc::BindServiceMethod(typeof(CalculatorService), "BindService")]
    public abstract partial class CalculatorServiceBase
    {
      public virtual global::System.Threading.Tasks.Task FindMaximum(grpc::IAsyncStreamReader<global::Calculator.FindMaximumRequest> requestStream, grpc::IServerStreamWriter<global::Calculator.FindMaximumResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CalculatorService</summary>
    public partial class CalculatorServiceClient : grpc::ClientBase<CalculatorServiceClient>
    {
      /// <summary>Creates a new client for CalculatorService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CalculatorServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CalculatorService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CalculatorServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CalculatorServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CalculatorServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncDuplexStreamingCall<global::Calculator.FindMaximumRequest, global::Calculator.FindMaximumResponse> FindMaximum(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FindMaximum(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Calculator.FindMaximumRequest, global::Calculator.FindMaximumResponse> FindMaximum(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_FindMaximum, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CalculatorServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CalculatorServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CalculatorServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_FindMaximum, serviceImpl.FindMaximum).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CalculatorServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_FindMaximum, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::Calculator.FindMaximumRequest, global::Calculator.FindMaximumResponse>(serviceImpl.FindMaximum));
    }

  }
}
#endregion
