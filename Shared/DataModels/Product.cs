using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Shared;

public class Product
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string ImageUrl { get; set; } = string.Empty;
	public Category? Category { get; set; }
	public int CategoryId { get; set; }
	public List<ProductVariant> Variants { get; set; } = new();
	public bool IsFeatured { get; set; } = false;

	public string PriceRange => Variants.Count switch
	{
		0 => string.Empty,
		1 => $"${Variants[0].Price}",
		_ => $"${Variants.Min(x => x.Price)} - {Variants.Max(x => x.Price)}"
	};
}