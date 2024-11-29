# Proyecto WebForms EVOLTIS

## Requisitos

Antes de comenzar, asegúrate de tener los siguientes programas instalados en tu máquina:

- **.NET Framework 4.7** (viene preinstalado en Windows 10 y versiones posteriores, si no lo tienes, puedes obtenerlo desde [aquí](https://dotnet.microsoft.com/download/dotnet-framework)).
- **Visual Studio 2017** o superior (se recomienda usar Visual Studio con el soporte para desarrollo de aplicaciones WebForms).
- **SQL Server**
  
## Instalación

### 1. **Clona o descarga el proyecto**:
   
   Si aún no lo has hecho, puedes clonar este repositorio usando Git:
   
   git clone https://github.com/ramiquinteros/Employees_Evoltis.git

### 2. **Configurar cadena de conexion a DB**:
     ir a Web.Config y cambiar el Server a local:
    
    <connectionStrings>
      <add name="DataContext" connectionString="Server=DESKTOP-G9R1CP9\SQLEXPRESS;Database=EmployeeDb;Integrated Security=True" providerName="System.Data.SqlClient" />
    </connectionStrings>
   
### 3. **Correr proyecto**:
  ![image](https://github.com/user-attachments/assets/b9853bdd-88bd-49ce-83c6-5dca2a16b712)
