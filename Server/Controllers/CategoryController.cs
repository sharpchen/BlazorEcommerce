using BlazorEcommerce.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
	private readonly ICategoryService _service;

	public CategoryController(ICategoryService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<ActionResult<ServiceResponse<List<Category>>>> Get()
	{
		var categories = await _service.GetCategoriesAsync();
		return Ok(categories);
	}

	[HttpGet($"{{{nameof(id)}}}")]
	public async Task<ActionResult<ServiceResponse<Category>>> Get(int id)
	{
		var category = await _service.GetCategoryAsync(id);
		return Ok(category);
	}
}