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
    public partial class Sales_Quotation : DevExpress.XtraEditors.XtraForm
    {
        public Sales_Quotation()
        {
            InitializeComponent();
        }

        private void Sales_Quotation_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sales_Quatation_List a = new Sales_Quatation_List();
            a.ShowDialog();
        }
    }
}