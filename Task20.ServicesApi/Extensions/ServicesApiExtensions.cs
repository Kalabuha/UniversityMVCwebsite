using Microsoft.Extensions.DependencyInjection;

namespace Task20.ServicesApi.Extensions
{
    public static class ServicesApiExtensions
    {
        public static IServiceCollection RegisterServicesApi(this IServiceCollection services, string hostApi)
        {
            services
                .AddHttpClient("Api", client => client.BaseAddress = new Uri(hostApi))
                .AddTypedClient<CourseServiceApi>()
                .AddTypedClient<GroupServiceApi>();

            return services;
        }
    }
}
