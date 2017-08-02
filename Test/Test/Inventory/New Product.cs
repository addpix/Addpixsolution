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
using Test.Inventory.Database;

namespace Test
{
    public partial class New_Product : DevExpress.XtraEditors.XtraForm
    {
        NewProductData NewProd = new NewProductData();
        public New_Product()
        {
            InitializeComponent();
        }
        
        private void btnNew_brand_Click(object sender, EventArgs e)
        {
            Newbrand a = new Newbrand();
            a.ShowDialog();
        }

        private void btnNew_category_Click(object sender, EventArgs e)
        {
            New_Category a = new New_Category();
            a.ShowDialog();
        }

        private void New_Product_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewProd.ProdCode = txtProduct_code.Text;
            NewProd.QRCode = txtQRCode.Text;
            NewProd.ItemName = txtItem_name.Text;
            NewProd.UnitMeasure = cmbUnit.Text;
            NewProd.BrandName = cmbBrand_name.Text;
            NewProd.Category = cmbItem_category.Text;
            NewProd.TaxCategory = cmbTax_category.Text;
            NewProd.PurchaseTax = cmbPurchase_Tax.Text;
            NewProd.SalesTax = cmbSales_tax.Text;
            NewProd.PurchaseRate = txtPurchase_rate.Text;
            NewProd.OpeningStock = txtOpening_stock.Text;
            NewProd.ReoderQty = txtReorder_qty.Text;
            NewProd.MinQty = txtMin_qty.Text;
            NewProd.SalesRate1 = txtSales_rate1.Text;
            NewProd.SalesRate2 = txtSales_rate2.Text;
            NewProd.SalesRate3 = txtSales_rate3.Text;
            NewProd.BatchName = txtBatch_name.Text;
            NewProd.MfgDate = dtMfg_date.Text;
            NewProd.ExpDate = dtExp_date.Text;
            NewProd.WarrantyDetails = memWarranty.Text;
            NewProd.Location = txtProduct_code.Text;

            NewProd.FnConn();
            NewProd.fnTransactionData();
            NewProd.FnTrans();
            MessageBox.Show(NewProd.Result);
        }
    }
}