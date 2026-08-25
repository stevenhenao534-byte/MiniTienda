using MiniTiendaLicores.Models;

namespace MiniTiendaLicores.Services;

public class ProductsService
{
    private readonly List<Product> products = new()
    {
        new Product(1, "Macerado de Tamarindo", 65000),
        new Product(2, "Macerado de Fresa-Mora", 65000),
        new Product(3, "Macerado de Maracuyá", 65000),
        new Product(4, "Macerado de Limoncello", 35000)
    };

    public void ShowProducts()
    {
        Console.WriteLine("\n=== Productos ===");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}: {product.Name} - ${product.Price:N0}");
        }
    }

    public Product? GetProductById(int id)
    {
        return products.FirstOrDefault(product => product.Id == id);
    }
}
