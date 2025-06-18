# Proveedor Screening API

Este es un servicio API desarrollado en **ASP.NET Core** para realizar la debida diligencia de proveedores. La API permite registrar, editar, eliminar proveedores y realizar un screening en diversas fuentes de riesgo (Offshore Leaks, World Bank, OFAC).

---

## Tecnologías utilizadas

- **ASP.NET Core**: Framework para la creación de la API RESTful.
- **Entity Framework Core**: Para interactuar con la base de datos.
- **SQL Server**: Base de datos utilizada.
- **CORS**: Para permitir el acceso desde aplicaciones frontend externas.
- **JWT (JSON Web Token)**: Para la autenticación con tokens Bearer.

---

## Instalación y Ejecución

### 1. Clonar el repositorio

Para empezar, clona el repositorio en tu máquina local:

```bash
git clone https://github.com/angheloaguirre/ProveedorScreeningAPI.git
```

### 2. Realizar migraciones en SQL Server con .NET
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
