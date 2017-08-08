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
            Sales_Return a = new Sales_Return();
            a.ShowDialog();
        }

        private void Sales_History_Load(object sender, EventArgs e)
        {
            Sale.Database.SalesData salesData = new Sale.Database.SalesData();
            salesData.FnConn();
            DataTable dt= salesData.FillData("s", "", "spsales");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
    }
}