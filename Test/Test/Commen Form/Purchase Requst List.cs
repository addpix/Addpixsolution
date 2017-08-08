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
    public partial class Purchase_Requst_List : DevExpress.XtraEditors.XtraForm
    {
        public Purchase_Requst_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Purchase_Requst a = new Purchase_Requst();
            a.ShowDialog();
        }

        private void Purchase_Requst_List_Load(object sender, EventArgs e)
        {
            Purchase.database.PurchaseRequest purchaseRequest = new Purchase.database.PurchaseRequest();
            purchaseRequest.FnConn();
            DataTable dt= purchaseRequest.FillData("rqdetails", "");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
    }
}