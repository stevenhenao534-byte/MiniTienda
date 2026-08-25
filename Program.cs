using MiniTiendaLicores.Services;

var productsService = new ProductsService();

bool running = true;

while (running)
{
    Console.WriteLine("\n=== Mini Tienda de Licores ===");
    Console.WriteLine("1. Ver productos");
    Console.WriteLine("2. Agregar producto al carrito");
    Console.WriteLine("3. Ver carrito");
    Console.WriteLine("4. Finalizar compra");
    Console.WriteLine("5. Salir");

    Console.Write("Seleccione una opción: ");
    string option = Console.ReadLine() ?? string.Empty;

    switch (option)
    {
        case "1":
            productsService.ShowProducts();
            break;

        case "2":
            Console.Write("Ingrese el ID del producto: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = productsService.GetProductById(productId);
                if (product != null)
                {
                    Console.WriteLine($"Producto encontrado: {product.Name} - ${product.Price:N0}");
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
            running = false;
            break;
        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.");
            break;
    }
}
