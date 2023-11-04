using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService;

public interface IProductService
{
	int CurrentPage { get; set; }
	int PageCount { get; set; }
	string LastSearchedText { get; set; }
	event Action? ProductsChanged;

	List<Product> Products { get; set; }
	string Message { get; set; }
	Task GetProductsAsync(string? url = default);

	Task<ServiceResponse<Product>> GetProductAsync(int id);
	Task<ServiceResponse<List<string>>> GetSearchSuggestions(string searchText);
	Task SearchProducts(string searchText, int page);
}