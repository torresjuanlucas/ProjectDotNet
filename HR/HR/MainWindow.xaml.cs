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
            UpdateEmployee win2 = new UpdateEmployee();
            win2.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee win2 = new AddEmployee();
            win2.Show();
            this.Close();
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

        //private void lsvPeople_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    List<Employee> Employees = new List<Employee>();
        //    if (lsvEmployee.SelectedIndex != -1)
        //    {
        //        tbFullName.Text = Employees.ElementAt(lsvEmployee.SelectedIndex).FullName;
        //        tbAge.Text = Employees.ElementAt(lsvEmployee.SelectedIndex).Age.ToString();
        //        sliderHeight.Value = Convert.ToInt64(Employees.ElementAt(lsvEmployee.SelectedIndex).Height);
        //    }
        //    else
        //    {
        //        MessageBox.Show("You must choose an Item. Just Cicking with out choosing does not work!", "My App", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }


        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> Persons = new List<Employee>();

            if (lsvEmployee.SelectedIndex < 0 )
            {
                MessageBox.Show("You must add some data First then try to delete one!", "My App", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Persons.RemoveAt(lsvEmployee.SelectedIndex);
            lsvEmployee.Items.Refresh();
        }

       

       
    
    }
}
      
    

 
