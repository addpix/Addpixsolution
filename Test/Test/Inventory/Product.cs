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
            New_Product a = new New_Product(null, null);
            a.ShowDialog();
            Inventory.Database.ProductData Pdt = new Inventory.Database.ProductData();
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

        private void Product_Load(object sender, EventArgs e)
        {
            Inventory.Database.ProductData Pdt = new Inventory.Database.ProductData();
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string ProductCode = row["productCode"].ToString();
            New_Product NewProd = new New_Product(ProductCode, "Product");
            NewProd.ShowDialog();

            Inventory.Database.ProductData Prod = new Inventory.Database.ProductData();
            try
            {
                Prod.FnConn();
                DataTable dtProd = Prod.FillData();
                gridControl1.DataSource = dtProd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}