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
    public partial class Newbrand : DevExpress.XtraEditors.XtraForm
    {
        public Newbrand()
        {
            InitializeComponent();
        }

        private void Newbrand_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Inventory.Database.NewBrandData NewBrand = new Inventory.Database.NewBrandData();
            NewBrand.Brand = txtBrand.Text;
            NewBrand.Vendor = cmbVendor.Text;

            NewBrand.FnConn();
            NewBrand.fnTransactionData();
            NewBrand.FnTrans();

            MessageBox.Show(NewBrand.Result);

        }

    }
}