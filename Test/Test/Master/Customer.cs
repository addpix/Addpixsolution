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
    public partial class Customer : DevExpress.XtraEditors.XtraForm
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            Cust.FnConn();
            Cust.fnTransactionData();
            Cust.FnTrans();
            MessageBox.Show(Cust.Result);
        }
    }
}