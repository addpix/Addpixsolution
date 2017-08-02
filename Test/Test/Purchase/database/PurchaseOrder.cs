using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Test.Purchase.database
{
    class PurchaseOrder
    {
        SqlCommand command;
        SqlConnection connection;
        SqlTransaction transaction;
        DataTable source2, source1;
        string Result = "";
        public PurchaseOrder()
        { }
        public  PurchaseOrder(DataTable data, DataTable data1)
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

        public void fnTransactionData()
        {


            command = new SqlCommand("PO_Insert", connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@OPERATION", "I");
            command.Parameters.AddWithValue("@datas", source1);
            command.Parameters.AddWithValue("@grd", source2);
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
    }
}
