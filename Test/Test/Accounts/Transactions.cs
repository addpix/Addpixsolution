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
    public partial class Transactions : DevExpress.XtraEditors.XtraForm
    {
        public Transactions()
        {
            InitializeComponent();
        }
        private bool ExitForm(XtraForm form)
        {
            foreach (var child in MdiChildren)
            {
                if (child.Name == form.Name)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }
        private void Transactions_Load(object sender, EventArgs e)
        {

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Contra_Voucher();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Cash_Payment();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Cash_Receipt();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Payment_Voucher1();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Receipt_Voucher();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Journal_Voucher();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Credit_Note();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Debit_Note();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }
    }
}