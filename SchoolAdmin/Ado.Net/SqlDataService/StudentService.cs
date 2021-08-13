using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using SchoolAdmin.Ado.Net.DTO;


namespace SchoolAdmin.Ado.Net.SqlDataService
{
    class StudentService
    {
        
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader rdr;

        public StudentService()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-P4C2M1N\SQLEXPRESS;Initial Catalog=SchoolAdminDB;Integrated Security=True;Pooling=False");
        }

        public void Insert(StudentDTO dataToInsert)
        {
            string commandStr = $"INSERT INTO Students(FirstName, MiddleName, LastName, Level) " +
                $"VALUES('{dataToInsert.FirstName}', '{dataToInsert.MiddleName}', '{dataToInsert.LastName}', '{dataToInsert.Level}')";
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Successfully inserted {rowsAffected} records into the 'Students' table.");
        }


        public List<StudentDTO> FetchAll()
        {
            List<StudentDTO> result = new List<StudentDTO>();
            string commandStr = "SELECT * FROM Students";
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new StudentDTO
                {
                    RegNumber = (int)rdr["RegNumber"],
                    FirstName = (string)rdr["FirstName"],
                    MiddleName = rdr["MiddleName"] == DBNull.Value ? string.Empty : (string)rdr["MiddleName"],
                    LastName = (string)rdr["LastName"],
                    Level = (string)rdr["Level"]
                }); ;
            }
            conn.Close();
            return result;
        }


        public List<StudentDTO> FetchWithFilter(KeyValuePair<string, object> filterPair, string comparer)
        {
            List<StudentDTO> result = new List<StudentDTO>();

            // SQL query without parameters
            string commandStr = "SELECT * FROM Students WHERE " + $"{filterPair.Key} {comparer} '{filterPair.Value}'";
            //string commandStr3 = "SELECT * FROM Students WHERE RegNumber = 'Physics' OR Subject = 'Chemistry' OR Subject = 'Biology'";

            // SQL query with parameters
            // string commandStr2 = "SELECT * FROM Teachers WHERE " + $"{filterPair.Key} {comparer} @param";
            //string commandStr4 = "SELECT * FROM Teachers WHERE Subject = @p1 OR Subject = @p2 OR Subject = @p3";

            cmd = new SqlCommand(commandStr, conn);
            // Specify parameters here, if any
            //cmd.Parameters.AddWithValue("param", filterPair.Value);
            //cmd.Parameters.AddWithValue("p1", "Physics");
            //cmd.Parameters.AddWithValue("p2", "Chemistry");
            //cmd.Parameters.AddWithValue("p3", "Biology");

            conn.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(new StudentDTO
                {
                    RegNumber = (int)rdr["RegNumber"],
                    FirstName = (string)rdr["FirstName"],
                    MiddleName = rdr["MiddleName"] == DBNull.Value ? string.Empty : (string)rdr["MiddleName"],
                    LastName = (string)rdr["LastName"],
                    Level = (string)rdr["Level"]
                }); ;
            }
            conn.Close();
            return result;
        }


        public void Update(KeyValuePair<string, object> filterPair, string comparer, StudentDTO newData)
        {
            string filterStr = " WHERE " + $"{filterPair.Key} {comparer} '{filterPair.Value}'";

            string updateStr = newData.FirstName == null ? "" : $" FirstName = '{newData.FirstName}',";
            updateStr += newData.MiddleName == null ? "" : $" MiddleName = '{newData.MiddleName}',";
            updateStr += newData.LastName == null ? "" : $" LastName = '{newData.LastName}',";
            updateStr += newData.Level == null ? "" : $" Level = '{newData.Level}',";

            string commandStr = $"UPDATE Students SET " + updateStr.TrimEnd(',') + filterStr;
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Successfully updated {rowsAffected} records in the 'Students' table.");
        }


        public void Delete(KeyValuePair<string, object> filterPair, string comparer)
        {
            string commandStr = $"DELETE FROM Students WHERE {filterPair.Key} {comparer} '{filterPair.Value}'";
            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Successfully deleted {rowsAffected} records from the 'Students' table.");
        }
    }
}

    

