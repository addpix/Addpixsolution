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
    public partial class Sales_Invoice_View : DevExpress.XtraEditors.XtraForm
    {
        public Sales_Invoice_View()
        {
            InitializeComponent();
        }

        private void Sales_Invoice_View_Load(object sender, EventArgs e)
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