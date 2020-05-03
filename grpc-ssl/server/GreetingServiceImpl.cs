using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace server
{
    public class GreetingServiceImpl : GreetingService.GreetingServiceBase
    {
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            var result = $"Hello {request.Greeting.FirstName} {request.Greeting.LastName}";

            return Task.FromResult(new GreetingResponse {Result = result});
        }
    }
}