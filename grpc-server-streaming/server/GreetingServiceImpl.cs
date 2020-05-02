using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Greet;
using static Greet.GreetingService;

namespace server
{
    public class GreetingServiceImpl : GreetingServiceBase
    {
        public override async Task GreetManyTimes(
            GreetManyTimesRequest request,
            IServerStreamWriter<GreetManyTimesResponse> responseStream,
            ServerCallContext context)
        {
            Console.WriteLine("The server received the request:");
            Console.WriteLine(request.ToString());

            var result = $"Hello {request.Greeting.FirstName} {request.Greeting.LastName}";

            foreach (var i in Enumerable.Range(1, 10))
            {
                await Task.Delay(500);

                await responseStream.WriteAsync(new GreetManyTimesResponse { Result = result });
            }
        }
    }
}