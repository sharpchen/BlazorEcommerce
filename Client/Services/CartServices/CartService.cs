
using System.Net.Http.Json;
using System.Numerics;
using BlazorEcommerce.Shared;
using Blazored.LocalStorage;

namespace BlazorEcommerce.Client;

internal class CartService : ICartService
{
    readonly ILocalStorageService _localStorageService;
    readonly HttpClient _http;

    public CartService(ILocalStorageService localStorageService, HttpClient http)
    {
        _localStorageService = localStorageService;
        _http = http;
    }

    public event Action? OnChange;

    public async Task AddToCart(CartItem newItem)
    {
        var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
        cartItems ??= new();
        // find existing unique variant in cart
        // if does exist, add up
        if (cartItems.FirstOrDefault(x => x.ProductId == newItem.ProductId && x.ProductTypeId == newItem.ProductTypeId) is { } and var same)
        {
            same.Quantity += newItem.Quantity;
        }
        else
        {
            cartItems.Add(newItem);
        }
        await _localStorageService.SetItemAsync("cart", cartItems);
        OnChange?.Invoke();
    }

    public async Task<bool> CartContains(int productId, int productTypeId)
    {
        var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
        if (cartItems is null) return false;
        return cartItems.Any(x => x.ProductTypeId == productTypeId && x.ProductId == productId);
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
        cart ??= new();
        return cart;
    }

    /// <summary>
    /// Get infos of items added in cart from server
    /// </summary>
    /// <returns></returns>
    public async Task<List<CartProductDTO>> GetCartProductDTOs()
    {
        var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
        var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
        var cartProduct = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductDTO>>>();
        return cartProduct!.Data!;
    }

    public async Task RemoveCartItem(CartProductDTO cartProduct)
    {
        var items = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

        if (items is null) return;

        items.RemoveAll(x => x.ProductTypeId == cartProduct.ProductTypeId && x.ProductId == cartProduct.ProductId);
        await _localStorageService.SetItemAsync("cart", items);
        OnChange?.Invoke();
    }

    public async Task UpdateQuantity(CartProductDTO product)
    {
        var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

        if (cartItems is null) return;

        if (cartItems.FirstOrDefault(x => x.ProductTypeId == product.ProductTypeId && x.ProductId == product.ProductId) is { } and var match)
        {
            match.Quantity = product.Quantity;
            await _localStorageService.SetItemAsync("cart", cartItems);
        }

    }
}

public static class IEnumerableExtension
{
    public static int QuantityIn<T>(this T source, IEnumerable<T> cartItems) where T : IEqualityOperators<T, T, bool>
    {
        return cartItems.Where(x => x == source).Count();
    }
}