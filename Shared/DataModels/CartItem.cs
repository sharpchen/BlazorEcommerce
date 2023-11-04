using System.Numerics;

namespace BlazorEcommerce.Shared;

public class CartItem : IEqualityOperators<CartItem, CartItem, bool>
{
    public int ProductId { get; set; }
    public int ProductTypeId { get; set; }
    public int Quantity { get; set; } = 1;

    public static bool operator ==(CartItem? left, CartItem? right)
    {
        if (new[] { left, right }.Any(x => x is null)) return false;
        return left!.ProductId == right!.ProductId && left.ProductTypeId == right.ProductTypeId;
    }

    public static bool operator !=(CartItem? left, CartItem? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return (this, obj) switch
        {
            var _ when ReferenceEquals(this, obj) => true,
            var _ when obj is null => false,
            _ => this == (CartItem)obj!
        };
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductId, ProductTypeId);
    }
}