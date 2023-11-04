using System.Linq.Expressions;
using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services;

public class ProductService : IProductService
{
	private readonly DataContext _context;

	public ProductService(DataContext context) => _context = context;

	public async Task<ServiceResponse<List<Product>>> GetFeatured()
	{
		var products = await _context.Products.Where(x => x.IsFeatured).Include(x => x.Variants).ToListAsync();
		return products;
	}

	public async Task<ServiceResponse<Product>> GetProductAsync(int id)
	{
		// include its variants and include product type in the variant
		// as the result Product
		// Test it in swagger!
		var product = await _context.Products.Include(p => p.Variants)
			.ThenInclude(v => v.ProductType)
			.FirstOrDefaultAsync(t => t.Id == id);
		return product is null ? new()
		{
			Success = false,
			Message = "Sorry, failed to find the product..."
		} :
		new()
		{
			Data = product
		};
	}

	public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
	{
		return new() { Data = await _context.Products.Include(p => p.Variants).ToListAsync() };
	}

	public async Task<ServiceResponse<List<Product>>> GetProductsByAsync(Expression<Func<Product, bool>> predicate)
	{
		return await _context.Products.Where(predicate).Include(p => p.Variants).ToListAsync();
	}

	public async Task<ServiceResponse<ProductSearchResultDTO>> GetSearchedProducts(string searchText, int page)
	{
		var text = searchText.Trim();
		List<Product> totalProducts = (await GetProductsByAsync(p => p.Title.Contains(text) || p.Description.Contains(text)))!;
		var pageResult = 2f;
		var pageCount = Math.Ceiling(totalProducts.Count / pageResult);
		var products = totalProducts.Skip((page - 1) * (int)pageResult).Take((int)pageResult).ToList();
		return new ProductSearchResultDTO
		{
			Products = products,
			CurrentPage = page,
			Pages = (int)pageCount
		};

	}

	public async Task<ServiceResponse<List<string>>> GetSearchSuggestionsAsync(string searchText)
	{
		var text = searchText.Trim();
		var products = await GetProductsByAsync(p => p.Title.Contains(text) || p.Description.Contains(text));
		List<string> suggestions = new();
		foreach (var p in products.Data!)
		{
			var words = p.Description.Split().Select(str => str.Trim(p.Description.Where(char.IsPunctuation).Distinct().ToArray()));
			suggestions.AddRange(words.Where(word => word.Contains(text, StringComparison.OrdinalIgnoreCase) && !suggestions.Contains(word)));
			if (p.Title.Contains(text, StringComparison.OrdinalIgnoreCase)) suggestions.Add(p.Title);
		}
		return suggestions;
	}
}
