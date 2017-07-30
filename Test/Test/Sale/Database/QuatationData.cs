using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Sale.Database
{

    class QuatationData
    {
        DataTable source2,source1;
        public QuatationData()
        {
            //this.source = data;
        }
        public  QuatationData(DataTable data,DataTable data1)
        {
            this.source2 = data;
            this.source1 = data1;
        }
        SqlCommand command;
        SqlConnection connection;
        SqlTransaction transaction;
        string Result = "";
        //public static string cnnString = "Data Source=59.96.174.85;Initial Catalog=ERP;Persist Security Info=True;User ID=sa;Password=123456;";

        public void FnConn()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }


        public void fnTransactionData()
        {


            command = new SqlCommand("spQuatation", connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@OPERATION", "I");
            command.Parameters.AddWithValue("@header", source1);
            command.Parameters.AddWithValue("@footer", source2);
          //  command.Parameters.AddWithValue("@number", "123");
            //command.Parameters.AddWithValue("@contactNumber", conactNumber);
            //command.Parameters.AddWithValue("@mailid", mailid);
            //command.Parameters.AddWithValue("@purchaseDate", purchaseDate);
            //command.Parameters.AddWithValue("@itemName", ItemName);
            //command.Parameters.AddWithValue("@serialNumber", SerialNumber);
            //command.Parameters.AddWithValue("@modelName", MOdelName);
            //command.Parameters.AddWithValue("@complaintdetails", complaintDetails);
            //command.Parameters.AddWithValue("@status", status);
            command.ExecuteNonQuery();

        }
        public DataTable FillData(string operation)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                command = new SqlCommand("spQuatation", connection, transaction);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OPERATION", operation);


                SqlDataAdapter adp = new SqlDataAdapter(command);

                adp.Fill(dtReturnTable);
                return dtReturnTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        public string FnTrans()
        {
            try
            {
                transaction.Commit();
                Result = "Success";
                return Result;
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                Result = "Error" + sqlEx.Message;
                return Result;
            }

            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
