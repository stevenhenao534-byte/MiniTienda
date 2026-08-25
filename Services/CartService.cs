using MiniTiendaLicores.Models;

namespace MiniTiendaLicores.Services;

public class CartService
{
    private readonly List<Product> _cartItems = new();

    public void AddToCart(Product product)
    {
        _cartItems.Add(product);
        Console.WriteLine($"Producto '{product.Name}' agregado al carrito.");
    }

    public void ShowCart()
    {
        Console.WriteLine("\n=== Carrito de compras ===");

        if (_cartItems.Count == 0)
        {
            Console.WriteLine("El carrito está vacío.");
            return;
        }

        foreach (Product item in _cartItems)
        {
            Console.WriteLine($"{item.Id}: {item.Name} - ${item.Price:N0}");
        }

        Console.WriteLine($"Total: ${GetTotal():N0}");
    }

    public decimal GetTotal()
    {
        return _cartItems.Sum(item => item.Price);
    }

    public void FinalizePurchase()
    {
        if (_cartItems.Count == 0)
        {
            Console.WriteLine("No puede finalizar una compra con el carrito vacío.");
            return;
        }

        Console.WriteLine($"Compra finalizada por ${GetTotal():N0}.");
        _cartItems.Clear();
    }
}
