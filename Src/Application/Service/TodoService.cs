using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Src.Domain.Dto;

namespace Src.Application.Service
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TodoResponse> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<TodoResponse>("https://dummyjson.com/todos");
            return response;
        }
    }
}
