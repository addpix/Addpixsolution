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
using DevExpress.XtraEditors.DXErrorProvider;
namespace Test
{
    public partial class New_Product : DevExpress.XtraEditors.XtraForm
    {
        ProductData NewProd = new ProductData();
        String ProdCode, FormName, Pdt_No=null;
        public String BatchID = "", PurRate = "", Qty = "", Mrr_No = "";
        public New_Product(String ProdCode, String FormName)
        {
            InitializeComponent();
            this.ProdCode = ProdCode;
            this.FormName = FormName;
        }
        private void InitValidationRules()
        {
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "Please enter a value";
            //..
            dxValidationProvider1.SetValidationRule(txtItem_name, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(cmbUnit, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(cmbItem_category, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(txtBatch_name, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(cmbLocation, notEmptyValidationRule);
        }
        private void btnNew_brand_Click(object sender, EventArgs e)
        {
            Newbrand a = new Newbrand(null);
            a.ShowDialog();
            ItemsLoad();
        }

        private void btnNew_category_Click(object sender, EventArgs e)
        {
            New_Category a = new New_Category();
            a.ShowDialog();
            ItemsLoad();
        }

        private void New_Product_Load(object sender, EventArgs e)
        {
            try
            {
                cmbSales_tax.Enabled = false;
                cmbPurchase_Tax.Enabled = false;
                cmbTax_category.Text = "Non Tax";
                cmbSales_tax.Text = "0";
                cmbPurchase_Tax.Text = "0";
                ItemsLoad();
                LoadData();

            }
            catch(Exception ex)
            { }
        }

        public void ItemsLoad()
        {
            cmbUnit.Properties.Items.Clear();
            cmbBrand_name.Properties.Items.Clear();
            cmbItem_category.Properties.Items.Clear();

            ProductData Prod = new ProductData();
            Prod.FnConn();
            txtProduct_code.Text = "ID-C:000000" + (Convert.ToInt16(Prod.GetMaxValue()) + 1);
            Prod.FnTrans();

            //Combobox UM
            CreateUMData UM = new CreateUMData();
            UM.FnConn();
            DataTable dtUM = UM.FillData();
            UM.FnTrans();

            foreach (DataRow dr in dtUM.Rows)
                cmbUnit.Properties.Items.Add(dr["unitName"] + "");

            //Combobox Brand
            NewBrandData NewBrand = new NewBrandData();
            NewBrand.FnConn();
            DataTable dtBrand = NewBrand.FillData();
            NewBrand.FnTrans();

            foreach (DataRow dr in dtBrand.Rows)
                cmbBrand_name.Properties.Items.Add(dr["brandName"] + "");

            //Combobox Category
            CategoryData Cat = new CategoryData();
            Cat.FnConn();
            DataTable dtCat = Cat.FillData();
            Cat.FnTrans();

            foreach (DataRow dr in dtCat.Rows)
                cmbItem_category.Properties.Items.Add(dr["category"] + "");
        }
        public void LoadData()
        {
            if (ProdCode != null)
            {
                ProductData Prod = new ProductData();
                Prod.FnConn();
                DataTable dtProd = new DataTable();
                dtProd = Prod.GetRow(ProdCode);

                if (FormName == "Product")
                {
                    btnSave.Caption = "Update";
                    Commen_Form.Functions.DateConverter Conv = new Commen_Form.Functions.DateConverter();
                    
                    if (dtProd.Rows.Count > 0)
                    {
                        txtProduct_code.Text = dtProd.Rows[0]["productCode"] + "";
                        txtQRCode.Text = dtProd.Rows[0]["qrCode"] + "";
                        txtItem_name.Text = dtProd.Rows[0]["itemName"] + "";
                        cmbUnit.Text = dtProd.Rows[0]["unitMeasure"] + "";
                        cmbBrand_name.Text = dtProd.Rows[0]["brandName"] + "";
                        cmbItem_category.Text = dtProd.Rows[0]["category"] + "";
                        cmbTax_category.Text = dtProd.Rows[0]["taxCategory"] + "";
                        cmbPurchase_Tax.Text = dtProd.Rows[0]["taxOnPurchase"] + "";
                        cmbSales_tax.Text = dtProd.Rows[0]["taxOnSale"] + "";
                        txtPurchase_rate.Text = dtProd.Rows[0]["purchaseRate"] + "";
                        txtOpening_stock.Text = dtProd.Rows[0]["openingStock"] + "";
                        txtReorder_qty.Text = dtProd.Rows[0]["reorderQuantity"] + "";
                        txtMin_qty.Text = dtProd.Rows[0]["minimumQuantity"] + "";
                        txtSales_rate1.Text = dtProd.Rows[0]["salesRate1"] + "";
                        txtSales_rate2.Text = dtProd.Rows[0]["salesRate2"] + "";
                        txtSales_rate3.Text = dtProd.Rows[0]["salesRate3"] + "";
                        txtBatch_name.Text = dtProd.Rows[0]["batchName"] + "";
                        dtMfg_date.Text = Conv.dateconverter(dtProd.Rows[0]["mfgDate"] + "");
                        dtExp_date.Text = Conv.dateconverter(dtProd.Rows[0]["expDate"] + "");
                        memWarranty.Text = dtProd.Rows[0]["warrentyDetails"] + "";
                        cmbLocation.Text = dtProd.Rows[0]["location"] + "";
                    }
                }
                else
                {
                    if (dtProd.Rows.Count > 0)
                    {
                        txtProduct_code.Text = "ID-C:000000" + (Convert.ToInt16(Prod.GetMaxValue()) + 1);
                        txtQRCode.Text = dtProd.Rows[0]["qrCode"] + "";
                        txtItem_name.Text = dtProd.Rows[0]["itemName"] + "";
                        cmbUnit.Text = dtProd.Rows[0]["unitMeasure"] + "";
                        cmbBrand_name.Text = dtProd.Rows[0]["brandName"] + "";
                        cmbItem_category.Text = dtProd.Rows[0]["category"] + "";
                        txtPurchase_rate.Text = PurRate;
                        txtOpening_stock.Text = Qty;
                        txtReorder_qty.Text = dtProd.Rows[0]["reorderQuantity"] + "";
                        txtMin_qty.Text = dtProd.Rows[0]["minimumQuantity"] + "";
                        txtBatch_name.Text = BatchID;

                        Pdt_No = dtProd.Rows[0]["productCode"] + "";
                    }
                   
                }
                Prod.FnTrans();
            }
            else
                btnDelete.Enabled = false;
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtItem_name.Text != "" && cmbItem_category.Text != "" && txtOpening_stock.Text != "")
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
                NewProd.Location = cmbLocation.Text;

                if (btnSave.Caption == "Save")
                {
                    NewProd.FnConn();
                    NewProd.fnTransactionData("I");
                    NewProd.FnTrans();
                    if (FormName != "Product")
                    {
                        Inventory.Database.MRRData MRR = new Inventory.Database.MRRData(null, null);

                        MRR.FnConn();
                        MRR.UpdateMrrStatus(Mrr_No, Pdt_No);
                        MRR.FnTrans();
                    }
                    if (NewProd.Result == "Success")
                        MessageBox.Show("Product Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Product Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    NewProd.FnConn();
                    NewProd.fnTransactionData("U");
                    NewProd.FnTrans();
                    if (NewProd.Result == "Success")
                        MessageBox.Show("Updated..", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Clear();
            }
            else
                MessageBox.Show("Please fill mandatory fields");
        }
        public void Clear()
        {
            ProductData Prod = new ProductData();
            Prod.FnConn();
            txtProduct_code.Text = "ID-C:000000" + (Convert.ToInt16(Prod.GetMaxValue()) + 1);
            Prod.FnTrans();

            txtQRCode.Text = "";
            txtItem_name.Text = "";
            cmbUnit.Text = "";
            cmbBrand_name.Text = "";
            cmbItem_category.Text = "";
            cmbSales_tax.Enabled = false;
            cmbPurchase_Tax.Enabled = false;
            cmbTax_category.Text = "Non Tax";
            cmbSales_tax.Text = "0";
            cmbPurchase_Tax.Text = "0";
            txtPurchase_rate.Text = "0.00";
            txtOpening_stock.Text="0";
            txtReorder_qty.Text="0";
            txtMin_qty.Text="0";
            txtSales_rate1.Text="0.00";
            txtSales_rate2.Text="0.00";
            txtSales_rate3.Text="0.00";
            txtBatch_name.Text="";
            dtMfg_date.Text="";
            dtExp_date.Text="";
            memWarranty.Text="";
            cmbLocation.Text = "";
            
        }

        private void txtItem_name_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void cmbUnit_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void cmbItem_category_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void txtBatch_name_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void cmbTax_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTax_category.Text == "Tax")
                {
                    cmbSales_tax.Enabled = true;
                    cmbPurchase_Tax.Enabled = true;
                }
                else
                {
                    cmbSales_tax.Enabled = false;
                    cmbPurchase_Tax.Enabled = false;
                }
            }
            catch(Exception ex)
            { }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnCreateUM_Click(object sender, EventArgs e)
        {
            Create_UM a = new Create_UM();
            a.ShowDialog();
            ItemsLoad();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ProdCode != null)
            {
                DialogResult rs = MessageBox.Show(" Procced ?", "Alert", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    ProductData Prod = new ProductData();
                    Prod.FnConn();
                    Prod.DeleteData(ProdCode);
                    Prod.FnTrans();
                    Clear();
                }
            }
        }
    }
}