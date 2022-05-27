using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task20.DataContext.DataBaseContext;

namespace Task20.DataContext.Extensions
{
    public static class ExtensionsDb
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
