using System;
using System.IO;
using System.Threading.Tasks;
using Calculator;
using Grpc.Core;

namespace server
{
    class Program
    {
        const int Port = 50051;

        static async Task Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server
                {
                    Services = { CalculatorService.BindService(new CalculatorServiceImpl()) },
                    Ports = { new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
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
                await server?.ShutdownAsync();
                Console.WriteLine("The server has been terminated");
            }
        }
    }
}
