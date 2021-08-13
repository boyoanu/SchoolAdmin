using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SchoolAdmin.Ado.Net.SqlDataService
{
   public class TeacherDataAdapterService
    {
        SqlConnection connection;
        SqlCommand selectCmd;
        SqlCommand updateCmd;
        SqlCommand insertCmd;
        SqlCommand deleteCmd;
        SqlDataAdapter adapter;
        
        public DataSet TeacherDataSet;

        public TeacherDataAdapterService() 
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-P4C2M1N\SQLEXPRESS;Initial Catalog=SchoolAdminDB;Integrated Security=True;Pooling=False");
        }
        public void PopulateDataSet()
        {
            // Configure commands for SqlAdapter's SELECT Operation

            selectCmd = new SqlCommand("SELECT * FROM Teachers", connection);

            // Create SqlAdapter object
            adapter = new SqlDataAdapter(selectCmd);

            //Create Dataset object
            TeacherDataSet = new DataSet();

            // Fill up DataSet using the SqlAdapter
            connection.Open();
            adapter.Fill(TeacherDataSet);
            connection.Close();


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