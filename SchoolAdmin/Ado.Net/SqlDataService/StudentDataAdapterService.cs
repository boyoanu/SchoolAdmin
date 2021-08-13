using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace SchoolAdmin.Ado.Net.SqlDataService
{
    class StudentDataAdapterService
    {
        SqlConnection connection;
        SqlCommand selectCmd;
        SqlCommand updateCmd;
        SqlCommand insertCmd;
        SqlCommand deleteCmd;
        SqlDataAdapter adapter;

        public DataSet StudentDataSet;

        public StudentDataAdapterService()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-P4C2M1N\SQLEXPRESS;Initial Catalog=SchoolAdminDB;Integrated Security=True;Pooling=False");
        }
        public void PopulateDataSet()
        {
            // Configure commands for SqlAdapter's SELECT Operation

            selectCmd = new SqlCommand("SELECT * FROM Students", connection);

            // Create SqlAdapter object
            adapter = new SqlDataAdapter(selectCmd);

            //Create Dataset object
            StudentDataSet = new DataSet();

            // Fill up DataSet using the SqlAdapter
            connection.Open();
            adapter.Fill(StudentDataSet);
            connection.Close();

        }

        public void ManipulateDataSet()
        {
            // Configure commands for SqlAdapter's UPDATE operation
            {
                #region UPDATE
                // Configure command for SqlAdapter's UPDATE operation
                updateCmd = new SqlCommand("UPDATE Students SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Level=@Level WHERE RegNumber=@RegNumber", connection);
                adapter.UpdateCommand = updateCmd;

                // Add parameters to the update command
                adapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
                adapter.UpdateCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
                adapter.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
                adapter.UpdateCommand.Parameters.Add("@Level", SqlDbType.NVarChar, 50, "Level");
                adapter.UpdateCommand.Parameters.Add("@RegNumber", SqlDbType.Int, 4, "RegNumber");

                // Fetch the record to be updated (the record at index 2, in the first table contained in the data set)
                DataRow okekeRecord = StudentDataSet.Tables[0].Rows[3];

                // Assign a new value to the column to updated
                okekeRecord["MiddleName"] = "Sweet";
                #endregion


                #region INSERT
                // Configure command for SqlAdapter's INSERT operation
                insertCmd = new SqlCommand("INSERT INTO Students (FirstName, MiddleName, LastName, Level) VALUES(@FirstName, @MiddleName, @LastName, @Level)", connection);
                adapter.InsertCommand = insertCmd;

                // Add parameters to the update command
                adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
                adapter.InsertCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
                adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
                adapter.InsertCommand.Parameters.Add("@Level", SqlDbType.NVarChar, 50, "Level");

                // Insert several new rows in the first table of the data set (the Teachers table)
                StudentDataSet.Tables[0].Rows.Add(DBNull.Value, "Adeyemi", DBNull.Value, "Vincent", "SSS2");
                StudentDataSet.Tables[0].Rows.Add(DBNull.Value, "Abimbola", DBNull.Value, "Fisher", "SSS3");
                StudentDataSet.Tables[0].Rows.Add(DBNull.Value, "Temilade", DBNull.Value, "Adelakun", "SSS1");
                #endregion


                #region DELETE
                // Configure command for SqlAdapter's DELETE operation
                deleteCmd = new SqlCommand("DELETE FROM Students WHERE StaffId > 20000", connection);
                adapter.DeleteCommand = deleteCmd;
                #endregion

                // Call the adapter's Update method to persist the changes to the database
                adapter.Update(StudentDataSet);

                // Refresh the contents of the dataset using the Fill method
                adapter.Fill(StudentDataSet);
            }
        }

    }
}

/* ToDos:
 * Create SqlConnection Object
 * Create SqlAdapter Object
 * Configure commands for SqlAdapter's SELECT, INSERT,UPDATE and DELETE
 * Create Dataset object
 * Fill dataset object with data records using the SqlAdapter object
 * Make changes to the Dataset(e.g, new record modify record, remove record)
 * Persist the DataSet changes to the database
 * Verify that the changes in the Dataset were affected in the database
 * */
    

