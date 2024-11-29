using System;
using System.Threading.Tasks;
using System.Web.UI;
using Employee.BLL.Services;
using Employee.Entity;

namespace Employee.UI
{
    public partial class EditEmployee : Page
    {
        readonly EmployeeService _employeeService = new EmployeeService();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string employeeId = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(employeeId) && int.TryParse(employeeId, out int id))
                {
                    await LoadEmployeeDetails(id);
                }
                else
                {
                    lblMessage.Text = "ID de empleado no válido.";
                    lblMessage.Visible = true;
                }
            }
        }

        private async Task LoadEmployeeDetails(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee != null)
            {
                txtName.Text = employee.Name;
                txtLastName.Text = employee.LastName;
                txtEmail.Text = employee.Email;
                txtSalary.Text = employee.Salary.ToString("F2");
            }
            else
            {
                lblMessage.Text = "Empleado no encontrado.";
                lblMessage.Visible = true;
            }
        }

        protected async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var employee = new EmployeeEntity
                {
                    Id = int.Parse(Request.QueryString["id"]),
                    Name = txtName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Salary = decimal.TryParse(txtSalary.Text, out var salary) ? salary : 0
                };

                await _employeeService.UpdateEmployee(employee);

                lblMessage.CssClass = "text-success";
                lblMessage.Text = "Empleado actualizado correctamente.";
                lblMessage.Visible = true;

                Response.Redirect("~/EmployeeList.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = $"Error al actualizar el empleado: {ex.Message}";
                lblMessage.Visible = true;
            }
        }
    }
}