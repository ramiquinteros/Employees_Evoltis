<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="Employee.UI.EditEmployee" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Empleado</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-primary text-center mb-4">Editar Empleado</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            <div class="mb-3">
                <label for="txtName" class="form-label">Nombre</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtLastName" class="form-label">Apellido</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Ingrese el apellido"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Correo Electrónico</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Ingrese el correo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtSalary" class="form-label">Salario</label>
                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Ingrese el salario"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-between">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="BtnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancelar" PostBackUrl="~/Default.aspx" />
            </div>
        </div>
    </form>
</body>
</html>
