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
    public partial class Purchase_Requst : DevExpress.XtraEditors.XtraForm
    {
        public Purchase_Requst()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Add_Items a = new Add_Items();
            a.ShowDialog();
        }

        private void Purchase_Requst_Load(object sender, EventArgs e)
        {
            Test.Purchase.database.PurchaseRequest pr = new Purchase.database.PurchaseRequest();
            pr.FnConn();

            DataTable dt1 = pr.FillData("M", "");
            String res = pr.FnTrans();

            DataTable dt = new DataTable();

            if (dt1.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                txtPRNo.Text = "P" + number;
            }

            dt.Columns.Add("slno", Type.GetType("System.Int32"));
            dt.Columns.Add("itemcode", Type.GetType("System.String"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("brand", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.Int32"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.RefreshDataSource();
            DataTable source = gridControl1.DataSource as DataTable;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("No");
            dt.Columns.Add("prNo");
            dt.Columns.Add("requester");
            dt.Columns.Add("location");
            dt.Columns.Add("date");
            dt.Rows.Add(new object[] { "11", txtPRNo.Text, txtRequester.Text, txtLocation.Text, datePOdate.Text, });
            Test.Purchase.database.PurchaseRequest purchase = new Purchase.database.PurchaseRequest(source, dt);
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
                        DataTable dt = po.FillData("description", description);
                        if (dt.Rows.Count > 0)
                        {
                            row["itemcode"] = dt.Rows[0]["productCode"].ToString();
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
            Test.Purchase.database.PurchaseRequest po = new Purchase.database.PurchaseRequest();

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