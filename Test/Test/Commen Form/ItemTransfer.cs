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
    public partial class ItemTransfer : DevExpress.XtraEditors.XtraForm
    {
        public ItemTransfer()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Requst a = new Requst();
            a.ShowDialog();
        }

        private void ItemTransfer_Load(object sender, EventArgs e)
        {

        }
    }
}