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
    public partial class Sales_Invoice : DevExpress.XtraEditors.XtraForm
    {
        public Sales_Invoice()
        {
            InitializeComponent();
        }
        String type = "Cash";
        public string deliveryno { get; set; }
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
                    total = total + Convert.ToDouble(gridView1.GetRowCellValue(i, "totalAmount").ToString());
                }
                catch (Exception Ex)
                {
                }
            }
            txtgrosstotal.Text = total + "";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Sales_Invoice_Load(object sender, EventArgs e)
        {
            typecash.IsOn = true;
            cmbpaymentmode.SelectedIndex=0;
            Test.Sale.Database.SalesData sales = new Sale.Database.SalesData();
            sales.FnConn();
            DataTable dt1 = sales.FillData("M", "","spsales");
            
            if (dt1.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                string invoiceno = number + "";
                txtinvoice.Text = "INV/"+invoiceno.PadLeft(5, '0');
                
            }
            DataTable dt2= sales.FillData("S", "", "spCustomer");
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    try
                    {
                        cmbcustomer.Properties.Items.Add(dt2.Rows[i]["name"].ToString());
                    }
                    catch (Exception ex) { }
                }
            }
            dtpdate.EditValue = DateTime.Now;
            String res = sales.FnTrans();
            DataTable dt = new DataTable();
            dt.Columns.Add("slno", Type.GetType("System.Int32"));
            dt.Columns.Add("invoice_no", Type.GetType("System.String"));
            dt.Columns.Add("barcode", Type.GetType("System.String"));
            dt.Columns.Add("itemcode", Type.GetType("System.String"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("brandName", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.Double"));
            dt.Columns.Add("offer", Type.GetType("System.Double"));
            dt.Columns.Add("unitPrice", Type.GetType("System.Double"));
            dt.Columns.Add("amount", Type.GetType("System.Double"));
            dt.Columns.Add("discountPercent", Type.GetType("System.Double"));
            dt.Columns.Add("discountAmount", Type.GetType("System.Double"));
            dt.Columns.Add("taxPercent", Type.GetType("System.Double"));
            dt.Columns.Add("taxAmount", Type.GetType("System.Double"));
            dt.Columns.Add("totalAmount", Type.GetType("System.Double"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
            if (deliveryno != null)
            {
                sales.FnConn();
                DataSet ds= sales.FillDataSet("searchgrid", deliveryno, "spsalesDelivery");
                sales.FnTrans();
                DataTable delivery = ds.Tables[0];
                DataTable deliverygrid = ds.Tables[1];
                if (delivery.Rows.Count > 0)
                {
                    CustomerId = delivery.Rows[0]["customerid"] + "";
                    cmbcustomer.Text = delivery.Rows[0]["customerName"] + "";
                    txtaddress.Text = delivery.Rows[0]["address"] + "";
                   // txtphone.Text = delivery.Rows[0]["contact"] + "";
                    txtsalesperson.Text = delivery.Rows[0]["salesPerson"] + "";
                    dt.Clear();
                    sales.FnConn();
                    for (int i = 0; i < deliverygrid.Rows.Count; i++)
                    {
                        string barcode = deliverygrid.Rows[i]["barcode"] + "";
                        double qty =Convert.ToDouble( deliverygrid.Rows[i]["quantity"] + "");

                        if (barcode!=null)
                        {
                            DataTable dts = sales.FillData("barcodedatails", barcode, "spQuatation");
                            if (dts.Rows.Count > 0)
                            {
                                string itemCode = dts.Rows[0]["productCode"] + "";
                                string description = dts.Rows[0]["itemName"] + "";
                                string brandName = dts.Rows[0]["brandName"] + "";

                                double unitprice = Convert.ToDouble(dts.Rows[0]["salesRate1"] + "");
                                double totalprice = unitprice * qty;
                                dt.Rows.Add(i + 1, "", barcode, itemCode, description, brandName, qty, "1", unitprice, totalprice, 0, 0, 0, 0, totalprice);
                            }
                        }
                        
                    }
                    sales.FnTrans();
                    calculateTotal();
                    
                }

            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sales_Invoice_View a = new Sales_Invoice_View();
            a.ShowDialog();
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            Test.Sale.Database.SalesData sales = new Sale.Database.SalesData();
            if (gridView1.FocusedColumn.FieldName.Equals("barcode"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

                    sales.FnConn();
                    DataTable dt = sales.FillData("barcode", "", "spQuatation");
                    string res = sales.FnTrans();
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
            else if (gridView1.FocusedColumn.FieldName.Equals("itemcode"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
                    sales.FnConn();
                    DataTable dt = sales.FillData("itemcode", "", "spQuatation");
                    string res = sales.FnTrans();
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
                    sales.FnConn();
                    DataTable dt = sales.FillData("name", "", "spQuatation");
                    string res = sales.FnTrans();
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
                    sales.FnConn();
                    customSource = null;

                    currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    currentEditor.MaskBox.AutoCompleteCustomSource = customSource;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//btnsave
        {
            int tendercash = Convert.ToInt32(txtpayamount.Text);
            int flag = 0;     
            if (tendercash < 1)
            {
                try
                {
                    DialogResult re = MessageBox.Show("Pay amount not entered please check. Click yes to Save with out pay amount ", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (re == DialogResult.Yes)
                    {
                        flag = 0;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
                catch (Exception) { }
            }
            if (flag == 0)
            {
                gridView1.RefreshData();
                DataTable source = gridControl1.DataSource as DataTable;
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("invoice_no");
                dt.Columns.Add("salesPerson");
                dt.Columns.Add("date");
                dt.Columns.Add("type");
                dt.Columns.Add("customerid");
                dt.Columns.Add("customerName");
                dt.Columns.Add("address");
                dt.Columns.Add("phone");
                dt.Columns.Add("paymentMode");
                dt.Columns.Add("balanceDue");
                dt.Columns.Add("paymentDueDate");
                dt.Columns.Add("grossTotal");
                dt.Columns.Add("discount");
                dt.Columns.Add("netTotal");
                dt.Columns.Add("payAmount");
                dt.Columns.Add("balance");
                //typecash.IsOn = true;
                double payamount = 0,balance=0;
                try
                {
                    payamount = Convert.ToDouble(txtpayamount.Text);
                    balance = Convert.ToDouble(txtbalance.Text);
                    if (balance < 0)
                    {
                        balance = 0;
                        payamount = Convert.ToDouble(txtnettotal.Text);
                    }

                }
                catch(Exception ex)
                {
                    
                }
                dt.Rows.Add(new object[] { txtinvoice.Text, txtsalesperson.Text, dtpdate.Text, type, CustomerId, cmbcustomer.Text, txtaddress.Text, txtphone.Text, cmbpaymentmode.Text, txtbalancedue.Text, dtppaymentdue.Text, txtgrosstotal.Text, txtdiscount.Text, txtnettotal.Text, payamount+"", balance+"" });
                Test.Sale.Database.SalesData salesData = new Test.Sale.Database.SalesData(source, dt);
                salesData.FnConn();

                salesData.fnTransactionData();
                if (deliveryno != "")
                {
                    salesData.fndeliveryUpdate(deliveryno);
                }
                string res = salesData.FnTrans();
                if (res == "Success")
                {
                    MessageBox.Show("New Invoice Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    barButtonItem1.Enabled = false;
                }
            }
        }

        private void type_Toggled(object sender, EventArgs e)
        {
            if (typecash.IsOn == true)
            {
                type = "Credit";
                
            }
            else
            {
                type = "Cash";
            }
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {
                int slno = gridView1.GetFocusedDataSourceRowIndex();
                Test.Sale.Database.SalesData salesdata = new Sale.Database.SalesData();
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["slno"] = (slno + 1) + "";
                if (gridView1.FocusedColumn.FieldName.Equals("barcode"))
                {
                    String barcode = row["barcode"].ToString();
                    if (barcode != "")
                    {
                        salesdata.FnConn();
                        DataTable dt = salesdata.FillData("barcodedatails", barcode, "spQuatation");
                        if (dt.Rows.Count > 0)
                        {
                            row["itemcode"] = dt.Rows[0]["productCode"].ToString();
                            row["description"] = dt.Rows[0]["itemName"].ToString();
                            row["brandName"] = dt.Rows[0]["brandName"].ToString();
                            row["quantity"] = "0";
                            row["amount"] = "0";
                            row["discountPercent"] = "0";
                            row["discountAmount"] = "0";
                            row["taxPercent"] = dt.Rows[0]["taxOnSale"].ToString();
                            row["taxAmount"] = "0";
                            row["unitPrice"] = dt.Rows[0]["salesRate1"].ToString();
                            row["totalAmount"] = "0";
                            
                        }
                    }
                }
                if (gridView1.FocusedColumn.FieldName.Equals("itemcode"))
                {
                    String itemcode = row["itemcode"].ToString();
                    if (itemcode != "")
                    {
                        salesdata.FnConn();
                        DataTable dt = salesdata.FillData("itemcodedatails", itemcode, "spQuatation");
                        if (dt.Rows.Count > 0)
                        {
                            row["barcode"] = dt.Rows[0]["qrCode"].ToString();
                            row["description"] = dt.Rows[0]["itemName"].ToString();
                            row["brandName"] = dt.Rows[0]["brandName"].ToString();
                            row["quantity"] = "0";
                            row["amount"] = "0";
                            row["discountPercent"] = "0";
                            row["discountAmount"] = "0";
                            row["taxPercent"] = dt.Rows[0]["taxOnSale"].ToString();
                            row["taxAmount"] = "0";
                            row["unitPrice"] = dt.Rows[0]["salesRate1"].ToString();
                            row["totalAmount"] = "0";
                        }
                    }
                }
                if (gridView1.FocusedColumn.FieldName.Equals("description"))
                {
                    String description = row["description"].ToString();
                    if (description != "")
                    {
                        salesdata.FnConn();
                        DataTable dt = salesdata.FillData("description", description, "spQuatation");
                        if (dt.Rows.Count > 0)
                        {
                            row["barcode"] = dt.Rows[0]["qrCode"].ToString();
                            row["itemcode"] = dt.Rows[0]["productCode"].ToString();
                            row["brandName"] = dt.Rows[0]["brandName"].ToString();
                            row["quantity"] = "0";
                            row["amount"] = "0";
                            row["discountPercent"] = "0";
                            row["discountAmount"] = "0";
                            row["taxPercent"] = dt.Rows[0]["taxOnSale"].ToString();
                            row["taxAmount"] = "0";
                            row["unitPrice"] = dt.Rows[0]["salesRate1"].ToString();
                            row["totalAmount"] = "0";
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
                    string itemCode = row["itemcode"].ToString();
                    salesdata.FnConn();
                    DataTable dt=salesdata.FillData("stock", itemCode, "spsales");
                    if (dt.Rows.Count > 0)
                    {
                        double currentstock = Convert.ToDouble(dt.Rows[0]["currentstock"].ToString());
                        if (currentstock > quantity)
                        {
                            try
                            {
                                unitprice = Convert.ToDouble(row["unitprice"] + "");
                            }
                            catch (Exception invalidstring)
                            {
                                row["unitprice"] = "0";
                            }
                            double total = quantity * unitprice;
                            row["totalamount"] = total + "";
                            row["amount"] = total + "";

                            int index = gridView1.GetFocusedDataSourceRowIndex();
                            gridView1.RefreshRow(index);
                            calculateTotal();
                            gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
                            gridView1.FocusedRowHandle = index;
                            gridView1.ShowEditor();
                        }
                        else
                        {
                            MessageBox.Show("Product not in stock . Available quantity " + currentstock, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            row["quantity"] = "0";
                            row["amount"] = "0";
                            row["totalAmount"] = "0";

                            int index = gridView1.GetFocusedDataSourceRowIndex();
                            gridView1.RefreshRow(index);
                            calculateTotal();
                            gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
                            gridView1.FocusedRowHandle = index;
                            gridView1.ShowEditor();
                        }
                    }
                    

                }  
            }
            catch (Exception ex)
            {

            }
            }

        private void txtgrosstotal_EditValueChanged(object sender, EventArgs e)
        {
            double grosstotal = 0, discount = 0;
            try
            {
                grosstotal = Convert.ToDouble(txtgrosstotal.Text);
            }
            catch (Exception ex)
            {
                grosstotal = 0;
                txtgrosstotal.Text = "0";
                ex.ToString();
            }
            try
            {
                discount = Convert.ToDouble(txtdiscount.Text);
            }
            catch (Exception ex)
            {
                discount = 0;
                txtdiscount.Text = "0";
                ex.ToString();
            }
            txtnettotal.Text = (grosstotal - discount) + ""; 
        }

        private void txtdiscount_EditValueChanged(object sender, EventArgs e)
        {
            double grosstotal = 0, discount = 0;
            try
            {
                grosstotal = Convert.ToDouble(txtgrosstotal.Text);
            }
            catch (Exception ex)
            {
                grosstotal = 0;
                txtgrosstotal.Text = "0";
                ex.ToString();
            }
            try
            {
                discount = Convert.ToDouble(txtdiscount.Text);
            }
            catch (Exception ex)
            {
                discount = 0;
                txtdiscount.Text = "0";
                ex.ToString();
            }
            txtnettotal.Text = (grosstotal - discount) + "";
        }

        private void txtnettotal_EditValueChanged(object sender, EventArgs e)
        {
            double nettotal = 0, payamount = 0;
            try
            {
                nettotal = Convert.ToDouble(txtnettotal.Text);
            }
            catch (Exception ex)
            {
                nettotal = 0;
                txtnettotal.Text = "0";
                ex.ToString();
            }
            try
            {
                payamount = Convert.ToDouble(txtpayamount.Text);
            }
            catch (Exception ex)
            {
                payamount = 0;
                txtpayamount.Text = "0";
                ex.ToString();
            }
            txtbalance.Text = (nettotal - payamount) + "";
        }

        private void txtpayamount_EditValueChanged(object sender, EventArgs e)
        {
                double nettotal = 0, payamount = 0;
            try
            {
                nettotal = Convert.ToDouble(txtnettotal.Text);
            }
            catch (Exception ex)
            {
                nettotal = 0;
                txtnettotal.Text = "0";
                ex.ToString();
            }
            try
            {
                payamount = Convert.ToDouble(txtpayamount.Text);
            }
            catch (Exception ex)
            {
                payamount = 0;
                txtpayamount.Text = "0";
                ex.ToString();
            }
            double balance = nettotal - payamount;
            
            txtbalance.Text = balance + "" ;
            if (balance > 0)
            {
                typecash.IsOn = true;
            }
            else
            {
                typecash.IsOn = false;
            }
        }
        String CustomerId = "";
        private void cmbcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcustomer.Text != "")
            {
                Test.Sale.Database.SalesData sales = new Sale.Database.SalesData();
                sales.FnConn();
                DataTable dt = sales.FillData("search", cmbcustomer.Text, "spCustomer");

                if (dt.Rows.Count > 0)
                {
                    txtaddress.Text = dt.Rows[0]["address"].ToString();
                    txtphone.Text =  dt.Rows[0]["phone"].ToString();
                    CustomerId = dt.Rows[0]["customerID"].ToString();
                }
                else
                {
                    CustomerId = "";
                    txtaddress.Text = "";
                    txtphone.Text = "";
                }
                sales.FnTrans();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Master.Customer a = new Master.Customer(null);
            a.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                cmbpaymentmode.SelectedIndex = 0;
                DataTable source = gridControl1.DataSource as DataTable;
                source.Clear();
                gridControl1.DataSource = source;
                cmbcustomer.Text = "";
                txtaddress.Text = "";
                CustomerId = "";
                txtphone.Text = "";
                txtsalesperson.Text = "";
                txtgrosstotal.Text = "0";
                txtdiscount.Text = "0";
                txtnettotal.Text = "0";
                txtpayamount.Text = "0";
                txtbalance.Text = "0";
                Test.Sale.Database.SalesData sales = new Sale.Database.SalesData();
                sales.FnConn();
                DataTable dt1 = sales.FillData("M", "", "spsales");

                if (dt1.Rows.Count > 0)
                {
                    int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                    string invoiceno = number + "";
                    txtinvoice.Text = "INV/"+invoiceno.PadLeft(5, '0'); 
                }
                sales.FnTrans();
                //cmbpaymentmode.Text = "";
                txtbalancedue.Text = "0";
                dtppaymentdue.Text = "";
                barButtonItem1.Enabled = true;
                deliveryno = "";

            }
            catch (Exception)
            {
                
            } 
           
        }
    }
}