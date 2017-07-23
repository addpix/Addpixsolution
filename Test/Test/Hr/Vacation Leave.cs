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
    public partial class Vacation_Leave : DevExpress.XtraEditors.XtraForm
    {
        public Vacation_Leave()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vacation_Requst a = new Vacation_Requst();
            a.ShowDialog();
        }
    }
}