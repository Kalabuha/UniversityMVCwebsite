using Microsoft.Extensions.DependencyInjection;
using Task20.Repositories;

namespace Task20.Repositories.Extensions
{
    public static class ExtensionsRepos
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<CourseRepository>();
            services.AddScoped<GroupRepository>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<TeacherRepository>();

            return services;
        }
    }
}
