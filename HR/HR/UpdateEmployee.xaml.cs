using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HR
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        Employee employeeinfo;
        MainWindow parentWindow;
        ProjectDatabase db = new ProjectDatabase();
        public UpdateEmployee(MainWindow parent, Employee toEditEmp)
        {
            parentWindow = parent;
            employeeinfo = toEditEmp;
            InitializeComponent();
            
        }

        //public AddPayment()
        //{
        //    InitializeComponent();
        //}

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {



            tbFullName.Text = employeeinfo.FullName.ToString();
            cmbDepartment.Text = employeeinfo.Department;
            // DatePicker1.Text = employeeinfo.birthdate.ToString();
            tbAddress.Text = employeeinfo.Address;
            tbPostalCode.Text = employeeinfo.PostalCode;
            tbPhone.Text = employeeinfo.Phone;
            tbJobTitleCode.Text = employeeinfo.JobTitle;




            //Employee emp = db.GetAllEmployees<>();
            //emp.FullName = tbFullName.Text;
            //emp.Department = cmbDepartment.Text;
            //emp.BirthDate = DateTime.Parse(DatePicker1.Text);
            //emp.Address = tbAddress.Text;
            //emp.PostalCode = tbPostalCode.Text;
            //emp.JobTitle = tbJobTitleCode.Text;
            //emp.Phone = tbPhone.Text;
            //db.UpdateEmployee(emp);
            //MessageBox.Show("Employee has been Updated succefully!");
            //Close();
            //parentWindow.ReloadEmployeeList();



            //// Employees emp = new Employees();
            //Employee emp = db.GetEmployeeById(id);
            //// data after update
            //emp.EmployeeID = id;
            //emp.FirstName = tbFirstName.Text;
            //emp.LastName = tbLastName.Text;
            //emp.HireDate = DateTime.Parse(tbHireDate.Text);
            //emp.Address = tbAddress.Text;
            //emp.UserName = tbUserName.Text;
            //emp.Password = tbPassword.Text;
            //emp.Phone = tbPhone.Text;

            //db.UpdateEmployee(emp);
            //MessageBox.Show("The Employee has been successfully updated");

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
