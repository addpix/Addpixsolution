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
    public partial class Purchase_Requst : DevExpress.XtraEditors.XtraForm
    {
        public Purchase_Requst()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Add_Items a = new Add_Items();
            a.ShowDialog();
        }
    }
}