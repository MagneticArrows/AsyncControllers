using AsyncControllers.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace AsyncControllers.Filters
{
    public class AsyncifyActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<AsyncifyActionFilter> _logger;

        public AsyncifyActionFilter(ILogger<AsyncifyActionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var methodInfo = (context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo;

            if (methodInfo != null)
            {
                var asyncifyAttribute = methodInfo.GetCustomAttribute<AsyncifyAttribute>();
                if (asyncifyAttribute != null)
                {
                    _logger.LogInformation($"Before running the action asynchronously on thread {Thread.CurrentThread.ManagedThreadId}");
                    await Task.Run(() =>
                    {
                        _logger.LogInformation($"Inside Task.Run on thread {Thread.CurrentThread.ManagedThreadId}");
                        next();
                    });
                    _logger.LogInformation($"After running the action asynchronously on thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }

            // Proceed with the next action filter or action method synchronously
            await next();
        }
    }
}
