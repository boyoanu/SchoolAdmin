using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAdmin.Ado.Net.DTO;

namespace SchoolAdmin.Ado.Net
{
   public class SqlDataService
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader rdr;

        public SqlDataService() 
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolAdmindb;Integrated Security=True;Pooling=False");
        }

         public void Insert(string tableName, object dataToInsert)
        {
            string commandStr; 

            switch (tableName)
            {
                case "teachers":
                    TeacherDTO teacher = (TeacherDTO)dataToInsert;
                    commandStr = $"INSERT INTO Teachers(FirstName, MiddleName, LastName, Subject) " +
                        $"VALUES('{teacher.FirstName}', '{teacher.MiddleName}', '{teacher.LastName}', '{teacher.Subject}')";
                    break;
                case "students":
                    StudentDTO student = (StudentDTO)dataToInsert;
                    commandStr = $"INSERT INTO Students(FirstName, MiddleName, LastName, Level) " +
                        $"VALUES('{student.FirstName}', '{student.MiddleName}', '{student.LastName}', '{student.Level}')";
                    break;
                default:
                    Console.WriteLine("Invalid table name! Only 'teachers' and 'students' are allowed.");
                    return;
            }

            cmd = new SqlCommand(commandStr, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Successfully inserted {rowsAffected} records into the '{tableName}' table.");
        }
    }
}
