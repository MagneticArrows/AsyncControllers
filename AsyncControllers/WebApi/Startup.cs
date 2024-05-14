using Service;
using Model.DB;
using AsyncControllers.DIManager;
using AsyncControllers.Filters;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<AsyncifyActionFilter>();
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton(configuration);
        SetDiRegistration(services);
    }

    private static void SetDiRegistration(IServiceCollection services)
    {
        services.AddSingleton<IExampleService, ExampleService>();
        services.AddSingleton<IDbManager, DbManager>();
        services.SetAsyncControllersRegistration();
    }
}

