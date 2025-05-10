using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoTask.Entities;

namespace TodoTask.Web.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:44379/api/app/todo-task";
        public TodoTaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TodoDto>> GetTodosAsync(string? status = null, string? priority = null,
                                                      DateTime? from = null, DateTime? to = null,
                                                      string? sortBy = null)
        {
            var queryParams = new List<string>();
            if (!string.IsNullOrEmpty(status)) queryParams.Add($"status={status}");
            if (!string.IsNullOrEmpty(priority)) queryParams.Add($"priority={priority}");
            if (from.HasValue) queryParams.Add($"from={from.Value:yyyy-MM-dd}");
            if (to.HasValue) queryParams.Add($"to={to.Value:yyyy-MM-dd}");
            if (!string.IsNullOrEmpty(sortBy)) queryParams.Add($"sortBy={sortBy}");

            var queryString = queryParams.Count > 0 ? $"?{string.Join("&", queryParams)}" : "";
            return await _httpClient.GetFromJsonAsync<List<TodoDto>>($"{BaseUrl}{queryString}");
        }

        public async Task<TodoDto> GetTodoAsync(Guid id)
            => await _httpClient.GetFromJsonAsync<TodoDto>($"{BaseUrl}/{id}");

        public async Task CreateTodoAsync(CreateUpdateTodoDto todo)
            => await _httpClient.PostAsJsonAsync(BaseUrl, todo);

        public async Task UpdateTodoAsync(Guid id, CreateUpdateTodoDto todo)
            => await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", todo);

        public async Task DeleteTodoAsync(Guid id)
            => await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

        public async Task MarkCompleteAsync(Guid id)
            => await _httpClient.PostAsync($"{BaseUrl}/{id}/mark-complete", null);
    }
}
