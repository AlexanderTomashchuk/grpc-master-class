using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace server
{
    class Program
    {
        private const string Host = "localhost";
        private const int Port = 5002;
        
        static async Task Main(string[] args)
        {
            Server server = null;

            try
            {
                var serverCrt = File.ReadAllText("ssl/server.crt"); 
                var serverKey = File.ReadAllText("ssl/server.key"); 
                var caCrt = File.ReadAllText("ssl/ca.crt"); 
                
                var sslServerCredentials = new SslServerCredentials(
                    new List<KeyCertificatePair>
                    {
                        new KeyCertificatePair(serverCrt, serverKey)
                    },
                    caCrt,
                    true);
                
                server = new Server
                {
                    Services = { GreetingService.BindService(new GreetingServiceImpl()) },
                    Ports = { new ServerPort(Host, Port, sslServerCredentials) }
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
