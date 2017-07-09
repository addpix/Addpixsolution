using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Test
{
    class clsNewCategory
    {
        public static string cnnString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MYDB;Persist Security Info=True;User ID=erp;Password=;";
        SqlCommand Comm;
        SqlConnection Con;
        SqlTransaction Trans;

        public string strOP { get; set; }
        public string strDocNo { get; set; }
        public string strDocType { get; set; }
        public string strBranch { get; set; }
        public string strCode { get; set; }
        string Result = "";
    

        public void FnConn()
        {
            Con = new SqlConnection(cnnString);
            Con.Open();
            Trans = Con.BeginTransaction();
        }
       
        public void  fnTransactionData()
        {
            Comm = new SqlCommand("SP_DEMO", Con, Trans);
            Comm.CommandType = CommandType.StoredProcedure;
                        
            Comm.Parameters.AddWithValue("@SLNO", strOP);
            Comm.Parameters.AddWithValue("@PRODUCT_CODE", strDocNo);
            Comm.Parameters.AddWithValue("@ITEM_NAME", strDocType);
            Comm.Parameters.AddWithValue("@UNIT_MEASURE", strBranch);
            Comm.Parameters.AddWithValue("@BRAND_NAME", strCode);
            Comm.Parameters.AddWithValue("@CATEGORY", strOP);
            Comm.Parameters.AddWithValue("@TAX_CATEGORY", strDocNo);
            Comm.Parameters.AddWithValue("@PURCHASE_TAX", strDocType);
            Comm.Parameters.AddWithValue("@SALES_TAX", strBranch);
            Comm.Parameters.AddWithValue("@PURCHASE_RATE", strCode);           
            Comm.Parameters.AddWithValue("@OPENING_STOCK", strOP);
            Comm.Parameters.AddWithValue("@REORDER_QTY", strDocNo);
            Comm.Parameters.AddWithValue("@MIN_QTY", strDocType);
            Comm.Parameters.AddWithValue("@SALES_RATE1", strBranch);
            Comm.Parameters.AddWithValue("@SALES_RATE2", strCode);
            Comm.Parameters.AddWithValue("@SALES_RATE3", strOP);
            Comm.Parameters.AddWithValue("@BATCH_NAME", strDocNo);
            Comm.Parameters.AddWithValue("@MFG_DATE", strDocType);
            Comm.Parameters.AddWithValue("@EXP_DATE", strBranch);
            Comm.Parameters.AddWithValue("@WARRANTY_DETAILS", strCode);
            Comm.Parameters.AddWithValue("@LOCATION", strCode);
            Comm.ExecuteNonQuery();
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
                Result = "Error"+sqlEx.Message;
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
