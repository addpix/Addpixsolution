﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Test.Sale.Database
{
    class WarrantyClameData
    {
        //ha
        public string claimeNo { get; set; }
        public string claimeDate { get; set; }
        public string contactName { get; set; }
        public string conactNumber { get; set; }
        public string mailid { get; set; }
        public string purchaseDate { get; set; }
        public string ItemName { get; set; }
        public string MOdelName { get; set; }
        public string SerialNumber { get; set; }
        public string complaintDetails { get; set; }
        public string status { get; set; }
        SqlCommand command;
        SqlConnection connection;
        SqlTransaction transaction;
        string Result = "";
        public static string cnnString = "Data Source=.;Initial Catalog=MYDB;Persist Security Info=True;User ID=sa;Password=123456;";

        public void FnConn()
        {
            connection = new SqlConnection(cnnString);
            connection.Open();
            transaction = connection.BeginTransaction();

        }

        public void fnTransactionData()
        {


            command = new SqlCommand("SP_warranty", connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@claimeno", claimeNo);
            command.Parameters.AddWithValue("@claimedate", claimeDate);
            command.Parameters.AddWithValue("@contactName", contactName);
            command.Parameters.AddWithValue("@contactNumber", conactNumber);
            command.Parameters.AddWithValue("@mailid", mailid);
            command.Parameters.AddWithValue("@purchaseDate", purchaseDate);
            command.Parameters.AddWithValue("@itemName", ItemName);
            command.Parameters.AddWithValue("@serialNumber", SerialNumber);
            command.Parameters.AddWithValue("@modelName",MOdelName);
            command.Parameters.AddWithValue("@complaintdetails", complaintDetails);
            command.Parameters.AddWithValue("@status", status);
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
