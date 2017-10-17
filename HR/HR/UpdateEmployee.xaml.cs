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

      

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {



            tbFullName.Text = employeeinfo.FullName.ToString();
            cmbDepartment.Text = employeeinfo.Department;
            // DatePicker1.Text = employeeinfo.birthdate.ToString();
            tbAddress.Text = employeeinfo.Address;
            tbPostalCode.Text = employeeinfo.PostalCode;
            tbPhone.Text = employeeinfo.Phone;
            tbJobTitleCode.Text = employeeinfo.JobTitle;
            

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
