using System;
using System.Collections.Generic;

namespace EntregableIII.DiccionarioProductos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Producto> productos = CrearInventario();
            bool seguirEjecutando = true;

            while (seguirEjecutando)
            {
                MostrarMenu();

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";

                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        BuscarProducto(productos);
                        break;

                    case "2":
                        ActualizarStock(productos);
                        break;

                    case "3":
                        EliminarProducto(productos);
                        break;

                    case "4":
                        MostrarProductosStockBajo(productos);
                        break;

                    case "5":
                        MostrarProductos(productos);
                        break;

                    case "0":
                        seguirEjecutando = false;
                        Console.WriteLine("Cerrando... :)");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (seguirEjecutando)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static Dictionary<int, Producto> CrearInventario()
        {
            Dictionary<int, Producto> productos = new Dictionary<int, Producto>();

            productos.Add(101, new Producto
            {
                Id = 101,
                Nombre = "Laptop",
                Precio = 2500.00m,
                Stock = 8
            });

            productos.Add(102, new Producto
            {
                Id = 102,
                Nombre = "Mouse",
                Precio = 50.00m,
                Stock = 3
            });

            productos.Add(103, new Producto
            {
                Id = 103,
                Nombre = "Teclado",
                Precio = 80.00m,
                Stock = 10
            });

            productos.Add(104, new Producto
            {
                Id = 104,
                Nombre = "Monitor",
                Precio = 900.00m,
                Stock = 2
            });

            productos.Add(105, new Producto
            {
                Id = 105,
                Nombre = "Audífonos",
                Precio = 120.00m,
                Stock = 6
            });

            return productos;
        }

        static void MostrarMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         DICCIONARIO DE PRODUCTOS      ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Buscar producto por ID");
            Console.WriteLine("2. Actualizar stock");
            Console.WriteLine("3. Eliminar producto");
            Console.WriteLine("4. Mostrar productos con stock bajo");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("0. Salir");
            Console.WriteLine("========================================");
        }

        static void BuscarProducto(Dictionary<int, Producto> productos)
        {
            Console.Write("Ingrese el ID del producto: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID ingresado no es válido. :(");
                return;
            }

            if (productos.TryGetValue(id, out Producto? producto))
            {
                Console.WriteLine("Producto encontrado:");
                MostrarInformacionProducto(producto);
            }
            else
            {
                Console.WriteLine("El producto no se encuentra en el inventario. :/");
            }
        }

        static void ActualizarStock(Dictionary<int, Producto> productos)
        {
            Console.Write("Ingrese el ID del producto: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID ingresado no es válido. :(");
                return;
            }

            if (!productos.TryGetValue(id, out Producto? producto))
            {
                Console.WriteLine("El producto no se encuentra en el inventario. :/");
                return;
            }

            Console.Write("Ingrese el nuevo stock: ");

            if (!int.TryParse(Console.ReadLine(), out int nuevoStock) || nuevoStock < 0)
            {
                Console.WriteLine("El stock ingresado no es válido. :(");
                return;
            }

            producto.Stock = nuevoStock;

            Console.WriteLine("Stock actualizado correctamente.");
        }

        static void EliminarProducto(Dictionary<int, Producto> productos)
        {
            Console.Write("Ingrese el ID del producto que desea eliminar: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID ingresado no es válido. :(");
                return;
            }

            if (productos.Remove(id))
            {
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("El producto no se encuentra en el inventario. :/");
            }
        }

        static void MostrarProductosStockBajo(
            Dictionary<int, Producto> productos)
        {
            const int STOCK_MINIMO = 5;
            bool existenProductos = false;

            Console.WriteLine("=======PRODUCTOS CON STOCK BAJO=======");

            foreach (Producto producto in productos.Values)
            {
                if (producto.Stock < STOCK_MINIMO)
                {
                    existenProductos = true;

                    Console.WriteLine(
                        $"ID: {producto.Id} | " +
                        $"Nombre: {producto.Nombre} | " +
                        $"Stock: {producto.Stock}");
                }
            }

            if (!existenProductos)
            {
                Console.WriteLine("No existen productos con stock bajo. :)");
            }
        }

        static void MostrarProductos(
            Dictionary<int, Producto> productos)
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("El inventario está vacío. :/");
                return;
            }

            Console.WriteLine("==========INVENTARIO DE PRODUCTOS==========");

            foreach (Producto producto in productos.Values)
            {
                MostrarInformacionProducto(producto);
                Console.WriteLine("----------------------------------------");
            }
        }

        static void MostrarInformacionProducto(Producto producto)
        {
            Console.WriteLine($"ID: {producto.Id}");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: S/ {producto.Precio:F2}");
            Console.WriteLine($"Stock: {producto.Stock}");
        }
    }

    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}