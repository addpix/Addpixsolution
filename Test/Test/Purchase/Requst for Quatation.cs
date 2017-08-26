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
    public partial class Requst_for_Quatation : DevExpress.XtraEditors.XtraForm
    {
        public Requst_for_Quatation()
        {
            InitializeComponent();
        }

        private void Requst_for_Quatation_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            Purchase.database.PurchaseRequest purchaseRequest = new Purchase.database.PurchaseRequest();
            purchaseRequest.FnConn();
            DataTable dt = purchaseRequest.FillData("rqdetails", "");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
            purchaseRequest.FnTrans();
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row["status"].ToString() == "RFQ ISSUED")
            {
                MessageBox.Show("RFQ Already Created...!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String no = row["prNo"].ToString();
                New_RFQ rfq = new New_RFQ(no);
                rfq.ShowDialog();
                loadData();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_RFQ a = new New_RFQ("");
            a.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}