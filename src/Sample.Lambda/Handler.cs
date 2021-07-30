using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sample.Lambda.Interfaces;
using Sample.Lambda.Models.Request;

namespace Sample.Lambda
{
    public class Handler : IHandler
    {
        private readonly ILogger _logger;
        public Handler(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Handle(Request request)
        {
            _logger.LogInformation($"{nameof(Handler)}.{nameof(Handle)}() => Reached handler.");
        }
    }
}