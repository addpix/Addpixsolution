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

namespace Test
{
    public partial class Sales_Return : DevExpress.XtraEditors.XtraForm
    {
        public String Invoiceno { get; set; }
        public Sales_Return()
        {
            InitializeComponent();
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {

        }
        string CustomerId = "";
        string returnno = "";
        private void Sales_Return_Load(object sender, EventArgs e)
        {
            Commen_Form.Functions.DateConverter dc = new Commen_Form.Functions.DateConverter(); 
            if (Invoiceno != "")
            {
                txtinvoiceno.Text = Invoiceno;
                Sale.Database.SalesData salesData = new Sale.Database.SalesData();
                salesData.FnConn();
                DataSet ds= salesData.FillDataSet("select", Invoiceno, "spsales");
                DataTable inv = ds.Tables[0];
                DataTable invgrid = ds.Tables[1];
                DataTable max = salesData.FillData("M", "", "spsalesReturn");
                if (max.Rows.Count > 0)
                {
                    returnno = (Convert.ToInt32(max.Rows[0][0] + "")+1)+"";
                }
                if (invgrid.Rows.Count > 0)
                {
                    //invgrid.Columns.Add("retqty");
                    for (int i = 0; i < invgrid.Rows.Count; i++)
                    {
                        invgrid.Rows[i]["returnNO"] = returnno;
                        invgrid.Rows[i]["retqty"] = "0";
                    }
                    gridControl1.DataSource = invgrid;
                    
                }
                if (inv.Rows.Count > 0)
                {
                    if (inv.Rows[0]["type"] + "" == "Credit")
                    {
                        toggleSwitch1.IsOn = true;
                        type = "Credit";
                    }
                    else
                    {
                        toggleSwitch1.IsOn = false;
                        type= "Cash";
                    }
                    CustomerId = inv.Rows[0]["customerid"] + "";
                    txtcustomername.Text = inv.Rows[0]["customerName"] + "";
                    txtaddress.Text = inv.Rows[0]["address"] + "";
                    txtphone.Text = inv.Rows[0]["phone"] + "";
                    dtpdate.Text = dc.dateconverter(inv.Rows[0]["date"] + "");
                    txtnetamount.Text = inv.Rows[0]["netTotal"] + "";
                    payamount.Text = inv.Rows[0]["payAmount"] + "";
                    txtsalesperson.Text = inv.Rows[0]["salesPerson"] + "";

                }
            }
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
                    total = total + Convert.ToDouble(gridView1.GetRowCellValue(i, "totalAmount").ToString());
                }
                catch (Exception Ex)
                {
                }
            }
            txtnetamount.Text = total + "";
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {
                int slno = gridView1.GetFocusedDataSourceRowIndex();
                Test.Sale.Database.QuatationData quatation = new Sale.Database.QuatationData();
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
              //  row["slno"] = (slno + 1) + "";
                if (gridView1.FocusedColumn.FieldName.Equals("retqty"))
                {


                    double quantity = 0, unitprice = 0,retqty=0;
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
                        retqty = Convert.ToDouble(row["retqty"] + "");
                    }
                    catch (Exception ex1)
                    {
                        row["retqty"] = "0";
                    }

                    try
                    {
                        unitprice = Convert.ToDouble(row["unitprize"] + "");
                    }
                    catch (Exception invalidstring)
                    {
                        row["unitprize"] = "0";
                    }
                    if (retqty > quantity)
                    {
                        row["retqty"] = "0";
                        retqty = 0;
                        MessageBox.Show("Return quantity is greater than purchased quantity", "ALERT",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    double total =( quantity -retqty)* unitprice;
                    row["amount"] = total + "";
                    row["totalamount"] = total + "";


                    int index = gridView1.GetFocusedDataSourceRowIndex();
                    gridView1.RefreshRow(index);
                    calculateTotal();
                    // DevExpress.XtraGrid.GridControl gc = (DevExpress.XtraGrid.GridControl)sender;
                    //DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.KeyboardFocusView;
                    //gv.FocusedColumn = gv.GetVisibleColumn(5);
                    //gv.FocusedRowHandle = index;
                    //gv.ShowEditor();
                    gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
                    gridView1.FocusedRowHandle = index;
                    gridView1.ShowEditor();

                }
            }
            catch (Exception) { }
            }

        private void gridControl1_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName.Equals("retqty"))
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.RefreshData();
            DataTable source = gridControl1.DataSource as DataTable;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("returnNO");
            dt.Columns.Add("invoice_no");
            dt.Columns.Add("date");
            dt.Columns.Add("salesPerson");
            dt.Columns.Add("type");
            dt.Columns.Add("customerid");
            dt.Columns.Add("customerName");
            dt.Columns.Add("address");
            dt.Columns.Add("phone");
            dt.Columns.Add("netAmount");
            dt.Columns.Add("paidAmount");
            dt.Columns.Add("reason");
            dt.Columns.Add("action");
            //typecash.IsOn = true;
            dt.Rows.Add(new object[] { returnno,txtinvoiceno.Text,dtpdate.Text, txtsalesperson.Text, type, CustomerId, txtcustomername.Text, txtaddress.Text, txtphone.Text,txtnetamount.Text,payamount.Text , "Changed Mind","Replacement" });
            Test.Sale.Database.SalesReturnData salesData = new Test.Sale.Database.SalesReturnData(source, dt);
            salesData.FnConn();
            salesData.fnTransactionData();
            salesData.FnTrans();
            MessageBox.Show("Return accepted", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        string type = "";
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true)
            {
                type = "Credit";

            }
            else
            {
                type = "Cash";
            }
        }
    }
}