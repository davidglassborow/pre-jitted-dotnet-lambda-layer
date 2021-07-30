using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Sample.Lambda.Interfaces;
using Sample.Lambda.Models.Request;

namespace Sample.Lambda
{
    public class Handler : IHandler
    {
        public async Task Handle(Request request)
        {
            LambdaLogger.Log($"{nameof(Handler)}.{nameof(Handle)}() => Reached handler.");
        }
    }
}