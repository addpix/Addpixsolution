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
    class SalesDeliveryData
    {
        DataTable source2, source1;
        public SalesDeliveryData()
        {
            //this.source = data;
        }
        public  SalesDeliveryData(DataTable data, DataTable data1)
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

            try
            {
                command = new SqlCommand("spsalesDelivery", connection, transaction);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OPERATION", "I");
                command.Parameters.AddWithValue("@header", source1);
                command.Parameters.AddWithValue("@footer", source2);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable FillData(string operation, string param1, string procedureName)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                command = new SqlCommand(procedureName, connection, transaction);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OPERATION", operation);
                if (param1 != "")
                {
                    command.Parameters.AddWithValue("@param1", param1);
                }
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
        public DataSet FillDataSet(string operation, string param1, string procedureName)
        {
            try
            {
                DataSet dtReturnTable = new DataSet();

                command = new SqlCommand(procedureName, connection, transaction);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OPERATION", operation);
                if (param1 != "")
                {
                    command.Parameters.AddWithValue("@param1", param1);
                }
                SqlDataAdapter adp = new SqlDataAdapter(command);

                adp.Fill(dtReturnTable);
                return dtReturnTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataSet();
            }
        }
    }

}
