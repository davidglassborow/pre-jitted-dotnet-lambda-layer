using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Sample.Lambda.Interfaces;
using Sample.Lambda.Models.Request;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Sample.Lambda
{
    public class Function
    {
        private readonly IHandler _handler;
        public Function()
        {
            var collection = new ServiceCollection();
            var provider = collection.Boostrap();
            _handler = provider.GetService<IHandler>();
        }
        
        public async Task Handler(Request request, ILambdaContext context)
        {
            LambdaLogger.Log($"{nameof(Function)}.{nameof(Handler)}() => Incoming request: {JsonConvert.SerializeObject(request)}");
            await _handler.Handle(request);
        }
    }
}