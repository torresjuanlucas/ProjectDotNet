using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class ProjectDatabase
    {
        private string connString = @"Data Source = lucastorres.database.windows.net; Initial Catalog = hrproject; Persist Security Info=True;User ID = sqladmin; Password=LucasLucas1";
        

        private SqlConnection conn;

        public ProjectDatabase()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }


        //Employee table 
       
        Employee emp;
        public void AddEmployee(Employee emp)
        {

            string sql = "INSERT INTO Employee (fullName, department, birthDate, address, postalCode, phone, jobTitle) VALUES "
                        + " (@fullName,@department,@birthDate,@address,@postalCode,@phone,@jobTitle)";
            SqlCommand insertCommand = new SqlCommand(sql, conn);
            insertCommand.Parameters.Add(new SqlParameter("@fullName", emp.FullName));
            insertCommand.Parameters.Add(new SqlParameter("@department", emp.Department));
            insertCommand.Parameters.Add(new SqlParameter("@birthDate", emp.BirthDate));
            insertCommand.Parameters.Add(new SqlParameter("@address", emp.Address));
            insertCommand.Parameters.Add(new SqlParameter("@postalCode", emp.PostalCode));
            insertCommand.Parameters.Add(new SqlParameter("@phone", emp.Phone));
            insertCommand.Parameters.Add(new SqlParameter("@jobTitle", emp.JobTitle));            
            insertCommand.ExecuteNonQuery();
        }



        public void DeleteEmployee(int Id)
        {

            //payment id 
            string sqlDeletepay = "DELETE FROM Payment WHERE @Id = Id;";
            string sqlDelete = "DELETE FROM Employee WHERE @Id = Id;";

            SqlCommand deleteCommandpay = new SqlCommand(sqlDeletepay, conn);
            deleteCommandpay.Parameters.AddWithValue("@Id", Id);
            deleteCommandpay.ExecuteNonQuery();

            SqlCommand deleteCommand = new SqlCommand(sqlDelete, conn);
            deleteCommand.Parameters.AddWithValue("@Id", Id);
            deleteCommand.ExecuteNonQuery();
        }



        public void UpdateEmployee(Employee emp)
        {

            string sql = "UPDATE Employee SET fullName=@fullName, department=@department , birthDate=@birthDate , address=@address , Phone=@Phone, postalCode=@postalCode, jobTitle=@jobTitle  WHERE @Id = Id";
            SqlCommand updateCommand = new SqlCommand(sql, conn);
            updateCommand.Parameters.AddWithValue("@fullName", emp.FullName);
            updateCommand.Parameters.AddWithValue("@department", emp.Department);
            updateCommand.Parameters.AddWithValue("@birthDate", emp.BirthDate);
            updateCommand.Parameters.AddWithValue("@address", emp.Address);
            updateCommand.Parameters.AddWithValue("@postalCode", emp.PostalCode);
            updateCommand.Parameters.AddWithValue("@phone", emp.Phone);
            updateCommand.Parameters.AddWithValue("@jobTitle", emp.JobTitle);
            updateCommand.ExecuteNonQuery();
        }



        public Employee GetEmployeeById(int id)
        {

            string sqlDelete = "SELECT * FROM Employee WHERE @ID = ID;";
            SqlCommand Command = new SqlCommand(sqlDelete, conn);
            Command.Parameters.AddWithValue("@Id", id);
            using (var reader = Command.ExecuteReader())
            {
                if (reader.Read())
                {
                    emp = new Employee
                    {
                        FullName = reader["fullName"].ToString(),
                        Department = reader["department"].ToString(),
                        BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                        Address = reader["Address"].ToString(),
                        PostalCode = reader["PostalCode"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        JobTitle = reader["JobTitle"].ToString()
                    };
                }

            }

            return emp;
        }

        public List<Employee> GetAllEmployees()
        {
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Employee ORDER BY Id", conn);
            var listOfEmployees = new List<Employee>();
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    emp = new Employee();
                    emp.Id = Convert.ToInt32(reader["Id"].ToString());
                    emp.FullName = reader["FullName"].ToString();
                    emp.Department = reader["Department"].ToString();
                    emp.BirthDate = (DateTime)reader["BirthDate"];
                    emp.Address = reader["Address"].ToString();
                    emp.PostalCode = reader["PostalCode"].ToString();
                    emp.Phone = reader["Phone"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();

                    listOfEmployees.Add(emp);
                }
            }
            return listOfEmployees;
        }



        //Payment
        public void AddPayment(Payment pay)
        {

            string sql = "INSERT INTO Payment ( id, hourlyRate, hours, netPay) VALUES "
                        + " (@id,@hourlyRate,@hours,@netPay)";
            SqlCommand insertCommand = new SqlCommand(sql, conn);
           
            insertCommand.Parameters.Add(new SqlParameter("@id", pay.Id));
            insertCommand.Parameters.Add(new SqlParameter("@hourlyRate", pay.HourlyRate));
            insertCommand.Parameters.Add(new SqlParameter("@hours", pay.Hours));
            insertCommand.Parameters.Add(new SqlParameter("@netPay", pay.NetPay));
      
            insertCommand.ExecuteNonQuery();
        }



        
    }
}
