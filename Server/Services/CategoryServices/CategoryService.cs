using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services;

public class CategoryService : ICategoryService
{
	private readonly DataContext _context;

	public CategoryService(DataContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
	{
		return new ServiceResponse<List<Category>> { Data = await _context.Categories.ToListAsync() };
	}

	public async Task<ServiceResponse<Category>> GetCategoryAsync(int id)
	{
		var category = await _context.Categories.FindAsync(id);
		return category is null ? new()
		{
			Success = false,
			Message = "Sorry, failed to find the category..."
		} :
		new()
		{
			Data = category
		};
	}
}