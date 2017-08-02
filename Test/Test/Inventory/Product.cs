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
    public partial class Product : DevExpress.XtraEditors.XtraForm
    {
       
        public Product()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Product a = new New_Product();
            a.ShowDialog();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            Inventory.Database.NewProductData Pdt = new Inventory.Database.NewProductData();
            try
            {
                Pdt.FnConn();
                DataTable dt = Pdt.FillData();
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
    }
}