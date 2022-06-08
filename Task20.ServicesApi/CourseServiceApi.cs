using System.Net.Http.Json;
using Task20.Models;
using Task20.Entities;
using Task20.Services.Converters;

namespace Task20.ServicesApi
{
    public class CourseServiceApi
    {
        private readonly HttpClient _httpClient;

        public CourseServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CourseModel>?> GetAllCourseModelsAsync()
        {
            var courses = await _httpClient.GetFromJsonAsync<CourseEntity[]>("/CourseRepositoryApi");
            return courses?.Select(c => c.EntityToModel()).ToList();
        }
    }
}
