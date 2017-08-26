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
using DevExpress.XtraEditors.DXErrorProvider;
namespace Test
{
    public partial class Newbrand : DevExpress.XtraEditors.XtraForm
    {
        String Brand_ID;
        public Newbrand(String Brand_ID)
        {
            InitializeComponent();
            this.Brand_ID = Brand_ID;
        }
        private void InitValidationRules()
        {
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "Please enter a value";
            //..
            dxValidationProvider1.SetValidationRule(txtBrand, notEmptyValidationRule);
            
        }
        private void Newbrand_Load(object sender, EventArgs e)
        {
            Master.Database.SupplierData Sup = new Master.Database.SupplierData();
            Sup.FnConn();
            DataTable dtBrand = Sup.DistinctColumn("spSupplier");
            //DataTable dtBrand = Sup.FillData();
            Sup.FnTrans();
            foreach (DataRow dr in dtBrand.Rows)
                cmbVendor.Properties.Items.Add(dr["name"] + "");

            if (Brand_ID != null)
            {
                btnSave.Caption = "Update";
                Inventory.Database.NewBrandData Brand = new Inventory.Database.NewBrandData();

                DataTable dtBrnd = new DataTable();
                Brand.FnConn();
                dtBrnd = Brand.GetRow(Brand_ID);
                Brand.FnTrans();

                if (dtBrnd.Rows.Count > 0)
                {
                    txtBrand.Text = dtBrnd.Rows[0]["brandName"] + "";
                    cmbVendor.Text = dtBrnd.Rows[0]["vendor"] + "";
                }
            }
            else
                btnDelete.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtBrand.Text != "" && cmbVendor.Text != "")
            {
                Inventory.Database.NewBrandData NewBrand = new Inventory.Database.NewBrandData();
                NewBrand.Brand = txtBrand.Text;
                NewBrand.Vendor = cmbVendor.Text;
                
                if (btnSave.Caption=="Save")
                {
                    NewBrand.FnConn();
                    NewBrand.fnTransactionData("I");
                    NewBrand.FnTrans();

                    if (NewBrand.Result == "Success")
                        MessageBox.Show("Brand Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Brand Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
                else
                {
                    NewBrand.Slno = Brand_ID;
                    NewBrand.FnConn();
                    NewBrand.fnTransactionData("U");
                    NewBrand.FnTrans();

                    if (NewBrand.Result == "Success")
                        MessageBox.Show("Brand Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Brand Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            Brand_ID = null;
            txtBrand.Text = "";
            cmbVendor.Text = "";
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Brand_ID != null)
            {
                DialogResult rs = MessageBox.Show(" Procced ?", "Alert", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    Inventory.Database.NewBrandData Brand = new Inventory.Database.NewBrandData();
                    Brand.FnConn();
                    Brand.DeleteData(Brand_ID);
                    Brand.FnTrans();
                    Clear();
                }
            }
        }

        private void txtBrand_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }
    }
}