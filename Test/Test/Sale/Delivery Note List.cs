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
    public partial class Delivery_Note_List : DevExpress.XtraEditors.XtraForm
    {
        public Delivery_Note_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delivery_Note a = new Delivery_Note();
            a.ShowDialog();
            loadData();
        }
        void loadData()
        {
            Sale.Database.SalesDeliveryData salesDeliveryData = new Sale.Database.SalesDeliveryData();
            salesDeliveryData.FnConn();
            DataTable dt = salesDeliveryData.FillData("S", "", "spsalesDelivery");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
            salesDeliveryData.FnTrans();
        }
        private void Delivery_Note_List_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}