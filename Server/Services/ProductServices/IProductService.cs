using System.Linq.Expressions;
using BlazorEcommerce.Shared.DTO;

namespace BlazorEcommerce.Server.Services;

public interface IProductService
{
	Task<ServiceResponse<List<Product>>> GetProductsAsync();
	Task<ServiceResponse<Product>> GetProductAsync(int id);
	Task<ServiceResponse<List<Product>>> GetProductsByAsync(Expression<Func<Product, bool>> predicate);
	Task<ServiceResponse<List<string>>> GetSearchSuggestionsAsync(string searchText);
	Task<ServiceResponse<List<Product>>> GetFeatured();
	Task<ServiceResponse<ProductSearchResultDTO>> GetSearchedProducts(string searchText, int page);
}