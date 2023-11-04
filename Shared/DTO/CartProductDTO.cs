using System.Numerics;

namespace BlazorEcommerce.Shared;

public class CartProductDTO : IEqualityOperators<CartProductDTO, CartProductDTO, bool>
{
    public int ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ProductTypeId { get; set; }
    public string ProductType { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; } = 1;

    public static bool operator ==(CartProductDTO? left, CartProductDTO? right)
    {
        if (new[] { left, right }.Any(x => x is null)) return false;
        return left!.ProductId == right!.ProductId && left.ProductTypeId == right.ProductTypeId;
    }

    public static bool operator !=(CartProductDTO? left, CartProductDTO? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return (this, obj) switch
        {
            var _ when ReferenceEquals(this, obj) => true,
            var _ when obj is null => false,
            _ => this == (CartProductDTO)obj!
        };
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductId, ProductTypeId);
    }
}