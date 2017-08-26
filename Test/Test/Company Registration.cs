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
    public partial class Company_Registration : DevExpress.XtraEditors.XtraForm
    {
        public Company_Registration()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Create_Location cl = new Create_Location();
            cl.ShowDialog();
            this.Close();
        }
    }
}