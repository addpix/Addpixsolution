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

namespace Test.Master
{
    public partial class Customer : DevExpress.XtraEditors.XtraForm
    {
        
        String Cus_ID;
        public Customer(String Cus_ID)
        {
            InitializeComponent();
            
            this.Cus_ID = Cus_ID;
        }
       
        private void InitValidationRules()
        {
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "Please enter a value";
            //..
            dxValidationProvider1.SetValidationRule(txtCustName, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(txtPhone, notEmptyValidationRule);
            dxValidationProvider1.SetValidationRule(memAddr, notEmptyValidationRule);
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool focused = txtCustName.Focused;
            int slno = 0;
            if (txtCustName.Text != "" && memAddr.Text != "" && txtPhone.Text != "")
            {
                Master.Database.CustomerData Cust = new Master.Database.CustomerData();
                Cust.CustomerName = txtCustName.Text;
                Cust.Address = memAddr.Text;
                Cust.Phone = txtPhone.Text;
                Cust.Email = txtEmail.Text;
                Cust.WebAddr = txtWebAddr.Text;
                Cust.OppBal = txtOppBal.Text;
                Cust.CreditLimit = txtCreditLim.Text;
                Cust.PaymentDays = (spnPaymentDays.Text).Split('.')[0];
                
                if (btnSave.Caption == "Save")
                {
                    Cust.FnConn();
                    slno = Convert.ToInt16(Cust.GetMaxValue()) + 1;
                    Cust.FnTrans();
                    Cust.CustomerId = "CU00" + slno;

                    Cust.FnConn();
                    Cust.fnTransactionData("I");
                    Cust.FnTrans();
                    if (Cust.Result == "Success")
                        MessageBox.Show("Customer Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Customer Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
                else
                {
                    Cust.CustomerId = Cus_ID;
                    Cust.FnConn();
                    Cust.fnTransactionData("U");
                    Cust.FnTrans();
                    if (Cust.Result == "Success")
                        MessageBox.Show("Updated", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Update Failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            txtCustName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            bool focused = txtCustName.Focused;
            if (Cus_ID != null)
            {
                btnSave.Caption = "Update";
                Master.Database.CustomerData CuS = new Master.Database.CustomerData();

                DataTable dtCus = new DataTable();
                CuS.FnConn();
                dtCus = CuS.GetRow(Cus_ID);
                CuS.FnTrans();

                if (dtCus.Rows.Count > 0)
                {
                    txtCustName.Text = dtCus.Rows[0]["name"] + "";
                    memAddr.Text = dtCus.Rows[0]["address"] + "";
                    txtPhone.Text = dtCus.Rows[0]["phone"] + "";
                    txtEmail.Text = dtCus.Rows[0]["email"] + "";
                    txtWebAddr.Text = dtCus.Rows[0]["webAddress"] + "";
                    txtOppBal.Text = dtCus.Rows[0]["openingBalance"] + "";
                    txtCreditLim.Text = dtCus.Rows[0]["creditLimit"] + "";
                    spnPaymentDays.Text = dtCus.Rows[0]["paymentDays"] + "";
                }
            }
        }
        public void Clear()
        {
            txtCustName.Text = "";
            memAddr.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtWebAddr.Text = "";
            txtOppBal.Text = "0.00";
            txtCreditLim.Text = "0.00";
            spnPaymentDays.Text = "0";
            Master.Database.CustomerData Cust = new Master.Database.CustomerData();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Cus_ID != null)
            {
                DialogResult rs = MessageBox.Show(" Procced ?", "Alert", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    Master.Database.CustomerData Cus = new Master.Database.CustomerData();
                    Cus.FnConn();
                    Cus.DeleteData(Cus_ID);
                    Cus.FnTrans();
                    Clear();
                }
            }
        }

        private void txtOppBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCreditLim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCustName_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtCustName_Leave(object sender, EventArgs e)
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