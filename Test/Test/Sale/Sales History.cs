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
    public partial class Sales_History : DevExpress.XtraEditors.XtraForm
    {
        public Sales_History()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
        void loadData()
        {
            Sale.Database.SalesData salesData = new Sale.Database.SalesData();
            salesData.FnConn();
            DataTable dt = salesData.FillData("invlist", "", "spsalesReturn");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
            salesData.FnTrans();
        }
        private void Sales_History_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                Sales_Return salereturn = new Sales_Return();
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string invoiceno = row["invoice_no"].ToString();
                salereturn.Invoiceno = invoiceno;
                salereturn.ShowDialog();
                loadData();
            }
            catch (Exception ex)
            {

            }
        }
    }
}