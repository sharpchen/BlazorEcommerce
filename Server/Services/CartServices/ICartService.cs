namespace BlazorEcommerce.Server.Services;

public interface ICartService
{
    Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> items);

}