using System;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using Greet;
using Grpc.Core;
using static Calculator.CalculatorService;
using static Greet.GreetingService;

namespace client
{
    class Program
    {
        static string Target = $"127.0.0.1:50051";

        static async Task Main(string[] args)
        {
            var channel = new Channel(Target, ChannelCredentials.Insecure);

            await channel.ConnectAsync(DateTime.UtcNow.AddSeconds(20)).ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The client connected successfully");
                }
            });

            Console.WriteLine("Press any key to send the request to the server...");
            Console.ReadKey();

            var client = new CalculatorServiceClient(channel);

            var request = new PrimeNumberDecompositionRequest
            {
                Number = 120
            };

            Console.WriteLine("");

            var response = client.PrimeNumberDecomposition(request);

            Console.Write($"{request.Number}=");

            var i = 0;
            while (await response.ResponseStream.MoveNext())
            {
                var primeFactor = response.ResponseStream.Current.PrimeFactor;

                if (i > 0)
                    Console.Write("*");

                Console.Write(primeFactor);

                i++;
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
