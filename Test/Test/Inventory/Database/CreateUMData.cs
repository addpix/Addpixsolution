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
    class CreateUMData
    {
        public string UnitName { get; set; }
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

                Cmd = new SqlCommand("spUnit", Con, Trans);
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
            Cmd = new SqlCommand("spUnit", Con, Trans);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.AddWithValue("@OPERATION", "I");
            Cmd.Parameters.AddWithValue("@UNIT_NAME", UnitName);
            Cmd.ExecuteNonQuery();
        }

        public void DeleteData(String Value)
        {
            Cmd = new SqlCommand("spUnit", Con, Trans);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "D");
            Cmd.Parameters.AddWithValue("@UNIT_NAME", Value);
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
