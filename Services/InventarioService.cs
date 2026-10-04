using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InventarioPersonal.Data;
using InventarioPersonal.Models;

namespace InventarioPersonal.Services
{
    public class InventarioService
    {
        // 1. Método para listar todos los productos
        public List<InventarioItem> ObtenerTodos()
        {
            using var db = new InventarioDbContext();
            return db.Inventario.OrderBy(i => i.Id).ToList();
        }

        // 2. Método para agregar un nuevo producto
        public void AgregarProducto(string categoria, string item, double cantidad, string unidad)
        {
            using var db = new InventarioDbContext();
            var nuevoItem = new InventarioItem
            {
                Categoria = categoria,
                Item = item,
                Cantidad = cantidad,
                Unidad = unidad,
                FechaRegistro = DateTime.Now
            };

            db.Inventario.Add(nuevoItem);
            db.SaveChanges();
            Console.WriteLine($"✅ Producto '{item}' agregado con éxito (ID: {nuevoItem.Id}).");
        }

        // 3. Método para BORRAR producto por ID (Solicitado por el usuario)
        public bool BorrarProductoPorId(int id)
        {
            using var db = new InventarioDbContext();
            var item = db.Inventario.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                Console.WriteLine($"❌ No se encontró ningún producto con ID {id}.");
                return false;
            }

            db.Inventario.Remove(item);
            db.SaveChanges();
            Console.WriteLine($"🗑️ Producto '{item.Item}' (ID: {id}) eliminado correctamente.");
            return true;
        }

        // 4. Método para BORRAR producto por Nombre
        public int BorrarProductoPorNombre(string nombre)
        {
            using var db = new InventarioDbContext();
            var coincidencias = db.Inventario
                .Where(i => EF.Functions.Like(i.Item, $"%{nombre}%"))
                .ToList();

            if (!coincidencias.Any())
            {
                Console.WriteLine($"❌ No se encontraron productos con el nombre o coincidencia '{nombre}'.");
                return 0;
            }

            db.Inventario.RemoveRange(coincidencias);
            int eliminados = db.SaveChanges();
            Console.WriteLine($"🗑️ Se eliminaron {eliminados} producto(s) coincidentes con '{nombre}'.");
            return eliminados;
        }

        // 5. Método para actualizar la cantidad de un producto
        public bool ActualizarCantidad(int id, double nuevaCantidad)
        {
            using var db = new InventarioDbContext();
            var item = db.Inventario.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                Console.WriteLine($"❌ No se encontró ningún producto con ID {id}.");
                return false;
            }

            item.Cantidad = nuevaCantidad;
            db.SaveChanges();
            Console.WriteLine($"🔄 Cantidad del producto '{item.Item}' actualizada a {nuevaCantidad} {item.Unidad}.");
            return true;
        }
    }
}
