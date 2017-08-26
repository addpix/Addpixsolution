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
    public partial class New_Lost : DevExpress.XtraEditors.XtraForm
    {
        public New_Lost()
        {
            InitializeComponent();
        }

        private void New_Lost_Load(object sender, EventArgs e)
        {
            dtpdate.EditValue = DateTime.Now;
            Purchase.database.DamageData damageData = new Purchase.database.DamageData();
            damageData.FnConn();
            DataTable dt1 = damageData.FillData("M", "", "spLost");
            if (dt1.Rows.Count > 0)
            {
                int slno = Convert.ToInt32(dt1.Rows[0][0].ToString()) + 1;
                string no = slno + "";
                txtlostno.Text = "LS"+no.PadLeft(5,'0');
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("slno", Type.GetType("System.Int32"));
            dt.Columns.Add("damageno", Type.GetType("System.String"));
            dt.Columns.Add("itemCode", Type.GetType("System.String"));
            dt.Columns.Add("itemName", Type.GetType("System.String"));
            dt.Columns.Add("brandName", Type.GetType("System.String"));
            dt.Columns.Add("category", Type.GetType("System.String"));
            dt.Columns.Add("realqty", Type.GetType("System.Double"));
            dt.Columns.Add("lostqty", Type.GetType("System.Double"));
            dt.Columns.Add("balanceqty", Type.GetType("System.Double"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
            damageData.FnTrans();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.RefreshData();
            DataTable source = gridControl1.DataSource as DataTable;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("lostNo");
            dt.Columns.Add("date");
            dt.Columns.Add("remark");
            dt.Columns.Add("username");
            dt.Rows.Add(new object[] { txtlostno.Text, dtpdate.Text, txtremark.Text, txtuser.Text });
            Purchase.database.LostData damageData = new Purchase.database.LostData(source, dt);
            damageData.FnConn();
            damageData.fnTransactionData();
            damageData.FnTrans();
            MessageBox.Show("Lost list updated", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {
                int slno = gridView1.GetFocusedDataSourceRowIndex();
                Test.Sale.Database.SalesData quatation = new Sale.Database.SalesData();
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["slno"] = (slno + 1) + "";
                if (gridView1.FocusedColumn.FieldName.Equals("itemCode"))
                {
                    String itemcode = row["itemcode"].ToString();
                    if (itemcode != "")
                    {
                        quatation.FnConn();
                        DataTable dt = quatation.FillData("stock", itemcode, "spsales");
                        if (dt.Rows.Count > 0)
                        {
                            //row["barcode"] = dt.Rows[0]["qrCode"].ToString();
                            row["itemName"] = dt.Rows[0]["itemName"].ToString();
                            row["brandName"] = dt.Rows[0]["brandName"].ToString();
                            row["realqty"] = dt.Rows[0]["currentstock"].ToString();
                            row["category"] = dt.Rows[0]["category"].ToString();
                            row["lostqty"] = "0";
                            row["balanceqty"] = "0";
                        }
                    }
                }
                if (gridView1.FocusedColumn.FieldName.Equals("itemName"))
                {
                    String itemcode = row["itemName"].ToString();
                    if (itemcode != "")
                    {
                        quatation.FnConn();
                        DataTable dt = quatation.FillData("stockname", itemcode, "spsales");
                        if (dt.Rows.Count > 0)
                        {
                            //row["barcode"] = dt.Rows[0]["qrCode"].ToString();
                            row["itemCode"] = dt.Rows[0]["productCode"].ToString();
                            row["brandName"] = dt.Rows[0]["brandName"].ToString();
                            row["realqty"] = dt.Rows[0]["currentstock"].ToString();
                            row["category"] = dt.Rows[0]["category"].ToString();
                            row["lostqty"] = "0";
                            row["balanceqty"] = "0";
                        }
                    }
                }
                if (gridView1.FocusedColumn.FieldName.Equals("lostqty"))
                {
                    double damageqty = 0, qty = 0;
                    try
                    {
                        damageqty = Convert.ToDouble(row["lostqty"].ToString());
                    }
                    catch (Exception ex)
                    {
                        row["lostqty"] = "0";
                    }
                    try
                    {
                        qty = Convert.ToDouble(row["realqty"].ToString());
                    }
                    catch (Exception ex)
                    {
                        row["realqty"] = "0";
                    }
                    double balance = qty - damageqty;
                    row["balanceqty"] = balance + "";
                }
            }
            catch (Exception ex)
            {


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

                    currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    currentEditor.MaskBox.AutoCompleteCustomSource = customSource;
                }
            }
            else if (gridView1.FocusedColumn.FieldName.Equals("itemName"))//Don't work only for this column
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
            else if (gridView1.FocusedColumn.FieldName.Equals("lostqty"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
                    quatation.FnConn();
                    //DataTable dt = quatation.FillData("name", "");
                    // string res = quatation.FnTrans();
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
            if (gridView1.FocusedColumn.FieldName.Equals("lostqty"))
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataTable source = gridControl1.DataSource as DataTable;
                source.Clear();
                gridControl1.DataSource = source;
                dtpdate.EditValue = DateTime.Now;
                Purchase.database.DamageData damageData = new Purchase.database.DamageData();
                damageData.FnConn();
                DataTable dt1 = damageData.FillData("M", "", "spLost");
                damageData.FnTrans();
                if (dt1.Rows.Count > 0)
                {
                    int slno = Convert.ToInt32(dt1.Rows[0][0].ToString()) + 1;
                    string no = slno + "";
                    txtlostno.Text = "LS" + no.PadLeft(5, '0');
                }
                txtremark.Text = "";
                txtuser.Text = "";
            }
            catch (Exception ex) { }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}