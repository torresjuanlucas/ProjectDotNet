using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class Payment
    {

        private int id;
        private double hourlyRate;
        private double hours;
        private double netPay;
   



        public int paymentId { get; set; }
        

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public double HourlyRate
        {
            get
            {
                return hourlyRate;
            }
            set
            {

               hourlyRate = value;

            }
        }

    
        public double Hours
        {
            get
            {
                return hours;
            }
            set
            {
                
                    hours = value;
                
            }
        }


        public double NetPay
        {
            get
            {
                return netPay;
            }
            set
            {

                netPay = value;

            }
        }

       
    }
}
