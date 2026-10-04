# 📦 Sistema de Inventario Personal (EF Core & SQLite)

Este proyecto es un sistema de gestión de inventario personal desarrollado en **C# / .NET 10** utilizando **Entity Framework Core** y **SQLite**. Es compatible con **DB Browser for SQLite** y está preparado para ser administrado directamente en **Visual Studio Code**.

## 📋 Características

- **Conexión dual:** Funciona simultáneamente con DB Browser for SQLite y Entity Framework Core.
- **Operaciones CRUD:**
  - Listar productos.
  - Agregar nuevos productos.
  - **Eliminar productos por ID**.
  - **Eliminar productos por Nombre**.
  - Actualizar cantidades de inventario.
- **Vistas SQL preconfiguradas:** `vista_insumos_cocina` y `vista_almacen`.

## 📂 Estructura del Proyecto

- `inventario.db`: Base de datos SQLite.
- `Models/InventarioItem.cs`: Modelo EF Core.
- `Data/InventarioDbContext.cs`: DbContext del proyecto.
- `Services/InventarioService.cs`: Lógica de negocio (incluyendo borrado con EF Core).
- `Program.cs`: Interfaz de consola interactiva.
- `.vscode/`: Configuración para VS Code (launch.json y tasks.json).

## 🚀 Ejecución

Para iniciar la aplicación desde la terminal o VS Code:

```bash
dotnet run
```
