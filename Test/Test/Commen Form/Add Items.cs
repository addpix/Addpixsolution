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
    public partial class Add_Items : DevExpress.XtraEditors.XtraForm
    {
        public Add_Items()
        {
            InitializeComponent();
        }

        private void Add_Items_Load(object sender, EventArgs e)
        {
            Sale.Database.SalesData salesData = new Sale.Database.SalesData();
            salesData.FnConn();
            DataTable dt = salesData.FillData("currentstock", "", "spsales");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
    }
}