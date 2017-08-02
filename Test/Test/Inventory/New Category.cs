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
    public partial class New_Category : DevExpress.XtraEditors.XtraForm
    {
        public New_Category()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Test.Inventory.Database.CategoryData NewCat = new Test.Inventory.Database.CategoryData();
            NewCat.Category = txtCategory.Text;

            NewCat.FnConn();
            NewCat.fnTransactionData();
            NewCat.FnTrans();
        }
    }
}