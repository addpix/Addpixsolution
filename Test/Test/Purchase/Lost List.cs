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
    public partial class Lost_List : DevExpress.XtraEditors.XtraForm
    {
        public Lost_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Lost a = new New_Lost();
            a.ShowDialog();
            loadData();
        }
        void loadData()
        {
            Purchase.database.LostData damageData = new Purchase.database.LostData();
            damageData.FnConn();
            DataTable dt = damageData.FillData("S", "", "spLost");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
        private void Lost_List_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}