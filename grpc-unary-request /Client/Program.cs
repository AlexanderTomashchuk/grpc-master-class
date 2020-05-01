using Calculator;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        private const string Target = "127.0.0.1:50051";

        static void Main(string[] args)
        {
            var channel = new Channel(Target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The client connected successfully");
                }
            }).Wait();

            Console.WriteLine("Press any key to send the request to the server...");
            Console.ReadKey();

            // unary request
            //var client = new GreetingService.GreetingServiceClient(channel);

            //var greeting = new Greeting
            //{
            //    FirstName = "Tom",
            //    LastName = "Jones"
            //};

            //var request = new GreetingRequest { Greeting = greeting };
            //var response = client.GreetAsync(request).GetAwaiter().GetResult();

            //Console.WriteLine(response.Result);

            // unary request (exercise)

            var client = new CalculatorService.CalculatorServiceClient(channel);

            var request = new SumRequest
            {
                A = 10,
                B = -1
            };

            var response = client.SumAsync(request).GetAwaiter().GetResult();

            Console.WriteLine(response.Result);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
