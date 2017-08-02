using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Inventory.Database
{
    class MRRData
    {
        public string MRRNo { get; set; }
        public string MRRDate { get; set; }
        public string DelNoteNo { get; set; }
        public string ReqNo { get; set; }
        public string PONo { get; set; }
        public string StoreKeeper { get; set; }
        public string Result = "";
        SqlCommand Cmd;
        SqlConnection Con;
        SqlTransaction Trans;
       
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

                Cmd = new SqlCommand("spProduct", Con, Trans);
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
        public void fnTransactionData()
        {
            Cmd = new SqlCommand("spMrr", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "I");
            Cmd.Parameters.AddWithValue("@MRR_NO", MRRNo);
            Cmd.Parameters.AddWithValue("@STORE_KEEPER", StoreKeeper);
            Cmd.Parameters.AddWithValue("@DATE", MRRDate);
            Cmd.Parameters.AddWithValue("@DEL_NOTE_NO", DelNoteNo);
            Cmd.Parameters.AddWithValue("@PO_NO", PONo);
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
