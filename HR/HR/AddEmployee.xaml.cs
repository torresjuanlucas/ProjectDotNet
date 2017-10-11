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
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }



        string FullName;
        string Department;
        DateTime BirthDate;
        string Address;
        string PostalCode;
        string Phone;

        string JobTitle;

        private object datePicker1;


        // ========================Add button====================

        private void btnAddNew_Click(object sender, RoutedEventArgs e)

        {

            //SqlConnection con = new SqlConnection(@"Server=tcp:lucastorres.database.windows.net,1433;Initial Catalog=hrproject;Persist Security Info=False;User ID={lucastorres};Password={LucasLucas1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //con.Open();

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



            //birth date
            //string theDate = DatePicker1.String("yyyy-MM-dd");
            DateTimePicker DatePicker1 = new DateTimePicker();

            MessageBox.Show(DatePicker1.Value.ToString());

            //Gender
            String gender = (rbMale.IsChecked == true ? "Male" : (rbFemale.IsChecked == true ? "Female" : "N/A"));



            //phone
            String phone = tbPhone.Text;


            //Address
            String Address = tbAddress.Text;

            //JobTitleCode
            String JobTitle = tbJobTitleCode.Text;


            //PostalCode
            String PostalCode = tbPostalCode.Text;



            //try
            //{
            //    string sql = "INSERT INTO Employees (FullName, Department, Address, postalCode, phone, gender, jobTitle) VALUES "
            //+ " (@FullName,@Department,@Address,@postalCode,@phone,@gender,@jobTitle)";



            //     SqlCommand cmd = new SqlCommand(sql, conn);
            //     cmd.ExecuteNonQuery();

            //     string str1 = "select max(emp_id) from employee ;";

            //     SqlCommand cmd1 = new SqlCommand(str1, conn);
            //     SqlDataReader dr = cmd1.ExecuteReader();
            //     if (dr.Read())
            //     {
            //         MessageBox.Show("" + tbFullName.Text + "'s Details is Inserted Successfully.. " + cmbDepartment.Text + "'s Id is " + dr.GetInt32(0) + ".", "Important Message");
            //         this.Hide();

            //     }
            //     this.Close();
            // }
            // catch (SqlException excep)
            // {
            //     MessageBox.Show(excep.Message);
            // }
            //// conn.Close();
            //}


            //    =========================Edit(modify) button=============================


            //    private void btnEdit_Click(object sender, RoutedEventArgs e)
            //{
            //    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\users\n\documents\visual studio 2010\Projects\EmployeeInformationSystem\EmployeeInformationSystem\Company.mdf;Integrated Security=True;User Instance=True");
            //    con.Open();
            //    try
            //    {
            //        string str = " Update employee set name='" + tbFullName.Text + "',phone='" + tbPhone.Text + "',jobTitle='" + tbJobTitleCode.Text + "',address='" + tbAddress.Text + "',='" + BirthDate.Date + "',department='" + cmbDepartment.Text + "'";

            //        SqlCommand cmd = new SqlCommand(str, conn);
            //        cmd.ExecuteNonQuery();

            //        string str1 = "select max(emp_id) from employee ;";

            //        SqlCommand cmd1 = new SqlCommand(str1, conn);
            //        SqlDataReader dr = cmd1.ExecuteReader();
            //        if (dr.Read())
            //        {
            //            MessageBox.Show("" + tbFullName.Text + "'s Details is Updated Successfully.. ", "Important Message");
            //            this.Hide();

            //        }
            //        this.Close();
            //    }
            //    catch (SqlException excep)
            //    {
            //        MessageBox.Show(excep.Message);
            //    }
            //    con.Close();

            //}



            //// =========================== Clear the Form button=============================

            //private void btnClear_Click(object sender, RoutedEventArgs e)
            //{

            //    cmbDepartment.SelectedIndex = -1;
            //    rbFemale.IsChecked = false;
            //    rbMale.IsChecked = false;
            //    rbNA.IsChecked = false;
            //    tbFullName.Text = "";
            //    tbPhone.Text = "";
            //    cmbDepartment.Text = "";
            //    tbAddress.Text = "";
            //    tbPostalCode.Text = "";
            //    tbJobTitleCode.Text = "";

            //}

        }
        }
        }

