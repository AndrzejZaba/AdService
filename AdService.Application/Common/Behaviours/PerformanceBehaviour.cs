using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AdService.Application.Common.Behaviours;


public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
{
    private readonly ILogger _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehaviour(ILogger<TRequest> logger)
    {
        _timer = new Stopwatch();
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();
        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            _logger.LogInformation("AdService - long running request: {@Name} ({@ElapsedMilliseconds} milliseconds) {@Request}", typeof(TRequest).Name, elapsedMilliseconds, request);
        }

        return response;

    }
}
