using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
  
    public partial class AddEmployee : Window
    {
        ProjectDatabase db = new ProjectDatabase();

        MainWindow parentWindow;

        public AddEmployee(MainWindow parent)
        {
            parentWindow = parent;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Employee emp = new Employee();
            emp.FullName = tbFullName.Text;
            emp.Department = cmbDepartment.Text;
            emp.BirthDate = DateTime.Parse(DatePicker1.Text);
            emp.Address = tbAddress.Text;
            emp.PostalCode = tbPostalCode.Text;
            emp.JobTitle = tbJobTitleCode.Text;
            emp.Phone = tbPhone.Text;
            db.AddEmployee(emp);
            MessageBox.Show("Employee has been added succefully!");
            Close();
            parentWindow.ReloadEmployeeList();
            

        }




        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();          

        }
    }
    }
       
    
       

