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



        //update button 
        private void Update_Click(object sender, RoutedEventArgs e)
        {

            Employee employeeinfo = (Employee)lsvEmployee.SelectedItem;


            UpdateEmployee updateWindow = new UpdateEmployee(this,employeeinfo);
            updateWindow.ShowDialog();


        }






        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee win2 = new AddEmployee(this);
            win2.ShowDialog();
           // this.Close();
        }

        


       


        public void ReloadEmployeeList()
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

        private void del_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "SMS DB", MessageBoxButton.YesNo);

            Employee item = (Employee)lsvEmployee.SelectedItem;
            int ID = item.Id;
           
            if (ID <= 0)
            {

                MessageBox.Show("You must select Employee.");
            }
            else
            {
                
                    db.DeleteEmployee(ID);
                    MessageBox.Show("Deleted successful.");
                    ReloadEmployeeList();
                
            }
        }
    }
}
      
    

 
