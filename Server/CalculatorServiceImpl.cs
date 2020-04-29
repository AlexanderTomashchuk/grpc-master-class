using Calculator;
using Grpc.Core;
using System.Threading.Tasks;
using static Calculator.CalculatorService;

namespace Server
{
    public class CalculatorServiceImpl : CalculatorServiceBase
    {
        public override Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            var result = request.A + request.B;

            return Task.FromResult(new SumResponse { Result = result });
        }
    }
}
