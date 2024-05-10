using Microsoft.AspNetCore.Mvc;

namespace AsyncControllers.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class HttpAsyncPostAttribute(string template) : HttpPostAttribute(template + "Async")
{
}
