
# Inventory Management Microservices

Este proyecto implementa una arquitectura basada en microservicios para la gestión de inventario. Está compuesto por dos APIs principales: una para la administración de productos y otra para el registro de transacciones (compras y ventas).

## Requisitos

Antes de ejecutar el proyecto en un entorno local, es necesario contar con los siguientes elementos:

- .NET 8.0 SDK o superior
- Visual Studio 2022 o superior (se recomienda para facilitar la gestión de proyectos)
- SQL Server o SQL Server Express (instancia local)
- Git (para clonar el repositorio)

## Ejecución del backend

### 1. Clonar el repositorio

```bash
git clone https://github.com/tuusuario/InventoryManagementMicroServices.git
```

### 2. Abrir la solución

Desde Visual Studio, abrir el archivo `GestionDeInventariosMicroService.sln`.

### 3. Configurar proyectos de inicio

Ir a las propiedades de la solución y establecer como proyectos de inicio simultáneo:

- `Productos.API`
- `Transacciones.API`

Ambos deben tener la acción "Inicio".

### 4. Configurar base de datos

Verificar las cadenas de conexión en los archivos `appsettings.json` de ambos proyectos. Ajustarlas según sea necesario para que apunten a la instancia local de SQL Server.

### 5. Crear bases de datos con scripts incluidos

En la raíz del proyecto se encuentra un archivo ZIP llamado `ScriptsBDTransactionAPI` que contiene los scripts necesarios para crear las bases de datos `ProductsDataBase` y `TransactionsDataBase`.

> **Importante:** No es necesario ejecutar `Update-Database`. Los scripts SQL ya contienen los comandos `CREATE DATABASE`, `CREATE TABLE` y también `INSERT` para precargar datos de ejemplo.

Solo es necesario ejecutar los scripts SQL manualmente desde SQL Server Management Studio u otra herramienta compatible.

### 6. Ejecutar el proyecto

Presionar `Ctrl + F5` o hacer clic en "Iniciar". Se abrirá Swagger para cada API:

- `https://localhost:7029/swagger` (Productos)
- `https://localhost:7007/swagger` (Transacciones)

Desde Swagger se pueden probar todos los endpoints disponibles de forma interactiva.

---

Este README cubre los pasos necesarios para ejecutar localmente el backend del sistema de gestión de inventario. Para cualquier problema durante la ejecución, revisar la configuración de las cadenas de conexión o las bases de datos creadas correctamente.
