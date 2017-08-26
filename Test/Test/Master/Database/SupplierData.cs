using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Master.Database
{
    class SupplierData
    {
        public string Supplierid { get; set; }
        public string SupplierName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebAddr { get; set; }
        public string License { get; set; }
        public string TinNo { get; set; }
        public string Status { get; set; }
        public string OppBal { get; set; }
        public string CreditLimit { get; set; }
        public string PaymentDays { get; set; }
        SqlCommand Cmd;
        SqlConnection Con;
        SqlTransaction Trans;
        public string Result = "";

        public void FnConn()
        {
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
            Con.Open();
            Trans = Con.BeginTransaction();
        }

        public DataTable FillData()
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand("spSupplier", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "S");
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);

                adp.Fill(dtReturnTable);
                return dtReturnTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public DataTable GetRow(String Sup_ID)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand("spSupplier", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "SR");
                Cmd.Parameters.AddWithValue("@SUP_ID", Sup_ID);
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);

                adp.Fill(dtReturnTable);
                return dtReturnTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public void DeleteData(String Value)
        {
            Cmd = new SqlCommand("spSupplier", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "D");
            Cmd.Parameters.AddWithValue("@SUP_ID", Value);
            Cmd.ExecuteNonQuery();
        }

        public void UpdateData(String Value)
        {
            Cmd = new SqlCommand("spSupplier", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "U");
            Cmd.Parameters.AddWithValue("@SUP_ID", Value);
            Cmd.ExecuteNonQuery();
        }

        public void fnTransactionData(String Operation)
        {
            Cmd = new SqlCommand("spSupplier", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", Operation);
            Cmd.Parameters.AddWithValue("@SUP_ID", Supplierid);
            Cmd.Parameters.AddWithValue("@NAME", SupplierName);
            Cmd.Parameters.AddWithValue("@FULL_NAME", FullName);
            Cmd.Parameters.AddWithValue("@ADDRESS", Address);
            Cmd.Parameters.AddWithValue("@PHONE", Phone);
            Cmd.Parameters.AddWithValue("@EMAIL", Email);
            Cmd.Parameters.AddWithValue("@WEB", WebAddr);
            Cmd.Parameters.AddWithValue("@LICENSE", License);
            Cmd.Parameters.AddWithValue("@TIN", TinNo);
            Cmd.Parameters.AddWithValue("@STATUS", Status);
            Cmd.Parameters.AddWithValue("@OPP_BAL", OppBal);
            Cmd.Parameters.AddWithValue("@CREDIT_LIMIT", CreditLimit);
            Cmd.Parameters.AddWithValue("@PAYMENT_DAYS", PaymentDays);
            Cmd.ExecuteNonQuery();
        }

        public String GetMaxValue()
        {
            try
            {
                DataTable dtReturnTable = new DataTable();
                Cmd = new SqlCommand("spSupplier", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "MAX");
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);

                adp.Fill(dtReturnTable);
                return dtReturnTable.Rows[0]["slno"] + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable DistinctColumn(String SPName)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand(SPName, Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "DISTINCT");
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);

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
                Trans.Commit();
                Result = "Success";
                return Result;
            }
            catch (SqlException sqlEx)
            {
                Trans.Rollback();
                Result = "Error" + sqlEx.Message;
                return Result;
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
        }
    }
}
