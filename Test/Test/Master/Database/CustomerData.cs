﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Test.Master.Database
{
    class CustomerData
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebAddr { get; set; }
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

        public DataTable FillData(string operation,string param1)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand("spCustomer", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", operation);
                if (param1 != "")
                {
                    Cmd.Parameters.AddWithValue("@param1", param1);
                }
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
        public void fnTransactionData()
        {
            Cmd = new SqlCommand("spCustomer", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "I");
            Cmd.Parameters.AddWithValue("@CUST_ID", CustomerId);        
            Cmd.Parameters.AddWithValue("@NAME", CustomerName);
            Cmd.Parameters.AddWithValue("@ADDRESS", Address);
            Cmd.Parameters.AddWithValue("@PHONE", Phone);
            Cmd.Parameters.AddWithValue("@EMAIL", Email);
            Cmd.Parameters.AddWithValue("@WEB", WebAddr);
            Cmd.Parameters.AddWithValue("@OPP_BAL", OppBal);
            Cmd.Parameters.AddWithValue("@CREDIT_LIMIT", CreditLimit);
            Cmd.Parameters.AddWithValue("@PAYMENT_DAYS", PaymentDays);
            Cmd.ExecuteNonQuery();

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
