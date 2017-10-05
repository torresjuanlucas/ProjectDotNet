using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        string FullName;
        string Department;
        DateTime BirthDate;
        bool Gender;
        string Address;
        string PostalCode;
        string Phone;
        DateTime HireDate;
        string JobTitle;
        string City;

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            FullName = tbFullName.Text;

            //verify full name
            if (FullName.Length < 2 || FullName.Length > 50)
            {
                MessageBox.Show("Name must be between 2 and 50  characters long", "Error Input");
                return;
            }
            if (FullName.IndexOf(';') != -1)
            {
                MessageBox.Show("Name Can't contains ';'", "Error Input");
                return;
            }




        }





        ///<<<<<<<LoadPhoto>>>>>>>>>>></Load>
        ///
        private void btnLoadPhoto_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

    }
   
}
