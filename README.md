# Proyecto WebForms con .NET Framework 4.7

Este proyecto utiliza WebForms con .NET Framework 4.7 para construir aplicaciones web dinámicas. WebForms permite desarrollar aplicaciones basadas en formularios y es ampliamente usado en aplicaciones heredadas de .NET.

## Requisitos

Antes de comenzar, asegúrate de tener los siguientes programas instalados en tu máquina:

- **.NET Framework 4.7** (viene preinstalado en Windows 10 y versiones posteriores, si no lo tienes, puedes obtenerlo desde [aquí](https://dotnet.microsoft.com/download/dotnet-framework)).
- **Visual Studio 2017** o superior (se recomienda usar Visual Studio con el soporte para desarrollo de aplicaciones WebForms).
  
## Instalación

1. **Clona o descarga el proyecto**:
   
   Si aún no lo has hecho, puedes clonar este repositorio usando Git:
   
   ```bash
   git clone https://github.com/tu_usuario/tu_repositorio.git

1. **Configurar Cadena de conexion a DB**:
     - ir a Web.Config y cambiar el Server a local:
    ```bash
    <connectionStrings>
      <add name="DataContext" connectionString="Server=DESKTOP-G9R1CP9\SQLEXPRESS;Database=EmployeeDb;Integrated Security=True" providerName="System.Data.SqlClient" />
    </connectionStrings>   
