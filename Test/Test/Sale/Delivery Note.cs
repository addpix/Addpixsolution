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
    public partial class Delivery_Note : DevExpress.XtraEditors.XtraForm
    {
        Sale.Database.SalesDeliveryData salesDeliveryData;
        public string deliveryNoteNo { get; set; }
        public Delivery_Note()
        {
            InitializeComponent();
            salesDeliveryData = new Sale.Database.SalesDeliveryData();
        }

        private void Delivery_Note_Load(object sender, EventArgs e)
        {
            salesDeliveryData.FnConn();
            DataTable dt = salesDeliveryData.FillData("S", "", "spCustomer");
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    collection.Add(dt.Rows[i]["name"].ToString());
                }
            }

            txtCustomerName.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomerName.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerName.MaskBox.AutoCompleteCustomSource = collection;
           
            if (deliveryNoteNo != null)
            {
                barButtonItem1.Enabled = false;
                barButtonItem5.Enabled = true;
                DataSet ds = salesDeliveryData.FillDataSet("searchgrid", deliveryNoteNo, "spsalesDelivery");
                DataTable tab = ds.Tables[0];
                salesDeliveryData.FnTrans();
                if (tab.Rows.Count > 0)
                {
                    txtdeliveryNo.Text = tab.Rows[0]["deliveryNo"] + "";
                    Commen_Form.Functions.DateConverter dc = new Commen_Form.Functions.DateConverter();
                    dtpdate.EditValue = dc.dateconverter(tab.Rows[0]["date"] + "");
                    txtsalesPerson.Text = tab.Rows[0]["salesPerson"] + "";
                    txtCustomerName.Text = tab.Rows[0]["customerName"] + "";
                    txtaddress.Text = tab.Rows[0]["address"]+"";
                    txtemail.Text = tab.Rows[0]["contact"] + "";
                    DataTable gridData = ds.Tables[1];
                    gridControl1.DataSource = gridData;
                }
            }
            else
            {
                dtpdate.EditValue = DateTime.Now;
                barButtonItem5.Enabled = false;
                DataTable dt1 = salesDeliveryData.FillData("M", "", "spsalesDelivery");
                if (dt1.Rows.Count > 0)
                {
                    int slno = Convert.ToInt32(dt1.Rows[0][0].ToString()) + 1;
                    string deno = slno + "";

                    txtdeliveryNo.Text = "DLN/"+deno.PadLeft(5,'0');
                }
                DataTable dt3 = new DataTable();
                dt3.Columns.Add("slno", Type.GetType("System.Int32"));
                dt3.Columns.Add("deliveryNo", Type.GetType("System.String"));
                dt3.Columns.Add("barcode", Type.GetType("System.String"));
                dt3.Columns.Add("description", Type.GetType("System.String"));
                dt3.Columns.Add("quantity", Type.GetType("System.Double"));
                dt3.Columns.Add("status", Type.GetType("System.String"));
                gridControl1.DataSource = dt3;
                salesDeliveryData.FnTrans();
            }

          


        }
        String CustomerId = "";
        private void txtCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerName.Text != "")
                {
                    salesDeliveryData.FnConn();
                    DataTable dt= salesDeliveryData.FillData("search", txtCustomerName.Text, "spCustomer");

                    if (dt.Rows.Count > 0)
                    {
                        txtaddress.Text = dt.Rows[0]["address"].ToString();
                        txtemail.Text = dt.Rows[0]["email"].ToString() + "  " + dt.Rows[0]["phone"].ToString();
                        CustomerId = dt.Rows[0]["customerID"].ToString();
                    }
                    else
                    {
                        CustomerId = "";
                        txtaddress.Text = "";
                        txtemail.Text = "";
                    }
                    salesDeliveryData.FnTrans();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            Test.Sale.Database.QuatationData quatation = new Sale.Database.QuatationData();
            if (gridView1.FocusedColumn.FieldName.Equals("barcode"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

                    quatation.FnConn();
                    DataTable dt = quatation.FillData("barcode", "");
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
                if (gridView1.FocusedColumn.FieldName.Equals("barcode"))
                {
                    String barcode = row["barcode"].ToString();
                    if (barcode != "")
                    {
                        quatation.FnConn();
                        DataTable dt = quatation.FillData("barcodedatails", barcode);
                        if (dt.Rows.Count > 0)
                        {
                           
                            row["description"] = dt.Rows[0]["itemName"].ToString();
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
                            row["barcode"] = dt.Rows[0]["qrCode"].ToString();
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
                    string itemCode = row["barcode"].ToString();
                    salesdata.FnConn();
                    DataTable dt = salesdata.FillData("stockqr", itemCode, "spsales");
                    if (dt.Rows.Count > 0)
                    {
                        double currentstock = Convert.ToDouble(dt.Rows[0]["currentstock"].ToString());
                        if (currentstock > quantity)
                        {
                           
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//save
        {
           // Commen_Form.Functions.DateConverter dc = new Commen_Form.Functions.DateConverter();
            gridView1.RefreshData();
            DataTable source = gridControl1.DataSource as DataTable;
            //source = dc.gridvalidation(source);
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("deliveryno");
            dt.Columns.Add("date");
            dt.Columns.Add("salesPerson");
            dt.Columns.Add("customerId");
            dt.Columns.Add("customerName");
            dt.Columns.Add("address");
            dt.Columns.Add("contact");
            dt.Columns.Add("status");
            dt.Rows.Add(new object[] { txtdeliveryNo.Text, dtpdate.Text, txtsalesPerson.Text, CustomerId, txtCustomerName.Text, txtaddress.Text, txtemail.Text, "No Invoice" });
            Test.Sale.Database.SalesDeliveryData quatationData = new Sale.Database.SalesDeliveryData(source, dt);
            quatationData.FnConn();
            quatationData.fnTransactionData();
            string res = quatationData.FnTrans();
            MessageBox.Show(res, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            barButtonItem1.Enabled = false;
            barButtonItem5.Enabled = true;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                dtpdate.EditValue = DateTime.Now;
                barButtonItem5.Enabled = false;
                barButtonItem1.Enabled = true;
                txtsalesPerson.Text = "";
                txtCustomerName.Text = "";
                txtaddress.Text = "";
                txtemail.Text = "";
                salesDeliveryData.FnConn();
                DataTable dt1 = salesDeliveryData.FillData("M", "", "spsalesDelivery");
                if (dt1.Rows.Count > 0)
                {
                    int slno = Convert.ToInt32(dt1.Rows[0][0].ToString()) + 1;
                    string deno = slno + "";

                    txtdeliveryNo.Text = "DLN/" + deno.PadLeft(5, '0');
                }
                salesDeliveryData.FnTrans();
                DataTable source = gridControl1.DataSource as DataTable;
                source.Clear();
                gridControl1.DataSource = source;
                
            }
            catch (Exception)
            {

               
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string deliveryno = txtdeliveryNo.Text;
            salesDeliveryData.FnConn();
            DataTable dt = salesDeliveryData.FillData("search", deliveryno, "spsalesDelivery");
            salesDeliveryData.FnTrans();
            if (dt.Rows.Count > 0)
            {
                string status = dt.Rows[0]["status"] + "";
                if (status == "No Invoice")
                {
                    Sales_Invoice inv = new Sales_Invoice();
                    inv.deliveryno = deliveryno;
                    inv.ShowDialog();
                }
                else if (status == "Invoice Created")
                {
                    MessageBox.Show("Invocie is created already against this delivery Note " + deliveryno, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}