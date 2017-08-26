using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Purchase.database
{

    class PurchaseRequest
    {
        SqlCommand command;
        SqlConnection connection;
        SqlTransaction transaction;
        DataTable source2, source1;
        string Result = "";
       public PurchaseRequest()
        { }
        public PurchaseRequest(DataTable data, DataTable data1)
        {
            this.source2 = data;
            this.source1 = data1;
        }
        public void FnConn()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }
        public void fnTransactionData(String op,String coloumn)
        {


            command = new SqlCommand("spPurchaseRequest", connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@OPERATION",op);
            command.Parameters.AddWithValue("@datas", source1);
            command.Parameters.AddWithValue("@grd", source2);
            command.Parameters.AddWithValue("@coloumn", coloumn);
            command.ExecuteNonQuery();

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

        public DataTable FillData(string operation, string param1)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                command = new SqlCommand("spPurchaseRequest", connection, transaction);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OPERATION", operation);
                command.Parameters.AddWithValue("@coloumn", param1);
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

        public void updatStatus(string operation, string param1, string param2)
        {

            try
            {
                command = new SqlCommand("spPurchaseRequest", connection, transaction);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OPERATION", operation);
                command.Parameters.AddWithValue("@coloumn", param1);
                command.Parameters.AddWithValue("@value", param2);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
           

        }

    }
}
