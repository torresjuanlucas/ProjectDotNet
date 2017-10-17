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
    
    public partial class AddPayment : Window
    {
        ProjectDatabase db;

        public AddPayment()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double hourlyRate;
            if (!double.TryParse(tbHourlyRatePay.Text, out hourlyRate))
            {
                MessageBox.Show("Please, enter the hourly rate");
                return;
            }
            double hours;
            if (!double.TryParse(tbNoOfHoursPay.Text, out hours))
            {
                MessageBox.Show("Please, enter the amount of hours worked");
                return;
            }

            hourlyRate = Convert.ToDouble(tbHourlyRatePay.Text);
            hours = Convert.ToDouble(tbNoOfHoursPay.Text);

            double Gross = (hourlyRate * hours);
            double FedTax = (Gross * 0.075);
            double ProvTax = Gross * 0.075;
            double NetPay = Gross - (FedTax + ProvTax);

            tbTotalGrossPay.Text = Gross.ToString();
            tbTotalNetPay.Text = NetPay.ToString();
            tbFederalTaxPay.Text = FedTax.ToString();
            tbProvincialTaxPay.Text = ProvTax.ToString();



        }

        private void btnSavePayment_Click(object sender, RoutedEventArgs e)
        {

            //collect info from the text boxes:            

            int id = Convert.ToInt32(tbEmployeeID.Text);

            double hourlyRate;
            if (!double.TryParse(tbHourlyRatePay.Text, out hourlyRate))
            {
                MessageBox.Show("Please, enter the hourly rate");
                return;
            }
            double hours;
            if (!double.TryParse(tbNoOfHoursPay.Text, out hours))
            {
                MessageBox.Show("Please, enter the amount of hours worked");
                return;
            }

            hourlyRate = Convert.ToDouble(tbHourlyRatePay.Text);            
            hours = Convert.ToDouble(tbNoOfHoursPay.Text);

            double net = Convert.ToDouble(tbTotalNetPay.Text);

            
            Payment payment = new Payment();
            payment.Id = id;
            payment.HourlyRate = hourlyRate;
            payment.NetPay = net;
            payment.Hours = hours;

            try
            {
                db = new ProjectDatabase();
                db.AddPayment(payment);
                MessageBox.Show("The Payment record was successfully saved.");
                this.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Check the Database Connection Please.");
                MessageBox.Show(ex.ToString());
            }
            

            
        }
    }
}
