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
    public partial class Purchase_Order : DevExpress.XtraEditors.XtraForm
    {
        public Purchase_Order()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_PO a = new New_PO(false,null);
            a.ShowDialog();
        }

        public void Purchase_Order_Load(object sender, EventArgs e)
        {
            Purchase.database.Rfq rfq = new Purchase.database.Rfq();
            rfq.FnConn();
            DataTable dt = rfq.FillData("rfqdetails", "");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
            rfq.FnTrans();

            Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
            po.FnConn();
            DataTable dt1 = po.FillData("podetails", "");
            if (dt1.Rows.Count > 0)
            {
                gridControl2.DataSource = dt1;
            }
            po.FnTrans();
        }

        

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row["status"].ToString() == "PO Created")
            {
                MessageBox.Show("PO Already Created...!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String no = row["rfqNo"].ToString();
                New_PO po = new New_PO(true, no);
                po.ShowDialog();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}