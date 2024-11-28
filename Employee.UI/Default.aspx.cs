using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Employee.BLL.Services;
using Employee.Entity;

namespace Employee.UI.Pages
{
    public partial class Default : Page
    {
        readonly EmployeeService _employeeService = new EmployeeService();

        protected async void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var employees = await _employeeService.GetAllEmployees();
                gvEmployees.DataSource = employees;
                gvEmployees.DataBind();  
            }
        }

        protected async void Create_Employee(object sender, EventArgs e)
        {

            var newEmployee = new EmployeeEntity()
            {
                Email = txtEmail.Text,
                LastName = txtLastName.Text,
                Name = txtName.Text,
                Salary = Decimal.Parse(txtSalary.Text),
            };

            await _employeeService.CreateEmployee(newEmployee);
            await LoadEmployees();
        }

        protected async void Delete_Employee(object sender, EventArgs e)
        {
            try
            {
                await _employeeService.DeleteEmployee(int.Parse(txtId.Text));
                await LoadEmployees();

                lblErrorMessage.Text = "Se eliminó correctamente el empleado.";
                lblErrorMessage.CssClass = "alert alert-success alert-dismissible fade show alert-top-right"; 
                lblErrorMessage.Visible = true;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccessMessage", "showErrorMessage();", true);
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
                lblErrorMessage.CssClass = "alert alert-danger alert-dismissible fade show alert-top-right"; 
                lblErrorMessage.Visible = true;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowErrorMessage", "showErrorMessage();", true);
            }
        }

        protected async void Search_Employees(object sender, EventArgs e)
        {
            var employees = await _employeeService.SearchEmployeesByName(txtSearch.Text);
            gvEmployees.DataSource = employees;
            gvEmployees.DataBind();
        }

        private async Task LoadEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            gvEmployees.DataSource = employees;
            gvEmployees.DataBind();
        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string employeeId = e.CommandArgument.ToString();

                Response.Redirect($"EditEmployee.aspx?id={employeeId}");
            }
        }
    }
}