using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProjectDatabase db;

        public MainWindow()
        {
            try
            {
                db = new ProjectDatabase();
                InitializeComponent();
                ReloadEmployeeList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
           

            Employee employeeinfo = (Employee)lsvEmployee.SelectedItem;


            UpdateEmployee win2 = new UpdateEmployee();
            win2.ShowDialog();

            win2.tbFullName.Text = employeeinfo.FullName.ToString();
            win2.cmbDepartment.Text = employeeinfo.Department;
           // win2.DatePicker1.Text = employeeinfo.birthdate.ToString();
            win2.tbAddress.Text = employeeinfo.Address;
            win2.tbPostalCode.Text = employeeinfo.PostalCode;
            win2.tbPhone.Text = employeeinfo.Phone;
            win2.tbJobTitleCode.Text = employeeinfo.JobTitle;

            win2.ShowDialog();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee win2 = new AddEmployee();
            win2.ShowDialog();
           // this.Close();
        }

        


       


        private void ReloadEmployeeList()
        {
         List<Employee> list = db.GetAllEmployees();
            lsvEmployee.Items.Clear();
            foreach (Employee E in list)
            {
                lsvEmployee.Items.Add(E);
            }
        }




        private void lsvEmployee_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu cm = this.FindResource("lsvEmployee") as ContextMenu;
            cm.PlacementTarget = sender as ListView;
            cm.IsOpen = true;
        }

       

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> list = new List<Employee>();

            if (lsvEmployee.SelectedIndex < 0 )
            {
                MessageBox.Show("You must add some data First then try to delete one!", "My App", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            list.RemoveAt(lsvEmployee.SelectedIndex);
            lsvEmployee.Items.Refresh();
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            Employee employeeinfo = (Employee) lsvEmployee.SelectedItem;


            AddPayment Paymentinfo = new AddPayment();

            Paymentinfo.tbEmployeeID.Text = employeeinfo.Id.ToString();
            Paymentinfo.tbFullNamePay.Text = employeeinfo.FullName;

            Paymentinfo.ShowDialog();
      
        }

    }
}
      
    

 
