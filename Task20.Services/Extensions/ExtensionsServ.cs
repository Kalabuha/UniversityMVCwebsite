using Microsoft.Extensions.DependencyInjection;
using Task20.Services.AboutROUService;

namespace Task20.Services.Extensions
{
    public static class ExtensionsServ
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CourseService>();
            //services.AddScoped<GroupRepository>();
            //services.AddScoped<StudentRepository>();
            //services.AddScoped<TeacherRepository>();

            return services;
        }
    }
}
