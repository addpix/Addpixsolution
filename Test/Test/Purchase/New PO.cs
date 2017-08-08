using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Test
{
    public partial class New_PO : DevExpress.XtraEditors.XtraForm
    {
        public New_PO()
        {
            InitializeComponent();
        }

      
        private void New_PO_Load(object sender, EventArgs e)
        {
            Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
            po.FnConn();

            DataTable dt1 = po.FillData("M", "");
            String res = po.FnTrans();

            DataTable dt = new DataTable();

            if (dt1.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                txtPO.Text = "P" + number;
            }

            dt.Columns.Add("slno", Type.GetType("System.Int32"));
            dt.Columns.Add("itemcode", Type.GetType("System.String"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("brand", Type.GetType("System.String"));
            dt.Columns.Add("um", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.Double"));
            dt.Columns.Add("unitprice", Type.GetType("System.Double"));
            dt.Columns.Add("amount", Type.GetType("System.Double"));
            dt.Columns.Add("taxpercent", Type.GetType("System.Double"));
            dt.Columns.Add("taxamount", Type.GetType("System.Double"));
            dt.Columns.Add("total", Type.GetType("System.Double"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable source = gridControl1.DataSource as DataTable;
           

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("slno");
            dt.Columns.Add("orderNo");
            dt.Columns.Add("date");
            dt.Columns.Add("purchaseRequestNo");
            dt.Columns.Add("quotationRequestNo");
            dt.Columns.Add("QuotationRefrenceNo");
            dt.Columns.Add("location");
            dt.Columns.Add("requester");
            dt.Columns.Add("vendor");
            dt.Columns.Add("vendorId");
            dt.Columns.Add("address");
            dt.Columns.Add("ph");
            dt.Columns.Add("paymentType");
            dt.Columns.Add("paymentDays");
            dt.Columns.Add("notes");
            dt.Columns.Add("conditions");
            dt.Rows.Add(new object[] {"11", txtPO.Text, datePOdate.Text, txtPRNo.Text, txtRFQNo.Text, TtxtQtnRfNo.Text, txtLocation.Text, txtrequester.Text, txtVendor.Text, "0000", txtAddress.Text, txtPh.Text, "cash", spnPaymtDays.Text, txtNotes.Text,txtTnC.Text});
            Test.Purchase.database.PurchaseOrder purchase = new Purchase.database.PurchaseOrder(source, dt);
            purchase.FnConn();
            purchase.fnTransactionData();
            purchase.FnTrans();
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {

           
            int slno = gridView1.GetFocusedDataSourceRowIndex();
            Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            row["slno"] = (slno + 1) + "";

            if (gridView1.FocusedColumn.FieldName.Equals("itemcode"))
            {
                String itemcode = row["itemcode"].ToString();
                if (itemcode != "")
                {
                    po.FnConn();
                    DataTable dt = po.FillData("itemdetails", itemcode);
                    if (dt.Rows.Count > 0)
                    {
                        row["description"] = dt.Rows[0]["itemName"].ToString();
                        row["brand"] = dt.Rows[0]["brandName"].ToString();
                        row["um"] = dt.Rows[0]["unitMeasure"].ToString();
                        row["quantity"] = "0";
                        row["unitPrice"] = dt.Rows[0]["salesRate1"].ToString();
                        row["total"] = "0";
                    }
                }
            }

            if (gridView1.FocusedColumn.FieldName.Equals("quantity"))
            {


                double quantity = 0, unitprice = 0;
                try
                {
                    quantity = Convert.ToDouble(row["quantity"] + "");
                }
                catch (Exception ex1)
                {
                    row["quantity"] = "0";
                }

                try
                {
                    unitprice = Convert.ToDouble(row["unitprice"] + "");
                }
                catch (Exception invalidstring)
                {
                    row["unitprice"] = "";
                }
                double total = quantity * unitprice;
                row["total"] = total + "";


                int index = gridView1.GetFocusedDataSourceRowIndex();
                gridView1.RefreshRow(index);
               // calculateTotal();
              
                gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
                gridView1.FocusedRowHandle = index;
                gridView1.ShowEditor();

            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();

             if (gridView1.FocusedColumn.FieldName.Equals("itemcode"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
                    po.FnConn();
                    DataTable dt = po.FillData("itemcode", "");
                    string res = po.FnTrans();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            customSource.Add(dt.Rows[i][0].ToString());
                        }
                    }

                    currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    currentEditor.MaskBox.AutoCompleteCustomSource = customSource;
                }
            }
            else if (gridView1.FocusedColumn.FieldName.Equals("description"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
                    po.FnConn();
                    DataTable dt = po.FillData("name", "");
                    string res = po.FnTrans();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            customSource.Add(dt.Rows[i][0].ToString());
                        }
                    }

                    currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    currentEditor.MaskBox.AutoCompleteCustomSource = customSource;
                }
            }
        }
    }
}