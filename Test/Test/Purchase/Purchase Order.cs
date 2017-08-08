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
    public partial class Purchase_Order : DevExpress.XtraEditors.XtraForm
    {
        public Purchase_Order()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_PO a = new New_PO();
            a.ShowDialog();
        }

        private void Purchase_Order_Load(object sender, EventArgs e)
        {

        }
    }
}