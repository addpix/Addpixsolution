using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Windows.Forms;
using Test.Inventory.Database;

namespace Test.Inventory
{
    public partial class Meterial_Receipt_Report : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        String PO_No, MrrNo;
        public Meterial_Receipt_Report(String PO,String MrrNo)
        {
            InitializeComponent();
            this.PO_No = PO;
            this.MrrNo = MrrNo;
        }

        private void LoadMRR(bool MRRDetails)
        {
            DataTable dtMrrData = null, dtMrrGrid = null;
            MRRData mrr = new MRRData(null, null);
            mrr.FnConn();
            if (!MRRDetails)
            {
                gridView1.Columns["forderqty"].Visible = false;
                dtMrrData = mrr.GetRow("PO", PO_No);
                dtMrrGrid = mrr.GetRow("POGRID", PO_No);
                
                dtMrrGrid.Columns.Add("deliveredQuantity", Type.GetType("System.Int32"));
                dtMrrGrid.Columns.Add("balanceQuantity", Type.GetType("System.Int32"));
                dtMrrGrid.Columns.Add("remark", Type.GetType("System.String"));
                
                if (dtMrrData.Rows.Count > 0)
                {
                    txtMRR_no.Text = "MRR-N0:00000" + (Convert.ToInt16(mrr.GetMaxValue()) + 1);

                    dtMRR_date.EditValue = DateTime.Now;
                    txtDel_note_no.Text = "";
                    txtReq_no.Text = dtMrrData.Rows[0]["purchaseRequestNo"] + "";
                    txtPO_no.Text = dtMrrData.Rows[0]["OrderNo"] + "";
                }
            }
            else
            {
                btnSave.Caption = "Update";
                Commen_Form.Functions.DateConverter dtc = new Commen_Form.Functions.DateConverter();
                dtMrrData = mrr.GetRow("SMRR", MrrNo);
                dtMrrGrid = mrr.GetRow("SMRRGRID", MrrNo);
                if (dtMrrData.Rows.Count > 0)
                {
                    txtStoreKeeper.Text = dtMrrData.Rows[0]["storeKeeper"] + "";
                    txtMRR_no.Text = dtMrrData.Rows[0]["mrrNo"] + "";
                    dtMRR_date.EditValue = dtc.dateconverter(dtMrrData.Rows[0]["date"] + "");
                    txtDel_note_no.Text = dtMrrData.Rows[0]["delivaryNoteNo"] + "";
                    txtReq_no.Text = dtMrrData.Rows[0]["requestNo"] + "";
                    txtPO_no.Text = dtMrrData.Rows[0]["purchaseOrderNo"] + "";
                   
                    dtMrrGrid.Columns.Add("forderqty", Type.GetType("System.Int32")).SetOrdinal(5);
                    for (int i = 0; i < dtMrrGrid.Rows.Count; i++)
                        dtMrrGrid.Rows[i]["forderqty"] = dtMrrGrid.Rows[i]["deliveredQuantity"];

                    for (int i = 0; i < dtMrrGrid.Rows.Count; i++)
                    {
                        dtMrrGrid.Rows[i]["balanceQuantity"] = "0.00";
                        dtMrrGrid.Rows[i]["deliveredQuantity"] = "0.00";
                    }
                }
            }
            dtMrrGrid.Columns.Add("slno", Type.GetType("System.Int32"));
            for (int count = 0; count < dtMrrGrid.Rows.Count; count++)
                dtMrrGrid.Rows[count]["slno"] = count + 1;

            gridControl1.DataSource = dtMrrGrid;
            mrr.FnTrans();
        }
        private void Meterial_Receipt_Report_Load(object sender, EventArgs e)
        {
            if (PO_No != null)
                LoadMRR(false);
            else if (MrrNo != null)
                LoadMRR(true);
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
            MRRGrid.Columns.Remove("slno");

            if (btnSave.Caption == "Save")
            {
                MRRData MRR = new MRRData(dtMrrData, MRRGrid);
                MRR.FnConn();
                MRR.fnTransactionData("I");
                MRR.PoStatus = "MRR Created";
                MRR.FnTrans();
                
                if (MRR.Result == "Success")
                    MessageBox.Show("MRR Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("MRR Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < MRRGrid.Rows.Count; i++)
                {
                    Int16 FOrderQty = Convert.ToInt16(MRRGrid.Rows[i]["forderqty"]);
                    Int16 DelQty = Convert.ToInt16(MRRGrid.Rows[i]["deliveredQuantity"]);
                    MRRGrid.Rows[i]["deliveredQuantity"] = (FOrderQty + DelQty) + "";
                }
                MRRGrid.Columns.Remove("forderqty");
                MRRData MRR = new MRRData(dtMrrData, MRRGrid);
                MRR.FnConn();
                MRR.fnTransactionData("U");
                MRR.FnTrans();
                if (MRR.Result == "Success")
                    MessageBox.Show("MRR Updated", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_ShownEditor(object sender, System.EventArgs e)
        {
            //ProductData Prod = new ProductData();
            //if (gridView1.FocusedColumn.FieldName.Equals("productCode"))//Don't work only for this column
            //{
            //    TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
            //    if (currentEditor != null)
            //    {
            //        AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

            //        Prod.FnConn();
            //        DataTable dt = Prod.GetDataList("spProduct", "productCode");
            //        if (dt.Rows.Count > 0)
            //        {
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                customSource.Add(dt.Rows[i][0].ToString());
            //            }
            //        }
            //        currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //        currentEditor.MaskBox.AutoCompleteCustomSource = customSource;
            //    }
            //}
            //else if (gridView1.FocusedColumn.FieldName.Equals("description"))//Don't work only for this column
            //{
            //    TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
            //    if (currentEditor != null)
            //    {
            //        AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

            //        Prod.FnConn();
            //        DataTable dt = Prod.GetDataList("spProduct", "itemName");
            //        if (dt.Rows.Count > 0)
            //        {
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                customSource.Add(dt.Rows[i][0].ToString());
            //            }
            //        }
            //        currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //        currentEditor.MaskBox.AutoCompleteCustomSource = customSource;
            //    }
            //}
        }
        
        private void gridView1_HiddenEditor(object sender, System.EventArgs e)
        {
            try
            {
                ProductData Prod = new ProductData();
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (gridView1.FocusedColumn.FieldName.Equals("deliveredQuantity"))
                {
                    int Qty = Convert.ToInt16(row["quantity"] + "");
                    int DelQty = Convert.ToInt16(row["deliveredQuantity"] + "");
                    if (gridView1.Columns["forderqty"].Visible == false)
                    {
                        row["balanceQuantity"] = (Qty - DelQty) + "";
                        row["remark"] = ((Qty - DelQty) == 0) ? "" : (Qty - DelQty) + " items Pending";
                    }
                    else
                    {
                        int fOrderQty = Convert.ToInt16(row["forderqty"] + "");
                        row["balanceQuantity"] = (Qty - (fOrderQty + DelQty)) + "";
                        row["remark"] = ((Qty - (fOrderQty + DelQty)) == 0) ? "" : (Qty - (fOrderQty + DelQty)) + " items Pending";
                    }
                }
                if (gridView1.Columns["forderqty"].Visible == false)
                {
                    int index = gridView1.GetFocusedDataSourceRowIndex();
                    gridView1.RefreshRow(index);

                    gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
                    gridView1.FocusedRowHandle = index + 1;
                    gridView1.ShowEditor();
                }
                else
                {
                    int index = gridView1.GetFocusedDataSourceRowIndex();
                    gridView1.RefreshRow(index);

                    gridView1.FocusedColumn = gridView1.GetVisibleColumn(7);
                    gridView1.FocusedRowHandle = index + 1;
                    gridView1.ShowEditor();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnNewMRR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}