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
        }
    }
}