using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Test.Purchase
{
    public partial class Price_Update : DevExpress.XtraEditors.XtraForm
    {
        public Price_Update()
        {
            InitializeComponent();
        }

      
        private void Price_Update_Load(object sender, EventArgs e)
        {
            GridLoad();
        }

        private void GridLoad()
        {
            Inventory.Database.MRRData MRR = new Inventory.Database.MRRData(null, null);
            try
            {
                MRR.FnConn();
                DataTable dt = MRR.FillData("LoadMrr");
                gridControl1.DataSource = dt;
                MRR.FnTrans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Inventory.Database.MRRData MRR = new Inventory.Database.MRRData(null, null);
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            
            String Pdt_No = row["itemcode"].ToString();
            New_Product NewProd= new New_Product(Pdt_No, "PriceUpdate");
            NewProd.BatchID = row["purchaseOrderNo"].ToString();
            NewProd.PurRate = row["unitprice"].ToString();
            NewProd.Qty = row["quantity"].ToString();
            NewProd.Mrr_No = row["mrrNo"].ToString();
            NewProd.ShowDialog();
            GridLoad();
        }
    }
}