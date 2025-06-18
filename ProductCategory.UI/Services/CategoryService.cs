using ProductCategory.Domain.Model;
using ProductCategory.UI.Models;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ProductCategory.UI.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;
        public CategoryService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ApiClient");
        }
        public async Task<List<Models.Category>> GetAllAsync()
        {
            var url = $"api/Categories";
            var response = await _http.GetFromJsonAsync<List<Models.Category>>(url);
            return response ?? new List<Models.Category>();
        }

        public async Task<bool> AddOrEditAsync(Models.Category category)
        {
            // If categoryId is empty => Add, else => Edit
            if (category.CategoryId == Guid.Empty)
            {
                // Assign new Guid (can also be done on backend)
                //category.CategoryId = Guid.NewGuid();

                var response = await _http.PostAsJsonAsync("api/Categories", category);
                return response.IsSuccessStatusCode;
            }
            else
            {
                var response = await _http.PutAsJsonAsync($"api/Categories/{category.CategoryId}", category);
                return response.IsSuccessStatusCode;
            }
        }
        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/Categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result ?? new ApiResponse { Status = true, Message = "Deleted successfully." };
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorObj = JsonSerializer.Deserialize<ApiResponse>(errorMessage, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return errorObj ?? new ApiResponse { Status = false, Message = errorObj.Message };
            }
        }


    }
}
