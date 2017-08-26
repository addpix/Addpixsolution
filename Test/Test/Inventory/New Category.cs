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
    public partial class New_Category : DevExpress.XtraEditors.XtraForm
    {
        public New_Category()
        {
            InitializeComponent();
        }
        private void InitValidationRules()
        {
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "Please enter a value";
            //..
            dxValidationProvider1.SetValidationRule(txtCategory, notEmptyValidationRule);

        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitValidationRules();
            if (txtCategory.Text != "")
            {
                Test.Inventory.Database.CategoryData NewCat = new Test.Inventory.Database.CategoryData();
                NewCat.Category = txtCategory.Text;

                NewCat.FnConn();
                NewCat.fnTransactionData();
                NewCat.FnTrans();
                if (NewCat.Result == "Success")
                    MessageBox.Show("Category Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Category Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                Clear();
            }
        }
        
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            txtCategory.Text = "";
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void txtCategory_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }
    }
}