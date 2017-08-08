using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Windows.Forms;
using Test.Inventory.Database;

namespace Test
{
    public partial class Meterial_Receipt_Report : DevExpress.XtraEditors.XtraForm
    {
        public Meterial_Receipt_Report()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dtMrrData = new DataTable();
            dtMrrData.Clear();
            dtMrrData.Columns.Add("MrrNo");
            dtMrrData.Columns.Add("StoreKeeper");
            dtMrrData.Columns.Add("Date");
            dtMrrData.Columns.Add("DelNoteNo");
            dtMrrData.Columns.Add("ReqNo");
            dtMrrData.Columns.Add("PoNo");
            dtMrrData.Rows.Add(new object[] { txtMRR_no.Text, txtStoreKeeper.Text, dtMRR_date.Text, txtDel_note_no.Text, txtReq_no.Text, txtPO_no.Text });

            gridView1.RefreshData();
            DataTable MRRGrid = gridControl1.DataSource as DataTable;

            MRRData MRR = new MRRData(dtMrrData, MRRGrid);

            MRR.FnConn();
            MRR.fnTransactionData();
            MRR.FnTrans();
            MessageBox.Show(MRR.Result);
        }

        private void gridView1_ShownEditor(object sender, System.EventArgs e)
        {
            ProductData Prod = new ProductData();
            if (gridView1.FocusedColumn.FieldName.Equals("ItemCode"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

                    Prod.FnConn();
                    DataTable dt = Prod.GetDataList("spProduct", "productCode");
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
            else if (gridView1.FocusedColumn.FieldName.Equals("Description"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

                    Prod.FnConn();
                    DataTable dt = Prod.GetDataList("spProduct", "itemName");
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

        private void gridView1_HiddenEditor(object sender, System.EventArgs e)
        {
            try
            {
                ProductData Prod = new ProductData();
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (gridView1.FocusedColumn.FieldName.Equals("ItemCode"))
                {
                    String itemcode = row["ItemCode"].ToString();
                    if (itemcode != "")
                    {
                        Prod.FnConn();
                        DataTable dt = Prod.GetRow("productCode",itemcode);
                        if (dt.Rows.Count > 0)
                        {
                            row["ItemCode"] = dt.Rows[0]["ItemCode"].ToString();
                            row["description"] = dt.Rows[0]["itemName"].ToString();
                            row["brandName"] = dt.Rows[0]["brandName"].ToString();
                            row["Quantity"] = "0";
                            row["DeliveredQty"] = "0";
                            row["BalanceQty"] = "0";

                        }
                    }
                }
                if (gridView1.FocusedColumn.FieldName.Equals("Description"))
                {
                    String description = row["description"].ToString();
                    if (description != "")
                    {
                        Prod.FnConn();
                        DataTable dt = Prod.GetRow("ItemName", description);
                        if (dt.Rows.Count > 0)
                        {
                            row["description"] = dt.Rows[0]["ItemName"].ToString();
                            row["itemcode"] = dt.Rows[0]["productCode"].ToString();
                            row["brandName"] = dt.Rows[0]["brandName"].ToString();
                            row["Quantity"] = "0";
                            row["DeliveredQty"] = "0";
                            row["BalanceQty"] = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}