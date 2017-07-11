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
            warrenty.fnTransactionData();
            String result=warrenty.FnTrans();
            MessageBox.Show(result);
            
        }
    }
}