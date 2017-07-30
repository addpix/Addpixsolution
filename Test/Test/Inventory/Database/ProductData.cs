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
    class ProductData
    {
        public string ProductCode { get; set; }
        public string QRCode { get; set; }
        public string BrandName { get; set; }
        public string ProdCategory { get; set; }
        public string Description { get; set; }
        SqlCommand Cmd;
        SqlConnection Con;
        SqlTransaction Trans;
        string Result = "";

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

                Cmd = new SqlCommand("Product", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "S");
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);

                adp.Fill(dtReturnTable);
                return dtReturnTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        public void fnTransactionData()
        {
            Cmd = new SqlCommand("Product", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "I");
            Cmd.Parameters.AddWithValue("@PRODUCTCODE", ProductCode);
            Cmd.Parameters.AddWithValue("@QRCODE", QRCode);
            Cmd.Parameters.AddWithValue("@BRANDNAME", BrandName);
            Cmd.Parameters.AddWithValue("@PRODCATEGORY", ProdCategory);
            Cmd.Parameters.AddWithValue("@DESCRIPTION", Description);
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
