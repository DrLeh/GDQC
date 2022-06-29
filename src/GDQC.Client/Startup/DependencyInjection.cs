using Microsoft.Extensions.DependencyInjection;

namespace GDQC.Client;

public static class DependencyInjection
{
    public static void AddGdqcClient(this IServiceCollection services)
    {

        var refitSettings = new RefitSettings();
        void RegisterApi<T>() where T : class =>
            services
                .AddRefitClient<T>(refitSettings)
                .ConfigureHttpClient(ConfigureHttpClient)
                ;

        RegisterApi<IGdqcApi>();
        services.AddSingleton<IScheduleService, GdqcClient>();
    }

    private static void ConfigureHttpClient(IServiceProvider sp, HttpClient client)
    {
        //    var config = sp.GetRequiredService<IEspConfiguration>();
        //    if (config.BaseUrl == null)
        //        throw new InvalidOperationException("ESP:BaseUrl must be configured");
        client.BaseAddress = new Uri("https://localhost:7140/");

        //var provider = sp.GetRequiredService<IAsiTokenProvider>();
        //var token = provider.GetToken();
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
