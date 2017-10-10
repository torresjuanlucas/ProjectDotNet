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
            List<Employee> result = new List<Employee>();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM People ORDER BY Id", conn);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int xId = (int)reader["Id"];
                    string xName = (string)reader["Name"];
                    int xAge = (int)reader["Age"];
                    double xHeight = (float)reader["Height"]; // float -> double
                    Employee e = new Employee { Id = xId, Name = xName, Age = xAge, Height = xHeight };
                    result.Add(e);
                }
            }
            return result;
        }

        // NOTE add modified so that it returns ID of the record just created
        public int AddEmployee(Employee e)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO People (Name, Age, Height) VALUES (@Name, @Age, @Height); SELECT SCOPE_IDENTITY();", conn);
            insertCommand.Parameters.Add(new SqlParameter("Name", e.Name));
            insertCommand.Parameters.Add(new SqlParameter("Age", e.Age));
            insertCommand.Parameters.Add(new SqlParameter("Height",e.Height));
            //insertCommand.ExecuteNonQuery();
            int id = (int)insertCommand.ExecuteScalar(); // return ID of the record just created
            return id;
        }

        public void DeleteEmployee(int Id)
        {

        }

        public void UpdateEmployee(Employee e)
        {

        }

    }
}
