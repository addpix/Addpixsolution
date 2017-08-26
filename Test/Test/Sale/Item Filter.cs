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
    public partial class Item_Filter : DevExpress.XtraEditors.XtraForm
    {
        public string itemcode { get; set; }
        public string qrcode { get; set; }
        public Item_Filter()
        {
            InitializeComponent();
        }

        private void Item_Filter_Load(object sender, EventArgs e)
        {
            Sale.Database.SalesData salesdata = new Sale.Database.SalesData();
            salesdata.FnConn();
            DataTable dt= salesdata.FillData("stockqr", qrcode, "spsales");
            salesdata.FnTrans();
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
    }
}