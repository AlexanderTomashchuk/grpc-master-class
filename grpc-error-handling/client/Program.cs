using System;
using System.Threading.Tasks;
using Grpc.Core;
using Sqrt;
using static Sqrt.SqrtService;

namespace client
{
    class Program
    {
        private const string Target = "127.0.0.1:50051";
        
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

            var client = new SqrtServiceClient(channel);

            try
            {
                var sqrtRequest = new SqrtRequest { Number = 15 };

                var result = await client.SqrtAsync(
                    sqrtRequest,
                    //deadline: DateTime.UtcNow.AddMilliseconds(1000));
                    deadline: DateTime.UtcNow.AddMilliseconds(1000));

                Console.WriteLine($"sqrt({sqrtRequest.Number}) = {result.SquareRoot}");
            }
            catch (RpcException e) when (e.StatusCode == StatusCode.DeadlineExceeded)
            {
                Console.WriteLine("DeadlineExceeded exception received:");
                Console.WriteLine($"\t StatusCode: {e.Status.StatusCode}");
                Console.WriteLine($"\t Detail: {e.Status.Detail}");
            }
            catch (RpcException e)
            {
                Console.WriteLine("RpcException received:");
                Console.WriteLine($"\t StatusCode: {e.Status.StatusCode}");
                Console.WriteLine($"\t Detail: {e.Status.Detail}");
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
