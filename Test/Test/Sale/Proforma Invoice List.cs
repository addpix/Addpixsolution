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
    public partial class Proforma_Invoice_List : DevExpress.XtraEditors.XtraForm
    {
        public Proforma_Invoice_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Proforma_Invoice a = new Proforma_Invoice();
            a.ShowDialog();
            loaddata();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void loaddata()
        {
            Sale.Database.PerformanceInvoiceData pi = new Sale.Database.PerformanceInvoiceData();
            pi.FnConn();
            DataTable dt = pi.FillData("S", "", "spperformanceInvoice");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
        private void Proforma_Invoice_List_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string deliveryNo = row["pinvoice_no"].ToString();
                Proforma_Invoice deliveryNote = new Proforma_Invoice();
                deliveryNote.proinvoiceno = deliveryNo;
                deliveryNote.ShowDialog();
                loaddata();

            }
            catch (Exception) { }
        }
    }
}