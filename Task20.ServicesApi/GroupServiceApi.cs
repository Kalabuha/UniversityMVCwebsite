using System.Net.Http.Json;
using Task20.Models;
using Task20.Entities;
using Task20.ApiModels;
using Task20.Services.Converters;

namespace Task20.ServicesApi
{
    public class GroupServiceApi
    {
        private readonly HttpClient _httpClient;

        public GroupServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GroupModel>?> GetAllGroupModelsAsync()
        {
            var courses = await _httpClient.GetFromJsonAsync<GroupEntity[]>("/GroupRepositoryApi");
            return courses?.Select(g => g.EntityToModel()).ToList();
        }

        public async Task<GroupModel?> GetGroupModelByGroupIdAsync(int id)
        {
            var groupModel = await _httpClient.GetFromJsonAsync<GroupEntity>($"/GroupRepositoryApi/{id}");
            return groupModel?.EntityToModel();
        }

        public async Task<bool> CraeteGroupAsync(GroupCreator creator)
        {
            var response = await _httpClient.PostAsJsonAsync($"/GroupRepositoryApi", creator);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateGroupByGroupIdAsync(int id, GroupUpdater updater)
        {
            var response = await _httpClient.PutAsJsonAsync($"/GroupRepositoryApi/{id}", updater);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteGroupByGroupIdAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/GroupRepositoryApi/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
