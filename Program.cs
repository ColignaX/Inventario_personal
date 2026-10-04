using System;
using InventarioPersonal.Services;

namespace InventarioPersonal
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new InventarioService();
            bool salir = false;

            Console.WriteLine("====================================================");
            Console.WriteLine(" 📦 SISTEMA DE INVENTARIO PERSONAL (EF CORE & SQLITE)");
            Console.WriteLine("====================================================\n");

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ DE OPCIONES ---");
                Console.WriteLine("1. 📋 Listar todos los productos");
                Console.WriteLine("2. ➕ Agregar un nuevo producto");
                Console.WriteLine("3. 🗑️  BORRAR un producto por ID");
                Console.WriteLine("4. 🗑️  BORRAR producto por Nombre");
                Console.WriteLine("5. ✏️  Actualizar cantidad de un producto");
                Console.WriteLine("6. 🚪 Salir");
                Console.Write("\nSeleccione una opción (1-6): ");

                string? opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        ListarProductos(service);
                        break;
                    case "2":
                        AgregarProducto(service);
                        break;
                    case "3":
                        BorrarProductoPorId(service);
                        break;
                    case "4":
                        BorrarProductoPorNombre(service);
                        break;
                    case "5":
                        ActualizarCantidad(service);
                        break;
                    case "6":
                        salir = true;
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void ListarProductos(InventarioService service)
        {
            var items = service.ObtenerTodos();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-4} | {1,-18} | {2,-22} | {3,-10} | {4,-10}", "ID", "Categoría", "Item", "Cantidad", "Unidad"));
            Console.WriteLine("----------------------------------------------------------------------------------");

            foreach (var item in items)
            {
                Console.WriteLine(string.Format("{0,-4} | {1,-18} | {2,-22} | {3,-10} | {4,-10}", item.Id, item.Categoria, item.Item, item.Cantidad, item.Unidad));
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        static void AgregarProducto(InventarioService service)
        {
            Console.Write("Categoría (ej: Insumo de cocina / Almacen): ");
            string categoria = Console.ReadLine() ?? "General";

            Console.Write("Nombre del Item: ");
            string item = Console.ReadLine() ?? "";

            Console.Write("Cantidad: ");
            double.TryParse(Console.ReadLine(), out double cantidad);

            Console.Write("Unidad de medida (ej: unidades, libras, cajas): ");
            string unidad = Console.ReadLine() ?? "unidades";

            if (string.IsNullOrWhiteSpace(item))
            {
                Console.WriteLine("⚠️ El nombre del item no puede estar vacío.");
                return;
            }

            service.AgregarProducto(categoria, item, cantidad, unidad);
        }

        static void BorrarProductoPorId(InventarioService service)
        {
            Console.Write("Ingrese el ID del producto que desea BORRAR: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                service.BorrarProductoPorId(id);
            }
            else
            {
                Console.WriteLine("⚠️ ID inválido. Debe ingresar un número.");
            }
        }

        static void BorrarProductoPorNombre(InventarioService service)
        {
            Console.Write("Ingrese el nombre (o parte del nombre) del producto a BORRAR: ");
            string nombre = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                service.BorrarProductoPorNombre(nombre);
            }
            else
            {
                Console.WriteLine("⚠️ Nombre inválido.");
            }
        }

        static void ActualizarCantidad(InventarioService service)
        {
            Console.Write("Ingrese el ID del producto a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Ingrese la nueva cantidad: ");
                if (double.TryParse(Console.ReadLine(), out double cantidad))
                {
                    service.ActualizarCantidad(id, cantidad);
                }
                else
                {
                    Console.WriteLine("⚠️ Cantidad inválida.");
                }
            }
            else
            {
                Console.WriteLine("⚠️ ID inválido.");
            }
        }
    }
}
