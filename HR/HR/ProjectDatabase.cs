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

        public void AddEmployee(String fullName, String department, DateTime birthDate, String address, String postalCode, String phone, String jobTitle)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Employee (FullName,Department,BirthDate, Address, PostalCode, Phone, JobTitle) VALUES (@FullName,@Department,@BirthDate,@Address,@PostalCode,@Phone,@JobTitle)", conn);
            insertCommand.Parameters.Add(new SqlParameter("FullName", fullName));
            insertCommand.Parameters.Add(new SqlParameter("Department", department));
            insertCommand.Parameters.Add(new SqlParameter("BirthDate", birthDate));
            insertCommand.Parameters.Add(new SqlParameter("Address", address));
            insertCommand.Parameters.Add(new SqlParameter("PostalCode", postalCode));
            insertCommand.Parameters.Add(new SqlParameter("Phone", phone));
            insertCommand.Parameters.Add(new SqlParameter("JobTitle", jobTitle));
            insertCommand.ExecuteNonQuery();
        }
        public void DeleteEmployee(long id)
        {
            SqlCommand insertCommand = new SqlCommand("DELETE FROM Employee WHERE Id = @id", conn);
            insertCommand.Parameters.Add(new SqlParameter("Id", id));
            insertCommand.ExecuteNonQuery();
        }
        public void UpdateEmployee(long id, String fullName, String department, DateTime birthDate, String address, String postalCode, String phone, String jobTitle)
        {
            SqlCommand insertCommand = new SqlCommand("Update Employee Set FullName=@name, Department=@department ,BirthDate=@birthDate, Address=@address, PostalCode=@postalCode, Phone=@phone, JobTitle=@jobTitle Where Id=@id", conn);
            insertCommand.Parameters.Add(new SqlParameter("Id", id));
            insertCommand.Parameters.Add(new SqlParameter("FullName", fullName));
            insertCommand.Parameters.Add(new SqlParameter("Department", department));
            insertCommand.Parameters.Add(new SqlParameter("BirthDate", birthDate));
            insertCommand.Parameters.Add(new SqlParameter("Address", address));
            insertCommand.Parameters.Add(new SqlParameter("PostalCode", postalCode));
            insertCommand.Parameters.Add(new SqlParameter("Phone", phone));
            insertCommand.Parameters.Add(new SqlParameter("JobTitle", jobTitle));
            insertCommand.ExecuteNonQuery();
        }

    }
}
