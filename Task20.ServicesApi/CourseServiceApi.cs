using System.Net.Http.Json;
using Task20.Models;
using Task20.Entities;
using Task20.Services.Converters;

namespace Task20.ServicesApi
{
    public class CourseServiceApi
    {
        private readonly HttpClient _httpClient;

        public CourseServiceApi(HttpClient httpClient, IUserContext userContext)
        {
            _httpClient = httpClient;

            if (userContext.UserName != null)
            {
                _httpClient.DefaultRequestHeaders.Add("X-User-Name", userContext.UserName);
            }
        }

        public async Task<List<CourseModel>?> GetAllCourseModelsAsync()
        {
            var courses = await _httpClient.GetFromJsonAsync<CourseEntity[]>("/CourseRepositoryApi");
            return courses?.Select(c => c.EntityToModel()).ToList();
        }
    }
}
