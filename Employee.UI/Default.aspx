<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employee.UI.Pages.Default" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee List</title>
    <!-- Bootstrap CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .container {
            margin-top: 50px;
        }
        .modal-header {
            background-color: #007bff;
            color: white;
        }
        .alert-top-right {
            position: fixed;
            top: 10px;
            right: 10px;
            z-index: 10;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="text-primary text-center mb-4">Employee List</h2>
                </div>
                <div class="col-md-12 text-right mb-3">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
                    <!-- Botón para abrir modal -->
                    <button type="button" class="btn btn-success btn-sm" data-bs-toggle="modal" data-bs-target="#CreateEmployee">
                        <i class="fa fa-plus"></i> Crear
                    </button>
                    <!-- Botón para eliminar -->
                    <button type="button" class="btn btn-danger btn-sm" data-bs-toggle="modal" data-bs-target="#DeleteEmployee">
                        <i class="fa fa-plus"></i> Eliminar
                    </button>
                </div>
                <div class="col-md-12">
                    <div class="d-flex gap-1">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Buscar por nombre"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="Search_Employees"/>
                    </div>
                    <!-- Tabla con Bootstrap -->
                    <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped mt-2"
                                  OnRowCommand="GvEmployees_RowCommand" EmptyDataText="No employees found">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Apellido" SortExpression="LastName" />
                            <asp:BoundField DataField="Email" HeaderText="Correo Electronico" SortExpression="Email" />
                            <asp:BoundField DataField="Salary" HeaderText="Salario" SortExpression="Salary" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-sm">
                                        Editar
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
              <asp:Label ID="lblErrorMessage" runat="server" CssClass="alert alert-dismissible fade show alert-top-right" role="alert"></asp:Label>
        </div>

        <!-- Modal Crear Empleado -->
       <div class="modal fade" id="CreateEmployee" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel1">Nuevo Empleado</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                <asp:Panel ID="panelForm" runat="server">
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
                    <asp:TextBox TextMode="Number"  ID="txtSalary" runat="server" CssClass="form-control" placeholder="Ingrese el salario"></asp:TextBox>
                  </div>
                </asp:Panel>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                <asp:Button ID="btnSaveEmployee" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="Create_Employee" />
              </div>
            </div>
          </div>
        </div>

        <!-- Modal Eliminar Empleado -->
        <div class="modal fade" id="DeleteEmployee" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel2">Eliminar Empleado</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                <asp:Panel ID="panel1" runat="server">
                    <label for="txtId" class="form-label">Ingrese el id del empleado</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Ingrese el id"></asp:TextBox>
                </asp:Panel>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                <asp:Button ID="btnDeleteEmployee" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="Delete_Employee"/>
              </div>
            </div>
          </div>
        </div>        

        <!-- Bootstrap JS -->
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
        <script type="text/javascript">
            function showErrorMessage() {
                var lblErrorMessage = document.getElementById('<%= lblErrorMessage.ClientID %>');
                lblErrorMessage.style.display = 'block'; 
                setTimeout(function () {
                    lblErrorMessage.style.display = 'none'; 
                }, 2000);
            }
        </script>
    </form>
</body>
</html>
