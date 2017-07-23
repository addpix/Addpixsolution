using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
namespace Test
{
    public partial class MainWindow : DevExpress.XtraEditors.XtraForm
    {
        public MainWindow()
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
        private void navButton3_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }

        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
          
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Productname();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Category();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Product();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new ItemTransfer();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navButton2_ElementClick_1(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new MRR();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem41_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Stock_History();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new RFQ();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Purchase_Requst_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Purchase_Order();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Supplier_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Customer_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem40_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Lost_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Damage_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Employee_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Working_Time a = new Working_Time();
            a.ShowDialog();
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Attendance();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem26_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Attendence_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem38_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Create_Payroll();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem39_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Payrol_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Sales_Invoice();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Stock_History();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new ItemTransfer();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Purchase_Requst_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Sales_History();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Sales_Quotation();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }
        
        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Warranty_Claim_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Group_Master();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Ledger_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transactions a = new Transactions();
            a.ShowDialog();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Product_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Create_Barcode();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarItem33_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Delivery_Note_List();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Employee_Right a = new Employee_Right();
            a.ShowDialog();
        }

        private void navBarItem34_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var form = new Vacation_Leave();
            if (ExitForm(form)) return;
            form.MdiParent = this;
            form.Show();
        }
    }
}
