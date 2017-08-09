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
    public partial class Damage_List : DevExpress.XtraEditors.XtraForm
    {
        public Damage_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Damage a = new New_Damage();
            a.ShowDialog();
            loadData();
        }
        void loadData()
        {
            Purchase.database.DamageData damageData = new Purchase.database.DamageData();
            damageData.FnConn();
            DataTable dt = damageData.FillData("S", "", "spDamage");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
        private void Damage_List_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}