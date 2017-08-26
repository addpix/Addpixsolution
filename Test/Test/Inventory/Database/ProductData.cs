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
        public string ProdCode { get; set; }
        public string QRCode { get; set; }
        public string ItemName { get; set; }
        public string UnitMeasure { get; set; }
        public string BrandName { get; set; }
        public string Category { get; set; }
        public string TaxCategory { get; set; }
        public string PurchaseTax { get; set; }
        public string SalesTax { get; set; }
        public string PurchaseRate { get; set; }
        public string OpeningStock { get; set; }
        public string ReoderQty { get; set; }
        public string MinQty { get; set; }
        public string SalesRate1 { get; set; }
        public string SalesRate2 { get; set; }
        public string SalesRate3 { get; set; }
        public string BatchName { get; set; }
        public string MfgDate { get; set; }
        public string ExpDate { get; set; }
        public string WarrantyDetails { get; set; }
        public string Location { get; set; }
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

        public DataTable GetDataList(String SPName, String Column)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand(SPName, Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "SS");
                Cmd.Parameters.AddWithValue("@COLUMN_NAME", Column);
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

        public String GetMaxValue()
        {
            try
            {
                DataTable dtReturnTable = new DataTable();
                Cmd = new SqlCommand("spProduct", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "MAX");
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);

                adp.Fill(dtReturnTable);
                return dtReturnTable.Rows[0]["productCode"] + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public DataTable GetRow(String Value)
        {
            try
            {
                DataTable dtReturnTable = new DataTable();

                Cmd = new SqlCommand("spProduct", Con, Trans);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@OPERATION", "SR");
                Cmd.Parameters.AddWithValue("@PRODUCT_CODE", Value);
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
            Cmd = new SqlCommand("spProduct", Con, Trans);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@OPERATION", "D");
            Cmd.Parameters.AddWithValue("@PRODUCT_CODE", Value);
            Cmd.ExecuteNonQuery();
        }

        public void fnTransactionData(String Operation)
        {
            Cmd = new SqlCommand("spProduct", Con, Trans);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.AddWithValue("@OPERATION", Operation);
            Cmd.Parameters.AddWithValue("@PRODUCT_CODE", ProdCode);
            Cmd.Parameters.AddWithValue("@QR_CODE", QRCode);
            Cmd.Parameters.AddWithValue("@ITEM_NAME", ItemName);
            Cmd.Parameters.AddWithValue("@UNIT_MEASURE", UnitMeasure);
            Cmd.Parameters.AddWithValue("@BRAND_NAME", BrandName);
            Cmd.Parameters.AddWithValue("@CATEGORY", Category);
            Cmd.Parameters.AddWithValue("@TAX_CATEGORY", TaxCategory);
            Cmd.Parameters.AddWithValue("@PURCHASE_TAX", PurchaseTax);
            Cmd.Parameters.AddWithValue("@SALES_TAX", SalesTax);
            Cmd.Parameters.AddWithValue("@PURCHASE_RATE", PurchaseRate);
            Cmd.Parameters.AddWithValue("@OPENING_STOCK", OpeningStock);
            Cmd.Parameters.AddWithValue("@REORDER_QTY", ReoderQty);
            Cmd.Parameters.AddWithValue("@MIN_QTY", MinQty);
            Cmd.Parameters.AddWithValue("@SALES_RATE1", SalesRate1);
            Cmd.Parameters.AddWithValue("@SALES_RATE2", SalesRate2);
            Cmd.Parameters.AddWithValue("@SALES_RATE3", SalesRate3);
            Cmd.Parameters.AddWithValue("@BATCH_NAME", BatchName);
            Cmd.Parameters.AddWithValue("@MFG_DATE", MfgDate);
            Cmd.Parameters.AddWithValue("@EXP_DATE", ExpDate);
            Cmd.Parameters.AddWithValue("@WARRANTY_DETAILS", WarrantyDetails);
            Cmd.Parameters.AddWithValue("@LOCATION", Location);
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
