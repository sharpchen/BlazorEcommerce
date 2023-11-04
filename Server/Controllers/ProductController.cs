using BlazorEcommerce.Server.Services;
using BlazorEcommerce.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly IProductService _service;

	public ProductController(IProductService service) => _service = service;

	[HttpGet]
	public async Task<ActionResult<ServiceResponse<List<Product>>>> Get()
	{
		var products = await _service.GetProductsAsync();
		return Ok(products);
	}

	[HttpGet($"{{{nameof(id)}}}")]
	public async Task<ActionResult<ServiceResponse<Product>>> Get(int id)
	{
		var product = await _service.GetProductAsync(id);
		return Ok(product);
	}

	[HttpGet($"Category/{{{nameof(url)}}}")]
	public async Task<ActionResult<ServiceResponse<List<Product>>>> GetByCategoryName(string url)
	{
		var products = await _service.GetProductsByAsync(p => p.Category!.Url.ToLower() == url.ToLower());
		return Ok(products);
	}
	[HttpGet($"search/{{{nameof(searchText)}}}/{{{nameof(page)}}}")]
	public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> GetBySearchText(string searchText, int page = 1)
	{
		var products = await _service.GetSearchedProducts(searchText, page);
		return Ok(products);
	}

	[HttpGet($"searchSuggestions/{{{nameof(searchText)}}}")]
	public async Task<ActionResult<ServiceResponse<List<string>>>> GetSuggestionBySearchText(string searchText)
	{
		var suggestions = await _service.GetSearchSuggestionsAsync(searchText);
		return Ok(suggestions);
	}
	[HttpGet("featured")]
	public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
	{
		var products = await _service.GetFeatured();
		return Ok(products);
	}
}