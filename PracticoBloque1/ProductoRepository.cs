using System.Collections.Generic;
using System.Linq;

public class ProductoRepository : IProductoRepository
{
    private readonly List<Producto> _productos;

    public ProductoRepository()
    {
        // Seed data: inicializamos con 4 productos de prueba
        _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Notebook Lenovo", Precio = 750000.00m, Categoria = "Tecnología", Activo = true },
            new Producto { Id = 2, Nombre = "Mouse Inalámbrico", Precio = 15000.50m, Categoria = "Tecnología", Activo = true },
            new Producto { Id = 3, Nombre = "Cafetera Exprés", Precio = 120000.00m, Categoria = "Hogar", Activo = true },
            new Producto { Id = 4, Nombre = "Silla Ergónomica", Precio = 95000.00m, Categoria = "Oficina", Activo = true }
        };
    }

    public void Agregar(Producto producto)
    {
        _productos.Add(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }

    public Producto ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public List<Producto> BuscarPorCategoria(string categoria)
    {
        return _productos
            .Where(p => p.Categoria.Equals(categoria, System.StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}