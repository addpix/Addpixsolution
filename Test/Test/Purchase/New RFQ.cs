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
    public partial class New_RFQ : DevExpress.XtraEditors.XtraForm
    {
        public New_RFQ()
        {
            InitializeComponent();
        }
        string vendorId1 = "", vendorId2 = "", vendorId3 = "";



        private void New_RFQ_Load(object sender, EventArgs e)
        {
            Test.Purchase.database.Rfq pr = new Purchase.database.Rfq();
            pr.FnConn();

            DataTable dt1 = pr.FillData("M", "");


            DataTable dt = new DataTable();

            if (dt1.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                txtRFQNO.Text = "RFQ" + number;
            }

            dt.Columns.Add("No", Type.GetType("System.Int32"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("brand", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.Int32"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
            cmbVendor1.Properties.Items.Clear();
            cmbVendor2.Properties.Items.Clear();
            cmbVendor3.Properties.Items.Clear();

            DataTable dtc1 = pr.FillData("SC", "");

            foreach (DataRow dr1 in dtc1.Rows)
            {
                cmbVendor1.Properties.Items.Add(dr1["name"] + "");
                cmbVendor2.Properties.Items.Add(dr1["name"] + "");
                cmbVendor3.Properties.Items.Add(dr1["name"] + "");
            }


            String res = pr.FnTrans();
        }

       

        private void cmbVendor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendor1.Text != "")
            {
                Test.Purchase.database.Rfq pr = new Purchase.database.Rfq();
                pr.FnConn();
                DataTable dt = pr.FillData("S", cmbVendor1.Text);
                if (dt.Rows.Count > 0)
                {
                    vendorId1 = dt.Rows[0]["supplierId"].ToString();
                    txtAddress1.Text = dt.Rows[0]["address"].ToString();
                    txtPh1.Text = dt.Rows[0]["phoneNumber"].ToString();
                }
            }
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {
                int slno = gridView1.GetFocusedDataSourceRowIndex();
                Test.Purchase.database.Rfq po = new Purchase.database.Rfq();
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["No"] = (slno + 1) + "";



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
                            row["quantity"] = "1";
                        }
                    }
                }
                else if (gridView1.FocusedColumn.FieldName.Equals("description"))
                {
                    String description = row["description"].ToString();
                    if (description != "")
                    {
                        po.FnConn();
                        DataTable dt = po.FillData("itemdetails", description);
                        if (dt.Rows.Count > 0)
                        {
                            row["brand"] = dt.Rows[0]["brandName"].ToString();
                            row["quantity"] = "1";
                        }
                    }
                }

            }
            catch (Exception)
            {


            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            Test.Purchase.database.Rfq po = new Purchase.database.Rfq();

            if (gridView1.FocusedColumn.FieldName.Equals("description"))//Don't work only for this column
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

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.RefreshDataSource();
            DataTable source = gridControl1.DataSource as DataTable;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("slno");
            dt.Columns.Add("RFQNo");
            dt.Columns.Add("ourchaseOrderNo");
            dt.Columns.Add("date");
            dt.Columns.Add("requester");
            dt.Columns.Add("vendor1");
            dt.Columns.Add("address1");
            dt.Columns.Add("ph1");
            dt.Columns.Add("vendor2");
            dt.Columns.Add("address2");
            dt.Columns.Add("ph2");
            dt.Columns.Add("vendor3");
            dt.Columns.Add("address3");
            dt.Columns.Add("ph3");
            dt.Columns.Add("vendoeId1");
            dt.Columns.Add("vendoeId2");
            dt.Columns.Add("vendoeId3");
            dt.Rows.Add(new object[] { "11", txtRFQNO.Text, txtPO.Text, dateRFQdate.Text, txtRequster.Text,cmbVendor1.Text,txtAddress1.Text,txtPh1.Text,cmbVendor2.Text,txtAddress2.Text,txtPh2.Text,cmbVendor3.Text,txtAddress3.Text,txtPh3.Text,vendorId1,vendorId2,vendorId3 });
            Test.Purchase.database.Rfq rfq = new Purchase.database.Rfq(source, dt);
            rfq.FnConn();
            rfq.fnTransactionData();
            rfq.FnTrans();
        }

        private void cmbVendor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendor2.Text != "")
            {
                Test.Purchase.database.Rfq pr = new Purchase.database.Rfq();
                pr.FnConn();
                DataTable dt = pr.FillData("S", cmbVendor2.Text);
                if (dt.Rows.Count > 0)
                {
                    vendorId2 = dt.Rows[0]["supplierId"].ToString();
                    txtAddress2.Text = dt.Rows[0]["address"].ToString();
                    txtPh2.Text = dt.Rows[0]["phoneNumber"].ToString();
                }
            }
        }

        private void cmbVendor3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendor3.Text != "")
            {
                Test.Purchase.database.Rfq pr = new Purchase.database.Rfq();
                pr.FnConn();
                DataTable dt = pr.FillData("S", cmbVendor2.Text);
                if (dt.Rows.Count > 0)
                {
                    vendorId3 = dt.Rows[0]["supplierId"].ToString();
                    txtAddress3.Text = dt.Rows[0]["address"].ToString();
                    txtPh3.Text = dt.Rows[0]["phoneNumber"].ToString();
                }
            }
        }
    }
}