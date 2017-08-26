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
    class discountData
    {
        SqlCommand command;
        SqlConnection connection;
        SqlTransaction transaction;
        DataTable  source1;
        string Result = "";
        public discountData()
        { }
        public discountData(DataTable data)
        {
            this.source1 = data;
        }

        public void FnConn()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public void fnTransactionData()
        {


            command = new SqlCommand("spDiscount", connection, transaction);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@OPERATION", "I");
            command.Parameters.AddWithValue("@table", source1);
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

                command = new SqlCommand("spDiscount", connection, transaction);

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
    }
}
