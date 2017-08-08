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

namespace Test
{
    public partial class New_Supplier : DevExpress.XtraEditors.XtraForm
    {
        public New_Supplier()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            Sup.FnConn();
            Sup.fnTransactionData();
            Sup.FnTrans();
            MessageBox.Show(Sup.Result);
        }
    }
}