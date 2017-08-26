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
        DataTable MrrData, MrrGrid;
        public string PoStatus { get; set; }
        public MRRData(DataTable Data, DataTable Grid)
        {
            this.MrrData = Data;
            this.MrrGrid = Grid;
        }
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

        public String GetMaxValue()
        {
            try
            {
                DataTable dtReturnTable = new DataTable();
                Cmd = new SqlCommand("spMrr", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "MAX");
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);

                adp.Fill(dtReturnTable);
                return dtReturnTable.Rows[0]["MrrNo"] + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable FillData(String Operation)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand("spMrr", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", Operation);
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
        
        public DataTable GetRow(String Operation,String Value)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand("spMrr", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", Operation);
                Cmd.Parameters.AddWithValue("@PARAM1", Value);
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

        public void UpdatePo(String Operation,String Value)
        {
            Cmd = new SqlCommand("spMrr", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", Operation);
            Cmd.Parameters.AddWithValue("@PO_STATUS", PoStatus);
            Cmd.Parameters.AddWithValue("@PARAM1", Value);
            Cmd.ExecuteNonQuery();

        }

        public void UpdateQty(String Operation)
        {
            Cmd = new SqlCommand("spMrr", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", Operation);
            Cmd.Parameters.AddWithValue("@MRR_GRID", MrrGrid);
            Cmd.ExecuteNonQuery();

        }

        public void UpdateMrrStatus(String MrrNo, String ItemCode)
        {
            Cmd = new SqlCommand("spMrr", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "UpMrr");
            Cmd.Parameters.AddWithValue("@MRR_STATUS", "1");
            Cmd.Parameters.AddWithValue("@PARAM1", MrrNo);
            Cmd.Parameters.AddWithValue("@PARAM2", ItemCode);
            Cmd.ExecuteNonQuery();

        }
        public void fnTransactionData(String Operation)
        {
            Cmd = new SqlCommand("spMrr", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", Operation);
            Cmd.Parameters.AddWithValue("@MRR_DATA", MrrData);
            Cmd.Parameters.AddWithValue("@MRR_GRID", MrrGrid);
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
