using MiniTiendaLicores.Models;
using MiniTiendaLicores.Services;

var productService = new ProductsService();
var cartService = new CartService();
var running = true;

while (running)
{
    Console.WriteLine("\n=== Mini Tienda de Licores ===");
    Console.WriteLine("1. Ver productos");
    Console.WriteLine("2. Agregar producto al carrito");
    Console.WriteLine("3. Ver carrito");
    Console.WriteLine("4. Finalizar compra");
    Console.WriteLine("5. Salir");
    Console.Write("\nSeleccione una opción: ");

    string option = Console.ReadLine() ?? string.Empty;

    switch (option)
    {
        case "1":
            productService.ShowProducts();
            break;

        case "2":
            Console.Write("Ingrese el ID del producto: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                Product? product = productService.GetProductById(productId);
                if (product is not null)
                {
                    cartService.AddToCart(product);
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "3":
            cartService.ShowCart();
            break;

        case "4":
            cartService.ShowCart();
            Console.Write("\n¿Confirmar compra? (S/N): ");
            string confirm = Console.ReadLine() ?? string.Empty;

            if (confirm.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                cartService.FinalizePurchase();
            }
            else
            {
                Console.WriteLine("Compra cancelada.");
            }
            break;

        case "5":
            running = false;
            Console.WriteLine("Saliendo de la aplicación. ¡Hasta luego!");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }
}
