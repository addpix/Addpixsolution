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
    public partial class Sales_Quotation : DevExpress.XtraEditors.XtraForm
    {
        public Sales_Quotation()
        {
            InitializeComponent();
        }
        public void calculateTotal()
        {
            gridView1.RefreshData();
            DataTable source = gridControl1.DataSource as DataTable;
            double total = 0;
            for (int i = 0; i <gridView1.DataRowCount; i++)
            {
                try
                {
                  //  total = total + Convert.ToDouble(source.Rows[i]["totalamount"] + "");
                    total = total +Convert.ToDouble( gridView1.GetRowCellValue(i, "totalAmount").ToString());
                }
                catch (Exception Ex)
                {
                }
            }
            txtnetamount.Text = total+"";
        }

        private void Sales_Quotation_Load(object sender, EventArgs e)
        {
            Test.Sale.Database.QuatationData quatation = new Sale.Database.QuatationData();
            quatation.FnConn();
            DataTable dt1=quatation.FillData("M");
            String res=quatation.FnTrans();
            if (dt1.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                txtquatationnno.Text = "Quo" + number;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("slno", Type.GetType("System.Int32"));
            dt.Columns.Add("quotationNo", Type.GetType("System.String"));
            dt.Columns.Add("barcode", Type.GetType("System.String"));
            dt.Columns.Add("itemcode", Type.GetType("System.String"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("brandName", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.Double"));
            dt.Columns.Add("unitPrice", Type.GetType("System.Double"));
            dt.Columns.Add("totalAmount", Type.GetType("System.Double"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sales_Quatation_List a = new Sales_Quatation_List();
            a.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable source = gridControl1.DataSource as DataTable;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("quotationno");
            dt.Columns.Add("date");
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("address");
            dt.Columns.Add("phone");
            dt.Columns.Add("totalamount");
            dt.Rows.Add(new object[] { txtquatationnno.Text,dtpdate.Text,"cs1002",cmbcustomer.Text,txtaddress.Text,txtphone.Text,txtnetamount.Text });
            Test.Sale.Database.QuatationData quatationData = new Sale.Database.QuatationData(source,dt);
            quatationData.FnConn();
            quatationData.fnTransactionData();
            quatationData.FnTrans();

        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedColumn.FieldName.Equals("quantity"))
                {

                    System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    double quantity = 0, unitprice = 0;
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
                        unitprice = Convert.ToDouble(row["unitprice"] + "");
                    }
                    catch (Exception invalidstring)
                    {
                        row["unitprice"] = "0";
                    }
                       double total = quantity * unitprice;
                    row["totalamount"] = total + "";


                    int index=gridView1.GetFocusedDataSourceRowIndex();
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
                else if (gridView1.FocusedColumn.FieldName.Equals("unitPrice"))
                {

                    System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    double quantity = 0, unitprice = 0;
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
                        unitprice = Convert.ToDouble(row["unitprice"] + "");
                    }
                    catch (Exception invalidstring)
                    {
                        row["unitprice"] = "0";
                    }
                    double total = quantity * unitprice;
                    row["totalamount"] = total + "";
                    int index = gridView1.GetFocusedDataSourceRowIndex();
                    gridView1.RefreshRow(index);
                    calculateTotal();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            //try
            //{
            //    if (gridView1.FocusedColumn.FieldName.Equals("quantity"))
            //    {

            //        System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //        double quantity = 0, unitprice = 0;
            //        try
            //        {
            //            quantity = Convert.ToDouble(row["quantity"] + "");
            //        }
            //        catch (Exception ex1)
            //        {
            //            row["quantity"] = "0";
            //        }

            //        try
            //        {
            //            unitprice = Convert.ToDouble(row["unitprice"] + "");
            //        }
            //        catch (Exception invalidstring)
            //        {
            //            row["unitprice"] = "0";
            //        }
            //        double total = quantity * unitprice;
            //        row["totalamount"] = total + "";
            //        int index = gridView1.GetFocusedDataSourceRowIndex();
            //        gridView1.RefreshRow(index);
            //        calculateTotal();
            //        gridView1.FocusedColumn = gridView1.GetVisibleColumn(6);
            //        gridView1.FocusedRowHandle = index;
            //        gridView1.ShowEditor();
            //    }
            //    else if (gridView1.FocusedColumn.FieldName.Equals("unitPrice"))
            //    {

            //        System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //        double quantity = 0, unitprice = 0;
            //        try
            //        {
            //            quantity = Convert.ToDouble(row["quantity"] + "");
            //        }
            //        catch (Exception ex1)
            //        {
            //            row["quantity"] = "0";
            //        }

            //        try
            //        {
            //            unitprice = Convert.ToDouble(row["unitprice"] + "");
            //        }
            //        catch (Exception invalidstring)
            //        {
            //            row["unitprice"] = "0";
            //        }
            //        double total = quantity * unitprice;
            //        row["totalamount"] = total + "";
            //        int index = gridView1.GetFocusedDataSourceRowIndex();
            //        gridView1.RefreshRow(index);
            //        calculateTotal();
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
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
                   DataTable dt= quatation.FillData("barcode");
                  string res=  quatation.FnTrans();
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
                    quatation.FnConn();
                    DataTable dt = quatation.FillData("itemcode");
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
            else if (gridView1.FocusedColumn.FieldName.Equals("description"))//Don't work only for this column
            {
                TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
                if (currentEditor != null)
                {
                    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
                    quatation.FnConn();
                    DataTable dt = quatation.FillData("name");
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
        }
    }
}