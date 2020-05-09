using System;
using System.IO;
using System.Threading.Tasks;
using Blog;
using Grpc.Core;
using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;

namespace server
{
    class Program
    {
        private const string Host = "localhost";
        private const int Port = 50051;
        
        static async Task Main(string[] args)
        {
            Server server = null;

            try
            {
                var reflectionServiceImpl = new ReflectionServiceImpl(BlogService.Descriptor, ServerReflection.Descriptor);
                
                server = new Server
                {
                    Services =
                    {
                        BlogService.BindService(new BlogServiceImpl()),
                        ServerReflection.BindService(reflectionServiceImpl)
                    },
                    Ports = { new ServerPort(Host, Port, ServerCredentials.Insecure) }
                };
                
                server.Start();

                Console.WriteLine($"The server is listening on the port {Port}...");
                Console.WriteLine("Press any key to terminate the server...");
                Console.ReadKey();
            }
            catch (Exception e)
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