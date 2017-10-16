using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    public class Employee
    {
        private int id;//{ get; set; }
        private string fullName; // { get; set; }
        private string department; // { get; set; }
        private DateTime birthDate;//{ get; set; }
        private string address;//{ get; set; }
        private string postalCode;//{ get; set; }
        private string phone;//{ get; set; }
        private string jobTitle;//{ get; set; }


        
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

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                if ((value.Length > 2) && (value.Length < 50))
                {
                    fullName = value;
                }
            }
        }

        public string Department
        {
            get
            {
                return department;
            }
            set
            {

             department = value;
  
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                
             birthDate = value;
   
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if ((value.Length > 2) && (value.Length < 150))
                {
                    address = value;
                }
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                if ((value.Length > 2) && (value.Length < 150))
                {
                    postalCode = value;
                }
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {

                phone = value;

            }
        }

        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
            set
            {
  
            jobTitle = value;
                
            }
        }



        public override string ToString()
        {
            return String.Format("{0}: fullName{1}, dept:{2}, birthdate: {3}, address:{4}, postalCode:{5}, phone:{6}, JobTitle:{7}", Id, FullName, Department, BirthDate, Address, PostalCode, phone, JobTitle);
        }
    }
}
