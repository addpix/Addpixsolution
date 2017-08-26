using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Test
{
    public partial class Product_List : DevExpress.XtraEditors.XtraForm
    {
        public Product_List()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Product_for_Discount a = new Product_for_Discount("");
            a.ShowDialog();
        }
        void loadData()
        {
            Purchase.database.discountData dis = new Purchase.database.discountData();
            dis.FnConn();
            DataTable dt = dis.FillData("productdetails", "");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
            dis.FnTrans();
        }
            
        private void Product_List_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //if (row["status"].ToString() == "PO Created")
            //{
            //    MessageBox.Show("PO Already Created...!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
                String no = row["productCode"].ToString();
                Product_for_Discount po = new Product_for_Discount(no);
                po.ShowDialog();
            loadData();
            //}
        }
    }
}