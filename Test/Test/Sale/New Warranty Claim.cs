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
    public partial class New_Warranty_Claim : DevExpress.XtraEditors.XtraForm
    {
        public string claimeNo { get; set; }
       
        public New_Warranty_Claim()
        {
            InitializeComponent();
        }
        //WarrantclameData 
        Sale.Database.WarrantyClameData warrenty = new Sale.Database.WarrantyClameData();
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            warrenty.claimeNo = txtclaimeno.Text;
            warrenty.claimeDate = dtpdate.Text;
            warrenty.contactName = txtcontactName.Text;
            warrenty.conactNumber = txtContactNo.Text;
            warrenty.mailid = txtmailId.Text;
            warrenty.purchaseDate = dtpurchaseDate.Text;
            warrenty.SerialNumber = txtSerialNumber.Text;
            warrenty.ItemName = txtItemNamae.Text;
            warrenty.MOdelName = txtmodelName.Text;
            warrenty.complaintDetails = txtcomplaintDeatails.Text;
            warrenty.status = cmbstatus.Text;
            warrenty.FnConn();
            if (barButtonItem1.Caption == "Save")
            {
                warrenty.fnTransactionData("I");
            }
            else
            {
                warrenty.fnTransactionData("update");
            }
            
            String result=warrenty.FnTrans();
            MessageBox.Show(result);
            barButtonItem1.Enabled = false;
            
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//btn new 
        {
            txtclaimeno.Text="";
            dtpdate.Text="";
            txtcontactName.Text="";
           txtContactNo.Text="";
            txtmailId.Text="";
            dtpurchaseDate.Text="";
            txtSerialNumber.Text="";
            txtItemNamae.Text="";
            txtmodelName.Text="";
            txtcomplaintDeatails.Text="";
            cmbstatus.Text="";
            barButtonItem1.Caption = "Save";
            barButtonItem1.Enabled = true;
            loadnewForm();
        }
        void loadnewForm()
        {
            warrenty.FnConn();
            dtpdate.EditValue = DateTime.Now;
            DataTable dt = warrenty.FillData("M", "spWarrenty", "");
            if (dt.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                string claimNo = number + "";
                txtclaimeno.Text = claimNo.PadLeft(5, '0');
            }
            warrenty.FnTrans();
        }

        private void New_Warranty_Claim_Load(object sender, EventArgs e)
        {
       
            if (claimeNo != null)
            {
                warrenty.FnConn();
                barButtonItem1.Caption = "Update";
                DataTable dt= warrenty.FillData("search", "spWarrenty", claimeNo);
                if (dt.Rows.Count > 0)
                {
                    txtclaimeno.Text = dt.Rows[0]["claimNo"] + "";
                    Commen_Form.Functions.DateConverter dc = new Commen_Form.Functions.DateConverter();

                    
                    dtpdate.Text = dc.dateconverter(dt.Rows[0]["date"]+"");
                    txtcontactName.Text = dt.Rows[0]["contactName"] + "";
                    txtContactNo.Text = dt.Rows[0]["contactNumber"] + "";
                    txtmailId.Text = dt.Rows[0]["mailid"] + "";
                    

                    dtpurchaseDate.Text = dc.dateconverter(dt.Rows[0]["purchaseDate"]+ "");
                    txtItemNamae.Text = dt.Rows[0]["itemName"] + "";
                    txtmodelName.Text = dt.Rows[0]["modelNo"] + "";
                    txtSerialNumber.Text = dt.Rows[0]["serialNo"] + "";
                    txtcomplaintDeatails.Text = dt.Rows[0]["complaintDetails"] + "";
                    cmbstatus.Text = dt.Rows[0]["status"] + "";
                    warrenty.FnTrans();
                }
            }
            else
            {
                loadnewForm();
            }
            
           
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string claimNo = txtclaimeno.Text;
            warrenty.FnConn();
            warrenty.claimeNo = claimNo;
            warrenty.fnTransactionData("delete");
            warrenty.FnTrans();
            MessageBox.Show(claimNo + " is removed from the database", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            barButtonItem3.PerformClick();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}