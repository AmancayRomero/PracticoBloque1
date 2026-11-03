using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IProductoRepository repo = new ProductoRepository();

        Console.WriteLine("=== 1. LISTA COMPLETA DE PRODUCTOS (SEED DATA) ===");
        MostrarProductos(repo.ObtenerTodos());

        Console.WriteLine("\n=== 2. BÚSQUEDA DE UN PRODUCTO POR ID (ID: 2) ===");
        var productoBuscado = repo.ObtenerPorId(2);
        if (productoBuscado != null)
        {
            Console.WriteLine($"Encontrado: ID: {productoBuscado.Id} | {productoBuscado.Nombre} | ${productoBuscado.Precio} | Cat: {productoBuscado.Categoria}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }

        Console.WriteLine("\n=== 3. FILTRADO DE PRODUCTOS POR CATEGORÍA ('Tecnología') ===");
        var productosTecnologia = repo.BuscarPorCategoria("Tecnología");
        MostrarProductos(productosTecnologia);

        Console.WriteLine("\n=== 4. INCORPORACIÓN DE UN NUEVO PRODUCTO ===");
        var nuevoProducto = new Producto
        {
            Id = 5,
            Nombre = "Monitor 24 pulgadas",
            Precio = 180000.00m,
            Categoria = "Tecnología",
            Activo = true
        };

        repo.Agregar(nuevoProducto);
        Console.WriteLine($"¡Producto '{nuevoProducto.Nombre}' agregado con éxito!\n");

        Console.WriteLine("=== LISTA COMPLETA ACTUALIZADA ===");
        MostrarProductos(repo.ObtenerTodos());

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    private static void MostrarProductos(List<Producto> productos)
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("No hay productos para mostrar.");
            return;
        }

        foreach (var p in productos)
        {
            Console.WriteLine($"[ID: {p.Id}] {p.Nombre} - ${p.Precio:N2} | Categoría: {p.Categoria} | Activo: {p.Activo}");
        }
    }
}