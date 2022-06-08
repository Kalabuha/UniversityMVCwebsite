using Microsoft.Extensions.DependencyInjection;
using Task20.Services;

namespace Task20.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CourseService>();
            services.AddScoped<GroupService>();
            services.AddScoped<TeacherService>();
            services.AddScoped<StudentService>();

            return services;
        }
    }
}
