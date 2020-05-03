using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Grpc.Core;
using Sqrt;

namespace server
{
    public class SqrtServiceImpl : SqrtService.SqrtServiceBase
    {
        public override async Task<SqrtResponse> Sqrt(SqrtRequest request, ServerCallContext context)
        {
            await Task.Delay(500);
            
            var number = request.Number;

            if (number >= 0)
            {
                return new SqrtResponse {SquareRoot = Math.Sqrt(number)};
            }
            else
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"The request parameter {nameof(number)} should be positive"));
            }
        }
    }
}