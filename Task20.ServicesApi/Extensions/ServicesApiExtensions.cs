using Microsoft.Extensions.DependencyInjection;

namespace Task20.ServicesApi
{
    public static class ServicesApiExtensions
    {
        public static IServiceCollection RegisterServicesApi(this IServiceCollection services, string hostApi)
        {
            services
                .AddHttpClient("CourseServiceApiClient", (serviceProvider, client) =>
                {
                    var userContext = serviceProvider.GetRequiredService<IUserContext>();
                    client.BaseAddress = new Uri(hostApi);
                    if (userContext.UserName != null)
                    {
                        client.DefaultRequestHeaders.Add("X-User-Name", userContext.UserName);
                    }
                })
                .AddTypedClient<CourseServiceApi>();

            services
                .AddHttpClient("GroupServiceApiClient", (serviceProvider, client) =>
                {
                    var userContext = serviceProvider.GetRequiredService<IUserContext>();
                    client.BaseAddress = new Uri(hostApi);
                    if (userContext.UserName != null)
                    {
                        client.DefaultRequestHeaders.Add("X-User-Name", userContext.UserName);
                    }
                })
                .AddTypedClient<GroupServiceApi>();

            return services;
        }
    }
}
