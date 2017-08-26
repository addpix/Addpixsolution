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
    public partial class MRR : DevExpress.XtraEditors.XtraForm
    {
        public MRR()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
            //Purchase.Price_Update pr = new Purchase.Price_Update();
            //pr.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Inventory.Meterial_Receipt_Report a = new Inventory.Meterial_Receipt_Report(null, null);
            a.ShowDialog();
            loadData();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            string PO_No = row["orderNo"].ToString();
            Inventory.Meterial_Receipt_Report NewMrr = new Inventory.Meterial_Receipt_Report(PO_No, null);
            if (row["status"] + "" != "MRR Created")
            {
                NewMrr.ShowDialog();
                loadData();
            }
            else
                MessageBox.Show("Purchase Order Closed...\nMRR Already Created");
            NewMrr.ShowDialog();
            loadData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string Mrr_No = row["mrrNo"].ToString();
            Inventory.Meterial_Receipt_Report NewMrr = new Inventory.Meterial_Receipt_Report(null, Mrr_No);
            NewMrr.ShowDialog();
            loadData();
        }
        void loadData()
        {
            Inventory.Database.MRRData MRR = new Inventory.Database.MRRData(null, null);
            // Purchase.database.PurchaseOrder PO = new Purchase.database.PurchaseOrder();
            try
            {

                MRR.FnConn();
                DataTable dt = MRR.FillData("S");
                if (dt.Rows.Count > 0)
                    gridControl1.DataSource = dt;

                DataTable dt1 = MRR.FillData("SPO");
                if (dt1.Rows.Count > 0)
                    gridControl2.DataSource = dt1;
                MRR.FnTrans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void MRR_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}