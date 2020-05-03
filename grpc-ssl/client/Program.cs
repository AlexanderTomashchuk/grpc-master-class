using System;
using System.IO;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace client
{
    class Program
    {
        private const string Host = "localhost";
        private const int TargetPort = 5002;
        
        static async Task Main(string[] args)
        {
            var clientCrt = File.ReadAllText("ssl/client.crt"); 
            var clientKey = File.ReadAllText("ssl/client.key"); 
            var caCrt = File.ReadAllText("ssl/ca.crt"); 
            
            var channelCredentials = new SslCredentials(caCrt, new KeyCertificatePair(clientCrt, clientKey));
            
            var channel = new Channel(Host, TargetPort, channelCredentials);

            await channel.ConnectAsync().ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine($"The client connected successfully to the target: {Host}:{TargetPort}");
                }
            });
            
            var client = new GreetingServiceClient(channel);
    
            var greetingRequest = new GreetingRequest
            {
                Greeting = new Greeting
                {
                    FirstName = "Oleksandr",
                    LastName = "Tomashchuk"
                }
            };

            var response = await client.GreetAsync(greetingRequest);

            Console.WriteLine($"Greeting result: {response.Result}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
