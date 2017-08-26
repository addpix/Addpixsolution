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
        bool flag;
        string no;
        public Purchase_Requst(Boolean flag, string no)
        {
            InitializeComponent();
            this.flag = flag;
            this.no = no;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Add_Items a = new Add_Items();
                a.ShowDialog();
                DataTable source = gridControl1.DataSource as DataTable;
                List<System.Data.DataRow> removeRowIndex = new List<System.Data.DataRow>();

                foreach (DataRow dr1 in source.Rows)
                {
                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        if (dr1[i] == DBNull.Value)
                        {
                            removeRowIndex.Add(dr1);
                            break;
                        }
                        else if (string.IsNullOrEmpty(dr1[i].ToString().Trim()))
                        {
                            removeRowIndex.Add(dr1);
                            break;
                        }

                    }
                }
                foreach (System.Data.DataRow rowIndex in removeRowIndex)
                {
                    source.Rows.Remove(rowIndex);
                }

                DataTable dt = gridControl1.DataSource as DataTable;
                for (int i = 0; i < a.Dgv.Rows.Count; i++)
                {
                    dt.Rows.Add("1", a.Dgv.Rows[i]["productCode"] + "", a.Dgv.Rows[i]["itemName"] + "", a.Dgv.Rows[i]["brandName"] + "", "1");
                }
                for (int i = 0; i < source.Rows.Count; i++)
                {
                    source.Rows[i]["slno"] = (i + 1) + "";
                }
            }
            catch (Exception)
            {

            }
        }
        int number = 0;
        private void Purchase_Requst_Load(object sender, EventArgs e)
        {
            Test.Purchase.database.PurchaseRequest pr = new Purchase.database.PurchaseRequest();
            pr.FnConn();

            if (flag == true)
            {

                btnSave.Caption = "Update";
                DataTable dt = pr.FillData("updatedata",no);
                DataTable dt1 = pr.FillData("updategrd", no);

                gridControl1.DataSource = dt1;
                txtLocation.Text = dt.Rows[0]["location"]+"";
                txtPRNo.Text = dt.Rows[0]["prNo"]+"";
                txtRequester.Text = dt.Rows[0]["requester"]+"";
                Test.Commen_Form.Functions.DateConverter c = new Commen_Form.Functions.DateConverter();
                datePOdate.EditValue = c.dateconverter(dt.Rows[0]["date"]+"");

            }
            else
            {
                btnSave.Caption = "Save";
                DataTable dt1 = pr.FillData("M", "");
                String res = pr.FnTrans();

                DataTable dt = new DataTable();

                if (dt1.Rows.Count > 0)
                {
                    number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                    string invoiceno = number + "";
                    txtPRNo.Text = "PR/" + invoiceno.PadLeft(5, '0');
                }

                dt.Columns.Add("slno", Type.GetType("System.Int32"));
                dt.Columns.Add("itemNo", Type.GetType("System.String"));
                dt.Columns.Add("description", Type.GetType("System.String"));
                dt.Columns.Add("brand", Type.GetType("System.String"));
                dt.Columns.Add("quantity", Type.GetType("System.Int32"));
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                gridControl1.DataSource = dt;
                datePOdate.EditValue = DateTime.Now;
            }
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSave.Enabled = false;
            gridControl1.RefreshDataSource();
            DataTable source = gridControl1.DataSource as DataTable;
            var emptyrows = source.AsEnumerable()
                                   .All(r => r.ItemArray.All(x => x == DBNull.Value));

            if (!emptyrows && txtLocation.Text.Length!=0 && txtPRNo.Text.Length!=0 && txtRequester.Text.Length!=0 )
            {
                DataTable dt = new DataTable();
                
                dt.Clear();
                dt.Columns.Add("prNo");
                dt.Columns.Add("requester");
                dt.Columns.Add("location");
                dt.Columns.Add("date");
                dt.Rows.Add(new object[] {txtPRNo.Text, txtRequester.Text, txtLocation.Text,datePOdate.Text });
                Test.Purchase.database.PurchaseRequest purchase = new Purchase.database.PurchaseRequest(source, dt);
                purchase.FnConn();
                if(btnSave.Caption=="Save")
                {
                    purchase.fnTransactionData("I",txtPRNo.Text);
                    purchase.updatStatus("updateStatus", txtPRNo.Text,"PR Created");
                }
                else
                {
                    purchase.fnTransactionData("U", txtPRNo.Text);
                }
                purchase.FnTrans();
                MessageBox.Show("PR CREATED.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {
                int slno = gridView1.GetFocusedDataSourceRowIndex();
                Test.Purchase.database.PurchaseRequest pr = new Purchase.database.PurchaseRequest();
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["slno"] = (slno + 1) + "";



                if (gridView1.FocusedColumn.FieldName.Equals("itemNo"))
                {
                    String itemcode = row["itemNo"].ToString();
                    if (itemcode != "")
                    {
                        pr.FnConn();
                        DataTable dt = pr.FillData("itemdetails", itemcode);
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
                        pr.FnConn();
                        DataTable dt = pr.FillData("desdetails", description);
                        if (dt.Rows.Count > 0)
                        {
                            row["itemNo"] = dt.Rows[0]["productCode"].ToString();
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

            if (gridView1.FocusedColumn.FieldName.Equals("itemNo"))//Don't work only for this column
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
                    DataTable dt = po.FillData("itemname", "");
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

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataTable source = gridControl1.DataSource as DataTable;
                source.Clear();
                gridControl1.DataSource = source;
                txtLocation.Text = "";
                txtRequester.Text = "";
                datePOdate.EditValue = DateTime.Now;
                Test.Purchase.database.PurchaseRequest pr = new Purchase.database.PurchaseRequest();
                pr.FnConn();
                DataTable dt1 = pr.FillData("M", "");
                if (dt1.Rows.Count > 0)
                {
                    number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                    string invoiceno = number + "";
                    txtPRNo.Text = "PR-NO:"+ invoiceno.PadLeft(5, '0');
                }
                btnSave.Enabled = true;
            }
            catch (Exception)
            {
                
            }
            
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}