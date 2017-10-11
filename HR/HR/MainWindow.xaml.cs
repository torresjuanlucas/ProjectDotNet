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




        private void Button_Click(object sender, RoutedEventArgs e)
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
    }
}
      
    

 
