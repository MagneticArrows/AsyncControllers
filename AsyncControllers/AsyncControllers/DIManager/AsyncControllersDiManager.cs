using AsyncControllers.Interceptors;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace AsyncControllers.DIManager;

public static class AsyncControllersDiManager
{
    public static void SetAsyncControllersRegistration(this IServiceCollection services)
    {
        services.AddInterceptedControllers(Assembly.GetCallingAssembly());
    }

    public static void AddInterceptedControllers(this IServiceCollection services, Assembly assembly)
    {
           
    }
}