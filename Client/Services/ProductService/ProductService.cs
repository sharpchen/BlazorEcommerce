using System.Net.Http.Json;
using System.Text.RegularExpressions;
using BlazorEcommerce.Shared;
using BlazorEcommerce.Shared.DTO;

namespace BlazorEcommerce.Client.Services.ProductService;

public class ProductService : IProductService
{
	private readonly HttpClient _http;

	public event Action? ProductsChanged;

	public ProductService(HttpClient http) => _http = http;

	public List<Product> Products { get; set; } = new();
	public string Message { get; set; } = "Loading Products...";
	public int CurrentPage { get; set; }
	public int PageCount { get; set; }
	public string LastSearchedText { get; set; } = string.Empty;

	public async Task<ServiceResponse<Product>> GetProductAsync(int id)
	{
		var response = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
		return response!;
	}

	public async Task GetProductsAsync(string? url = default)
	{
		var response = url is null ?
			await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured") :
			await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{url}");
		if (response is { Data: { } })
			Products = response!;

		CurrentPage = 1;
		PageCount = 0;

		ProductsChanged?.Invoke();
	}

	public async Task SearchProducts(string searchText, int page)
	{
		var response = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"api/product/search/{searchText}/{page}");
		if (response is { Data: { } and var dto })
		{
			Products = dto.Products;
			CurrentPage = dto.CurrentPage;
			PageCount = dto.Pages;
			LastSearchedText = searchText;
		}
		if (Products.Count == 0) Message = "No Product Found";
		ProductsChanged?.Invoke();
	}

	public async Task<ServiceResponse<List<string>>> GetSearchSuggestions(string searchText)
	{
		var response = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchSuggestions/{searchText}");
		return response!;
	}
}