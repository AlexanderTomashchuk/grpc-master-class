using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Grpc.Core;
using Sqrt;

namespace server
{
    class Program
    {
        private const int Port = 50051;
        
        static async Task Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server
                {
                    Services = {SqrtService.BindService(new SqrtServiceImpl())},
                    Ports = {new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure)}
                };
                
                server.Start();

                Console.WriteLine($"The server is listening on the port {Port}...");
                Console.WriteLine("Press any key to terminate the server...");
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine($"The server failed to start. Error message: {e.Message}");
                throw;
            }
            finally
            {
                if (server != null)
                    await server.ShutdownAsync();
                
                Console.WriteLine("The server has been terminated");
            }
        }
    }
}
