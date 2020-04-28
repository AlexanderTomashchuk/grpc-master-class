using Greet;
using Grpc.Core;
using System;
using System.IO;
using GrpcServer = Grpc.Core.Server;

namespace Server
{
    public class Program
    {
        private const int Port = 50051;

        static void Main(string[] args)
        {
            GrpcServer server = null;

            try
            {
                server = new GrpcServer
                {
                    Services = { GreetingService.BindService(new GreetingServiceImpl()) },
                    Ports = {new ServerPort("localhost", Port, ServerCredentials.Insecure)}
                };

                server.Start();

                Console.WriteLine($"The server is listening on the port: {Port}");

                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine($"The server failed to start: {e.Message}");
                throw;
            }
            finally
            {
                server?.ShutdownAsync().Wait();
            }
        }
    }
}
