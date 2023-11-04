using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _http;

    public CategoryService(HttpClient http) => _http = http;

    public List<Category> Categories { get; set; } = new();

    public async Task GetCategoriesAsync()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
        if (response is { Data: { } })
            Categories = response.Data;
    }

    public async Task<ServiceResponse<Category>> GetCategoryAsync(int id)
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<Category>>($"api/Category/{id}");
        return response!;
    }
}