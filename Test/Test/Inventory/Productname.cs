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
    public partial class Productname : DevExpress.XtraEditors.XtraForm
    {
        public Productname()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Newbrand a = new Newbrand();
            a.ShowDialog();
        }

        private void Productname_Load(object sender, EventArgs e)
        {
            Test.Inventory.Database.NewBrandData Brand = new Inventory.Database.NewBrandData();
            try
            {
                Brand.FnConn();
                DataTable dt = Brand.FillData();
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
    }
}