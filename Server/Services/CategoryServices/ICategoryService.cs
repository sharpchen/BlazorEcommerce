﻿namespace BlazorEcommerce.Server.Services;

public interface ICategoryService
{
	Task<ServiceResponse<List<Category>>> GetCategoriesAsync();

	Task<ServiceResponse<Category>> GetCategoryAsync(int id);
}