using ProductCategory.Domain.Model;
using ProductCategory.UI.Models;
using System.Text.Json;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("ApiClient");
    }

    public async Task<ApiPagedResponse<ProductCategory.UI.Models.Product>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
    {
        var url = $"api/products?pageNumber={pageNumber}&pageSize={pageSize}";
        var response = await _http.GetFromJsonAsync<ApiPagedResponse<ProductCategory.UI.Models.Product>>(url);
        return response ?? new ApiPagedResponse<ProductCategory.UI.Models.Product>();
    }
    public async Task<bool> AddOrEditAsync(ProductCategory.UI.Models.Product product)
    {
        if (product.ProductId == Guid.Empty)
        {
            // Add new product
            var response = await _http.PostAsJsonAsync("api/Products", product);
            return response.IsSuccessStatusCode;
        }
        else
        {
            // Update existing product
            var response = await _http.PutAsJsonAsync($"api/Products/{product.ProductId}", product);
            return response.IsSuccessStatusCode;
        }
    }

    public async Task<ApiResponse> DeleteAsync(Guid productId)
    {
        var response = await _http.DeleteAsync($"api/Products/{productId}");

        if (response.IsSuccessStatusCode)
            return new ApiResponse { Status = true, Message = "Product deleted successfully." };

        var errorContent = await response.Content.ReadAsStringAsync();

        try
        {
            var message = JsonDocument.Parse(errorContent).RootElement.GetProperty("message").GetString();
            return new ApiResponse { Status = false, Message = message };
        }
        catch
        {
            return new ApiResponse { Status = false, Message = "An unexpected error occurred." };
        }
    }

}
