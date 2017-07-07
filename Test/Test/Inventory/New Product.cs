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
    public partial class New_Product : DevExpress.XtraEditors.XtraForm
    {
        public New_Product()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Newbrand a = new Newbrand();
            a.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            New_Category a = new New_Category();
            a.ShowDialog();
        }
    }
}