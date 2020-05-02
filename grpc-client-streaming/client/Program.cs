using System;
using System.Linq;
using System.Threading.Tasks;
using Calculator;
using Grpc.Core;
using static Calculator.CalculatorService;

namespace client
{
    class Program
    {
        const string Target = "127.0.0.1:50051";

        static async Task Main(string[] args)
        {
            var channel = new Channel(Target, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine($"The client connected successfully to the target: {Target}");
                }
            });

            Console.WriteLine("Press any key to send the request to the server...");
            Console.ReadKey();

            var client = new CalculatorServiceClient(channel);
            var stream = client.ComputeAverage();

            foreach (var i in Enumerable.Range(1, 4))
            {
                var request = new ComputeAverageRequest { Number = i };

                await Task.Delay(1000);
                await stream.RequestStream.WriteAsync(request);

                Console.WriteLine($"Number sent to the server: {i}");
            }

            await stream.RequestStream.CompleteAsync();

            var response = await stream.ResponseAsync;

            Console.WriteLine($"Average result: {response.Result}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
