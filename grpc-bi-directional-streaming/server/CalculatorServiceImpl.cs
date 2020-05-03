using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator;
using Grpc.Core;

namespace server
{
    public class CalculatorServiceImpl : CalculatorService.CalculatorServiceBase
    {
        public override async Task FindMaximum(
            IAsyncStreamReader<FindMaximumRequest> requestStream,
            IServerStreamWriter<FindMaximumResponse> responseStream,
            ServerCallContext context)
        {
            int? max = null;

            while (await requestStream.MoveNext())
            {
                await Task.Delay(2000);

                if (max == null || max < requestStream.Current.Number)
                {
                    max = requestStream.Current.Number;
                    
                    var response = new FindMaximumResponse { MaxNumber = max.Value };
                
                    await responseStream.WriteAsync(response);    
                }
            }
        }
    }
}