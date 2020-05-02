using System.Threading.Tasks;
using Calculator;
using Grpc.Core;
using static Calculator.CalculatorService;

namespace server
{
    public class CalculatorServiceImpl : CalculatorServiceBase
    {
        public override async Task<ComputeAverageResponse> ComputeAverage(
            IAsyncStreamReader<Calculator.ComputeAverageRequest> requestStream,
            ServerCallContext context)
        {
            int total = 0;
            double result = 0.0;

            while (await requestStream.MoveNext())
            {
                var number = requestStream.Current.Number;

                result += number;
                total++;

                System.Console.WriteLine($"The number received from client: {number}");
            }

            return new ComputeAverageResponse { Result = result / total };
        }
    }
}