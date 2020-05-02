using System;
using System.Threading.Tasks;
using Calculator;
using static Calculator.CalculatorService;

namespace server
{
    public class CalculatorServiceImpl : CalculatorServiceBase
    {
        public override Task<Calculator.SumResponse> Sum(SumRequest request, Grpc.Core.ServerCallContext context)
        {
            var result = request.A + request.B;

            return Task.FromResult(new SumResponse { Result = result });
        }

        public override async Task PrimeNumberDecomposition(
            PrimeNumberDecompositionRequest request,
            Grpc.Core.IServerStreamWriter<PrimeNumberDecompositionResponse> responseStream,
            Grpc.Core.ServerCallContext context)
        {
            Console.WriteLine("The server received the request:");
            Console.WriteLine(request.ToString());

            var number = request.Number;

            uint divisor = 2;

            while (number > 1)
            {
                if (number % divisor == 0)
                {
                    number = number / divisor;

                    await Task.Delay(500);
                    await responseStream.WriteAsync(new PrimeNumberDecompositionResponse { PrimeFactor = divisor });
                }
                else
                {
                    divisor++;
                }
            }
        }
    }
}