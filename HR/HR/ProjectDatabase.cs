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
        private string connString = @"Server=tcp:lucastorres.database.windows.net,1433;Initial Catalog=hrproject;Persist Security Info=False;User ID={lucastorres};Password={LucasLucas1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection conn;

        public ProjectDatabase()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Employee ORDER BY Id", conn);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = (long)reader[0];
                    emp.FullName = (String)reader[1];
                    emp.Department = (String)reader[2];
                    emp.BirthDate = (DateTime)reader[3];
                    emp.Address = (String)reader[4];
                    emp.PostalCode = (String)reader[5];
                    emp.Phone = (String)reader[6];
                    emp.JobTitle = (String)reader[7];


                    list.Add(emp);
                }
            }
            return list;
        }

        public void AddEmployee(String name, int age, double height)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Employee (Name,Age,Height) VALUES (@Name,@Age,@Height)", conn);
            insertCommand.Parameters.Add(new SqlParameter("Name", name));
            insertCommand.Parameters.Add(new SqlParameter("Age", age));
            insertCommand.Parameters.Add(new SqlParameter("Height", height));
            insertCommand.ExecuteNonQuery();
        }
        public void DeleteEmployee(long id)
        {
            SqlCommand insertCommand = new SqlCommand("DELETE FROM Employee WHERE Id = @id", conn);
            insertCommand.Parameters.Add(new SqlParameter("id", id));
            insertCommand.ExecuteNonQuery();
        }
        public void UpdateEmployee(String name, int age, double height, long id)
        {
            SqlCommand insertCommand = new SqlCommand("Update Employee Set Name=@name, Age=@age ,Height=@height Where id=@id", conn);
            insertCommand.Parameters.Add(new SqlParameter("Name", name));
            insertCommand.Parameters.Add(new SqlParameter("Age", age));
            insertCommand.Parameters.Add(new SqlParameter("Height", height));
            insertCommand.Parameters.Add(new SqlParameter("Id", id));
            insertCommand.ExecuteNonQuery();
        }

    }
}
