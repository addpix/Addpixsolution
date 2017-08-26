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
using DevExpress.XtraEditors.Repository;

namespace Test
{
    public partial class New_PO : DevExpress.XtraEditors.XtraForm
    {
        bool flag;
        String no;
        string vendor;
        public New_PO(bool flag, String no)
        {
            InitializeComponent();
            this.flag = flag;
            this.no = no;
        }

        public void calculateTotal()
        {
            gridView1.RefreshData();
            DataTable source = gridControl1.DataSource as DataTable;
            double total = 0;
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                try
                {
                    //  total = total + Convert.ToDouble(source.Rows[i]["totalamount"] + "");
                    total = total + Convert.ToDouble(gridView1.GetRowCellValue(i, "total").ToString());
                }
                catch (Exception Ex)
                {
                }
            }
            txtTotal.Text = total + "";
        }

        private void New_PO_Load(object sender, EventArgs e)
        {
            txtTotal.Text = "0.00";
            Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
            po.FnConn();
            RepositoryItemComboBox riCombo = new RepositoryItemComboBox();
            DataTable dtc = po.FillData("loadUnit", "");
            foreach (DataRow row in dtc.Rows)
            {
                riCombo.Items.Add(row["um"]);
            }
            persistentRepository1.Items.Add(riCombo);
            gridControl1.ExternalRepository = persistentRepository1;


            DataTable dt1 = po.FillData("M", "");


            DataTable dt = new DataTable();

            datePOdate.EditValue = DateTime.Now;
            if (dt1.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                string invoiceno = number + "";
                txtPO.Text = "PO-NO:" + invoiceno.PadLeft(5, '0');
            }

            DataTable dtv = po.FillData("SC", "");
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            if (dtv.Rows.Count > 0)
            {
                for (int i = 0; i < dtv.Rows.Count; i++)
                {
                    collection.Add(dtv.Rows[i]["name"].ToString());
                }
            }

            txtVendor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVendor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVendor.MaskBox.AutoCompleteCustomSource = collection;

            if (flag == true)
            {
                DataTable dtd = po.FillData("updatedata", no);
                DataTable dtg = po.FillData("updategrd", no);
                String res = po.FnTrans();

                (gridControl1.MainView as GridView).Columns["um"].ColumnEdit = riCombo;
                dtg.Columns.Add("um", Type.GetType("System.String"));
                dtg.Columns.Add("unitprice", Type.GetType("System.Double"));
                dtg.Columns.Add("amount", Type.GetType("System.Double"));
                dtg.Columns.Add("taxpercent", Type.GetType("System.Double"));
                dtg.Columns.Add("taxamount", Type.GetType("System.Double"));
                dtg.Columns.Add("total", Type.GetType("System.Double"));
                gridControl1.DataSource = dtg;

                datePOdate.EditValue = DateTime.Now;
                txtPRNo.Text = dtd.Rows[0]["purchaseOrderNo"] + "";
                txtRFQNo.Text = dtd.Rows[0]["rfqNo"] + "";
                txtrequester.Text = dtd.Rows[0]["requester"] + "";
                txtLocation.Text = dtd.Rows[0]["location"] + "";

                Test.Commen_Form.Functions.DateConverter c = new Commen_Form.Functions.DateConverter();
                datePOdate.EditValue = c.dateconverter(dtd.Rows[0]["date"] + "");
            }
            else
            {
                dt.Columns.Add("slno", Type.GetType("System.Int32"));
                dt.Columns.Add("itemCode", Type.GetType("System.String"));
                dt.Columns.Add("description", Type.GetType("System.String"));
                dt.Columns.Add("brand", Type.GetType("System.String"));
                (gridControl1.MainView as GridView).Columns["um"].ColumnEdit = riCombo;
                dt.Columns.Add("quantity", Type.GetType("System.Double"));
                dt.Columns.Add("um", Type.GetType("System.String"));
                dt.Columns.Add("unitprice", Type.GetType("System.Double"));
                dt.Columns.Add("amount", Type.GetType("System.Double"));
                dt.Columns.Add("taxpercent", Type.GetType("System.Double"));
                dt.Columns.Add("taxamount", Type.GetType("System.Double"));
                dt.Columns.Add("total", Type.GetType("System.Double"));

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                gridControl1.DataSource = dt;

            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cash = "";
            if (tglPaymtTyp.IsOn == true)
                cash = "CASH";
            else
                cash = "CREDIT";
            btnSave.Enabled = false;
            DataTable source = gridControl1.DataSource as DataTable;

            DataTable dt = new DataTable();
            dt.Clear();
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
            dt.Columns.Add("status");
            dt.Rows.Add(new object[] { txtPO.Text, datePOdate.Text, txtPRNo.Text, txtRFQNo.Text, txtQtnRfNo.Text, txtLocation.Text, txtrequester.Text, txtVendor.Text, vendor, txtAddress.Text, txtPh.Text, cash, spnPaymtDays.Text, txtNotes.Text, txtTnC.Text, "PO Created." }); 
            Test.Purchase.database.PurchaseOrder purchase = new Purchase.database.PurchaseOrder(source, dt);
            purchase.FnConn();
            purchase.fnTransactionData();
            purchase.FnTrans();
            Test.Purchase.database.Rfq rf = new Purchase.database.Rfq();
            rf.FnConn();
            rf.updatStatus("updateStatus", "status", txtRFQNo.Text);
            rf.FnTrans();
            MessageBox.Show("Purchase Order Created.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {


                int slno = gridView1.GetFocusedDataSourceRowIndex();
                Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["slno"] = (slno + 1) + "";

                if (gridView1.FocusedColumn.FieldName.Equals("itemCode"))
                {
                    String itemcode = row["itemCode"].ToString();
                    if (itemcode != "")
                    {
                        po.FnConn();
                        DataTable dt = po.FillData("itemdetails", itemcode);
                        if (dt.Rows.Count > 0)
                        {
                            row["description"] = dt.Rows[0]["itemName"].ToString();
                            row["brand"] = dt.Rows[0]["brandName"].ToString();
                            row["quantity"] = "1";
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
                        row["quantity"] = "1";
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
                    row["amount"] = total + "";
                    row["total"] = total + "";


                    int index = gridView1.GetFocusedDataSourceRowIndex();
                    gridView1.RefreshRow(index);
                    calculateTotal();

                    gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
                    gridView1.FocusedRowHandle = index;
                    gridView1.ShowEditor();

                }

                if (gridView1.FocusedColumn.FieldName.Equals("unitprice"))
                {


                    double quantity = 0, unitprice = 0;
                    try
                    {
                        quantity = Convert.ToDouble(row["quantity"] + "");
                    }
                    catch (Exception ex1)
                    {
                        row["quantity"] = "1";
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
                    row["amount"] = total + "";
                    row["total"] = total + "";

                    int index = gridView1.GetFocusedDataSourceRowIndex();
                    gridView1.RefreshRow(index);
                    calculateTotal();

                    gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
                    gridView1.FocusedRowHandle = index;
                    gridView1.ShowEditor();

                }

            }


            catch (Exception)
            {
            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();

            if (gridView1.FocusedColumn.FieldName.Equals("itemCode"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
                    po.FnConn();
                    DataTable dt = po.FillData("itemCode", "");
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
                po.FnConn();
                DataTable dt1 = po.FillData("M", "");
                if (dt1.Rows.Count > 0)
                {
                    int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                    string invoiceno = number + "";
                    txtPO.Text = "PO-NO:" + invoiceno.PadLeft(5, '0');
                }

                DataTable source = gridControl1.DataSource as DataTable;
                source.Clear();
                gridControl1.DataSource = source;
                txtLocation.Text = "";
                txtPRNo.Text = "";
                txtrequester.Text = "";
                datePOdate.EditValue = DateTime.Now;
                txtNotes.Text = "";
                txtPh.Text = "";
                txtRFQNo.Text = "";
                txtTnC.Text = "";
                txtVendor.Text = "";
                txtAddress.Text = "";
                txtQtnRfNo.Text = "";
                spnPaymtDays.Text = "1";
                btnSave.Enabled = true;
                txtTotal.Text = "0.00";
                datePOdate.EditValue = DateTime.Now;
            }
            catch (Exception)
            {

            }
        }

        private void txtVendor_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
                po.FnConn();
                DataTable dtv = po.FillData("vendor", txtVendor.Text);

                if (dtv.Rows.Count > 0)
                {
                    txtAddress.Text = dtv.Rows[0]["address"] + "";
                    txtPh.Text = dtv.Rows[0]["phoneNumber"] + "";
                    vendor = dtv.Rows[0]["supplierId"] + "";
                }
                else
                {
                    
                    txtPh.Text = "";
                    txtAddress.Text = "";
                    vendor = "";
                }
                po.FnTrans();
            }
            catch (Exception)
            {


            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Purchase_Order po = new Purchase_Order();
            po.Purchase_Order_Load(sender, e);
            this.Close();

        }

        private void gridControl1_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName.Equals("quantity"))
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            if (gridView1.FocusedColumn.FieldName.Equals("unitprice"))
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}