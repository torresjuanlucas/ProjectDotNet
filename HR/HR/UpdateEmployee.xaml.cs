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
        public UpdateEmployee()
        {
            InitializeComponent();
        }

        //private void btnAddNew_Click(object sender, RoutedEventArgs e)
        //{
        //    UpdateEmployee edit = new UpdateEmployee();
        //    edit.SaveEvent += new UpdateEmployee.SaveEventHandler(edit_SaveEvent);  //Add event handler
        //    edit.name = Employee[this.lsvEmployee.SelectedItems[0].Index].Name;
        //    edit.age = Employee[this.lsvEmployee.SelectedItems[0].Index].Age;
        //    edit.ShowDialog(this);
        //}
    }
}
