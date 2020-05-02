using System;
using System.IO;
using Calculator;
using Greet;
using Grpc.Core;
using GrpcServer = Grpc.Core.Server;

namespace server
{
    class Program
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            GrpcServer server = null;

            try
            {
                server = new GrpcServer
                {
                    Services = {
                        GreetingService.BindService(new GreetingServiceImpl()),
                        CalculatorService.BindService(new CalculatorServiceImpl())
                    },
                    Ports = { new Grpc.Core.ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
                };

                server.Start();

                Console.WriteLine($"The server is listening on the port {Port}...");
                Console.WriteLine("Press any key to terminate the server...");
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine($"The sarver failed to start. Error message: {e.Message}");
                throw;
            }
            finally
            {
                server?.ShutdownAsync().Wait();
                Console.WriteLine("The server has been teminated");
            }
        }
    }
}
