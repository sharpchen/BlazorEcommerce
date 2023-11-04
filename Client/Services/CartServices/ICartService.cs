using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client;

internal interface ICartService
{
    event Action? OnChange;
    Task AddToCart(CartItem item);
    Task<List<CartItem>> GetCartItems();
    Task<List<CartProductDTO>> GetCartProductDTOs();
    Task RemoveCartItem(CartProductDTO cartProduct);
    Task UpdateQuantity(CartProductDTO productDTO);
    Task<bool> CartContains(int productId, int productTypeId);
}