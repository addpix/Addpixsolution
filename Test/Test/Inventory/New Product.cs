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
        NewCategoryData NewCat = new NewCategoryData();
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

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewCat.ProdCode = txtProduct_code.Text;
            NewCat.ItemName = txtItem_name.Text;
            NewCat.UnitMeasure = cmbUnit.Text;
            NewCat.BrandName = cmbBrand_name.Text;
            NewCat.Category = cmbItem_category.Text;
            NewCat.TaxCategory = cmbTax_category.Text;
            NewCat.PurchaseTax = cmbPurchase_Tax.Text;
            NewCat.SalesTax = cmbSales_tax.Text;
            NewCat.PurchaseRate = txtPurchase_rate.Text;
            NewCat.OpeningStock = txtOpening_stock.Text;
            NewCat.ReoderQty = txtReorder_qty.Text;
            NewCat.MinQty = txtMin_qty.Text;
            NewCat.SalesRate1 = txtSales_rate1.Text;
            NewCat.SalesRate2 = txtSales_rate2.Text;
            NewCat.SalesRate3 = txtSales_rate3.Text;
            NewCat.BatchName = txtBatch_name.Text;
            NewCat.MfgDate = dtMfg_date.Text;
            NewCat.ExpDate = dtExp_date.Text;
            NewCat.WarrantyDetails = memWarranty.Text;
            NewCat.Location = txtProduct_code.Text;

            NewCat.FnConn();
            NewCat.fnTransactionData();
            NewCat.FnTrans();
        }
    }
}