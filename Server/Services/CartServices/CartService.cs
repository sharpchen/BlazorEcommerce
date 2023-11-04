
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services;

public class CartService : ICartService
{
    readonly DataContext _context;
    public CartService(DataContext context) => _context = context;

    public async Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> items)
    {
        var result = new ServiceResponse<List<CartProductDTO>>()
        {
            Data = new()
        };
        foreach (var item in items)
        {
            var product = await _context.Products.Where(x => x.Id == item.ProductId).FirstOrDefaultAsync();
            if (product is null) continue;
            var variant = await _context.ProductVariants.Where(x => x.ProductId == item.ProductId && x.ProductTypeId == item.ProductTypeId)
                .Include(v => v.ProductType)
                .FirstOrDefaultAsync();
            if (variant is null) continue;
            var cartDTO = new CartProductDTO
            {
                ImageUrl = product.ImageUrl,
                Price = variant.Price,
                Title = product.Title,
                ProductId = product.Id,
                ProductType = variant.ProductType!.Name,
                ProductTypeId = variant.ProductTypeId
            };
            result.Data.Add(cartDTO);
        }
        return result;
    }
}