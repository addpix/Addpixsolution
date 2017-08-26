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
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraEditors.DXErrorProvider;
namespace Test.Master
{
    public partial class New_Supplier : DevExpress.XtraEditors.XtraForm
    {
        String Sup_ID;
        public New_Supplier(String Sup_ID)
        {
            InitializeComponent();
            this.Sup_ID = Sup_ID;
        }
        private void InitValidationRules()
        {
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "Please enter a value";
            //..
            dxValidationProvider1.SetValidationRule(txtSupplierName, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(txtPhone, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(memAddr, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(txtFullName, notEmptyValidationRule);
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool focused = txtSupplierName.Focused;
            cmbStatus.SelectedIndex = 0;
            int slno = 0;
            if (txtSupplierName.Text != "" && memAddr.Text != "" && txtPhone.Text != "")
            {
                Master.Database.SupplierData Sup = new Master.Database.SupplierData();
               
                Sup.SupplierName = txtSupplierName.Text;
                Sup.FullName = txtFullName.Text;
                Sup.Address = memAddr.Text;
                Sup.Phone = txtPhone.Text;
                Sup.Email = txtEmail.Text;
                Sup.WebAddr = txtWebAddr.Text;
                Sup.License = txtLicenseNo.Text;
                Sup.TinNo = txtTinNo.Text;
                Sup.Status = cmbStatus.Text;
                Sup.OppBal = txtOppBal.Text;
                Sup.CreditLimit = txtCreditLimit.Text;
                Sup.PaymentDays = (spnPaymentDays.Text).Split('.')[0];

                if (btnSave.Caption == "Save")
                {
                    Sup.FnConn();
                    slno = Convert.ToInt16(Sup.GetMaxValue()) + 1;
                    Sup.FnTrans();

                    Sup.Supplierid = "SUP000" + slno;

                    Sup.FnConn();
                    Sup.fnTransactionData("I");
                    Sup.FnTrans();
                    if (Sup.Result == "Success")
                        MessageBox.Show("Supplier Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Supplier Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Sup.Supplierid = Sup_ID;
                    Sup.FnConn();
                    Sup.fnTransactionData("U");
                    Sup.FnTrans();
                    if (Sup.Result == "Success")
                        MessageBox.Show("Suppler Details Updated..", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Clear();
            }
            else
                MessageBox.Show("Please input mandatory fields");
        }
        public void Clear()
        {
            txtSupplierName.Text = "";
            txtFullName.Text = "";
            memAddr.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtWebAddr.Text = "";
            txtLicenseNo.Text = "";
            txtTinNo.Text = "";
            cmbStatus.SelectedIndex = 0;
            txtOppBal.Text = "0.00";
            txtCreditLimit.Text = "0.00";
            spnPaymentDays.Text = "0";
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void New_Supplier_Load(object sender, EventArgs e)
        {
            bool focused = txtSupplierName.Focused;
            cmbStatus.SelectedIndex = 0;
            if (Sup_ID != null)
            {
                btnSave.Caption = "Update";
                Master.Database.SupplierData Sup = new Master.Database.SupplierData();

                DataTable dtSup = new DataTable();
                Sup.FnConn();
                dtSup = Sup.GetRow(Sup_ID);
                Sup.FnTrans();

                if (dtSup.Rows.Count > 0)
                {
                    txtSupplierName.Text = dtSup.Rows[0]["name"] + "";
                    txtFullName.Text = dtSup.Rows[0]["fullName"] + "";
                    memAddr.Text = dtSup.Rows[0]["address"] + "";
                    txtPhone.Text = dtSup.Rows[0]["phoneNumber"] + "";
                    txtEmail.Text = dtSup.Rows[0]["email"] + "";
                    txtWebAddr.Text = dtSup.Rows[0]["webAddress"] + "";
                    txtLicenseNo.Text = dtSup.Rows[0]["licenceNumber"] + "";
                    txtTinNo.Text = dtSup.Rows[0]["tinNumber"] + "";
                    cmbStatus.Text = dtSup.Rows[0]["status"] + "";
                    txtOppBal.Text = dtSup.Rows[0]["openingBalance"] + "";
                    txtCreditLimit.Text = dtSup.Rows[0]["creditLimit"] + "";
                    spnPaymentDays.Text = dtSup.Rows[0]["paymentDays"] + "";
                }
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Sup_ID != null)
            {
                DialogResult rs = MessageBox.Show(" Procced ?", "Alert", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    Master.Database.SupplierData Sup = new Master.Database.SupplierData();
                    Sup.FnConn();
                    Sup.DeleteData(Sup_ID);
                    Sup.FnTrans();
                    Clear();
                }
            }
        }

        private void txtOppBal_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtOppBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void memAddr_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }
    }
}