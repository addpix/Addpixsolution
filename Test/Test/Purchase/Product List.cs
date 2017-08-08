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
    public partial class Product_List : DevExpress.XtraEditors.XtraForm
    {
        public Product_List()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Product_for_Discount a = new Product_for_Discount();
            a.ShowDialog();
        }

        private void Product_List_Load(object sender, EventArgs e)
        {

        }
    }
}