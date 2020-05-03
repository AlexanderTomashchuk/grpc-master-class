using System;
using System.Linq;
using System.Threading.Tasks;
using Calculator;
using Grpc.Core;
using static Calculator.CalculatorService;

namespace client {
    static class Program
    {
        private const string Target = "127.0.0.1:50051";
        
        static async Task Main (string[] args) {
            var channel = new Channel (Target, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine($"The client connected successfully to the target: {Target}");
                }
            });
            
            var client = new CalculatorServiceClient(channel);

            await FindMaxElement(client);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task FindMaxElement(CalculatorServiceClient client)
        {
            var duplexStream = client.FindMaximum();

            var responseReaderTask = Task.Run(async () =>
            {
                while (await duplexStream.ResponseStream.MoveNext())
                {
                    Console.WriteLine($"Received: {duplexStream.ResponseStream.Current}");
                }
            });

            var findMaximumRequestsList = new [] { 1, 5, 3, 6, 2, 20 }
                .Select(n => new FindMaximumRequest {Number = n});
            
            foreach (var findMaximumRequest in findMaximumRequestsList)
            {
                await Task.Delay(2500);
                await duplexStream.RequestStream.WriteAsync(findMaximumRequest);
                
                Console.WriteLine($"Sending: {findMaximumRequest}");
            }

            await duplexStream.RequestStream.CompleteAsync();
            
            await responseReaderTask;

            Console.WriteLine("Finished");
        }
    }
}
