using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Test
{
    public partial class Proforma_Invoice : DevExpress.XtraEditors.XtraForm
    {
        public Proforma_Invoice()
        {
            InitializeComponent();
        }
        public string  proinvoiceno{ get; set; }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
                    total = total + Convert.ToDouble(gridView1.GetRowCellValue(i, "amount").ToString());
                }
                catch (Exception Ex)
                {
                }
            }
            txtsubtotal.Text = total + "";
        }
        private void Proforma_Invoice_Load(object sender, EventArgs e)
        {
            if (proinvoiceno != null)
            {
                txtinvoice.Text = proinvoiceno;
                Sale.Database.PerformanceInvoiceData p2 = new Sale.Database.PerformanceInvoiceData();
                p2.FnConn();
                DataSet ds= p2.FillDataSet("searchgrid", proinvoiceno, "spperformanceInvoice");
                DataTable inv = ds.Tables[0];
                DataTable invgrid = ds.Tables[1];
                p2.FnTrans();
                if (inv.Rows.Count > 0)
                {
                    Commen_Form.Functions.DateConverter dc = new Commen_Form.Functions.DateConverter();
                    dtpdate.EditValue = dc.dateconverter( inv.Rows[0]["date"] + "");
                    txtbillto.Text = inv.Rows[0]["billto"] + "";
                    txtbilladdress.Text = inv.Rows[0]["billaddress"]+"";
                    txtshipto.Text = inv.Rows[0]["shipto"] + "";
                    txtshipaddress.Text = inv.Rows[0]["shipaddress"] + "";
                    txtnotes.Text = inv.Rows[0]["note"] + "";
                    txtsubtotal.Text = inv.Rows[0]["sutotal"] + "";
                    txttax.Text = inv.Rows[0]["tax"] + "";
                    txtship.Text = inv.Rows[0]["shipping"] + "";
                    txtgrandtotal.Text = inv.Rows[0]["grandtotal"] + "";
                    barButtonItem1.Enabled = false;

                }
                if (invgrid.Rows.Count > 0)
                {
                    gridControl1.DataSource = invgrid;
                }
            }
            else
            {
                Sale.Database.PerformanceInvoiceData pi = new Sale.Database.PerformanceInvoiceData();
                pi.FnConn();
                DataTable dt = pi.FillData("M", "", "spperformanceInvoice");
                pi.FnTrans();
                if (dt.Rows.Count > 0)
                {
                    int number = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    string num = number + "";
                    num = "PRI/" + num.PadLeft(5, '0');
                    txtinvoice.Text = num;
                }
                dtpdate.EditValue = DateTime.Now;
                DataTable dt3 = new DataTable();
                dt3.Columns.Add("slno", Type.GetType("System.Int32"));
                dt3.Columns.Add("pinvoice_no", Type.GetType("System.String"));
                dt3.Columns.Add("itemCode", Type.GetType("System.String"));
                dt3.Columns.Add("description", Type.GetType("System.String"));
                dt3.Columns.Add("quantity", Type.GetType("System.Double"));
                dt3.Columns.Add("unitPrice", Type.GetType("System.Double"));
                dt3.Columns.Add("amount", Type.GetType("System.Double"));
                dt3.Columns.Add("status", Type.GetType("System.String"));
                gridControl1.DataSource = dt3;
            }

            
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            Test.Sale.Database.QuatationData quatation = new Sale.Database.QuatationData();
            if (gridView1.FocusedColumn.FieldName.Equals("itemCode"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

                    quatation.FnConn();
                    DataTable dt = quatation.FillData("itemcode", "");
                    string res = quatation.FnTrans();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            customSource.Add(dt.Rows[i][0].ToString());
                        }
                    }

                    //   customSource.Add("Programa 1");
                    // customSource.Add("Paaaaaaa 3");
                    //customSource.Add("Pabbbbbb 2");

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
                    quatation.FnConn();
                    DataTable dt = quatation.FillData("name", "");
                    string res = quatation.FnTrans();
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
            else if (gridView1.FocusedColumn.FieldName.Equals("quantity"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
                    //quatation.FnConn();
                    //DataTable dt = quatation.FillData("name", "");
                    //string res = quatation.FnTrans();
                    //if (dt.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        customSource.Add(dt.Rows[i][0].ToString());
                    //    }
                    //}

                    currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    currentEditor.MaskBox.AutoCompleteCustomSource = customSource;
                }
            }
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
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {
                int slno = gridView1.GetFocusedDataSourceRowIndex();
                Test.Sale.Database.QuatationData quatation = new Sale.Database.QuatationData();
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["slno"] = (slno + 1) + "";
                row["status"] = "No Invoice";
                if (gridView1.FocusedColumn.FieldName.Equals("itemCode"))
                {
                    String barcode = row["itemCode"].ToString();
                    if (barcode != "")
                    {
                        quatation.FnConn();
                        DataTable dt = quatation.FillData("itemcodedatails", barcode);
                        if (dt.Rows.Count > 0)
                        {

                            row["description"] = dt.Rows[0]["itemName"].ToString();
                            row["unitPrice"] = dt.Rows[0]["salesRate1"].ToString();
                            row["quantity"] = "0";

                        }
                    }
                }
                if (gridView1.FocusedColumn.FieldName.Equals("description"))
                {
                    String description = row["description"].ToString();
                    if (description != "")
                    {
                        quatation.FnConn();
                        DataTable dt = quatation.FillData("description", description);
                        if (dt.Rows.Count > 0)
                        {
                            row["itemCode"] = dt.Rows[0]["productCode"].ToString();
                            row["unitPrice"] = dt.Rows[0]["salesRate1"].ToString();
                            row["quantity"] = "0";

                        }
                    }
                }
                if (gridView1.FocusedColumn.FieldName.Equals("quantity"))
                {
                    Test.Sale.Database.SalesData salesdata = new Sale.Database.SalesData();

                    double quantity = 0, unitprice = 0;
                    try
                    {
                        quantity = Convert.ToDouble(row["quantity"] + "");
                    }
                    catch (Exception ex1)
                    {
                        row["quantity"] = "0";
                    }
                    string itemCode = row["itemCode"].ToString();
                    salesdata.FnConn();
                    DataTable dt = salesdata.FillData("stock", itemCode, "spsales");
                    if (dt.Rows.Count > 0)
                    {
                        double currentstock = Convert.ToDouble(dt.Rows[0]["currentstock"].ToString());
                        if (currentstock > quantity)
                        {
                            double rate = 0,qty;
                            try
                            {
                                rate = Convert.ToDouble(row["unitPrice"].ToString());
                            }
                            catch (Exception ex)
                            {
                                rate = 0;
                            }
                            row["amount"] = (quantity * rate)+"";
                            int index = gridView1.GetFocusedDataSourceRowIndex();
                            gridView1.RefreshRow(index);
                            calculateTotal();
                            gridView1.FocusedColumn = gridView1.GetVisibleColumn(3);
                            gridView1.FocusedRowHandle = index;
                            gridView1.ShowEditor();
                        }
                        else
                        {
                            MessageBox.Show("Product not in stock . Available quantity " + currentstock, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            row["quantity"] = "0";

                        }
                    }


                }
            }
            catch (Exception ex) { }
        }

        private void txtsubtotal_EditValueChanged(object sender, EventArgs e)
        {
            double subtot = 0, tax = 0, shipping = 0, grand = 0;
            try
            {
                subtot = Convert.ToDouble(txtsubtotal.Text);
            }
            catch (Exception ex)
            {
                txtsubtotal.Text = "0";
            }
            try
            {
                shipping = Convert.ToDouble(txtship.Text);
            }
            catch (Exception ex)
            {
                txtship.Text = "0";
            }
            try
            {
                tax = Convert.ToDouble(txttax.Text);
            }
            catch (Exception ex)
            {
                txttax.Text = "0";
            }
            txtgrandtotal.Text = (tax + shipping + subtot) + "";
        }

        private void txttax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtship_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.RefreshData();
            DataTable source = gridControl1.DataSource as DataTable;
            //source = dc.gridvalidation(source);
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Pinvoiceno");
            dt.Columns.Add("date");
            dt.Columns.Add("billto");
            dt.Columns.Add("billaddress");
            dt.Columns.Add("shipto");
            dt.Columns.Add("shipaddress");
            dt.Columns.Add("note");
            dt.Columns.Add("subtotal");
            dt.Columns.Add("tax");
            dt.Columns.Add("shipping");
            dt.Columns.Add("grandtotal");
            dt.Columns.Add("status");
            dt.Rows.Add(new object[] { txtinvoice.Text, dtpdate.Text, txtbillto.Text, txtbilladdress.Text, txtshipto.Text,txtshipaddress.Text, txtnotes.Text,txtsubtotal.Text,txttax.Text,txtship.Text,txtgrandtotal.Text, "Not Invoice" });
            Test.Sale.Database.PerformanceInvoiceData performance = new Sale.Database.PerformanceInvoiceData(source, dt);
            performance.FnConn();
            performance.fnTransactionData();
            string res = performance.FnTrans();
            MessageBox.Show(res, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            barButtonItem1.Enabled = false;
            barButtonItem4.Enabled = true;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}