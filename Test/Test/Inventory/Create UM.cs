using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
namespace Test
{
    public partial class Create_UM : DevExpress.XtraEditors.XtraForm
    {
        public Create_UM()
        {
            InitializeComponent();
            LoadList();
        }
        public void LoadList()
        {
            lsbUnitNames.Items.Clear();
            Test.Inventory.Database.CreateUMData UM = new Inventory.Database.CreateUMData();
            UM.FnConn();
            DataTable dtUnit = UM.FillData();
            UM.FnTrans();

            foreach (DataRow dr in dtUnit.Rows)
                lsbUnitNames.Items.Add(dr["unitName"] + "");
        }
        private void InitValidationRules()
        {
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "Please enter a value";
            //..
            dxValidationProvider1.SetValidationRule(txtUnitName, notEmptyValidationRule);
            
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtUnitName.Text.Length != 0)
            {
                if (lsbUnitNames.Items.Contains(txtUnitName.Text))
                    MessageBox.Show("Unit already exist");
                else
                {
                    Test.Inventory.Database.CreateUMData UM = new Inventory.Database.CreateUMData();
                    UM.UnitName = txtUnitName.Text;

                    UM.FnConn();
                    UM.fnTransactionData();
                    UM.FnTrans();

                    if (UM.Result == "Success")
                        MessageBox.Show("Unit Created", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Unit Creation failed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtUnitName.Text = "";
                    txtUnitName.Focus();
                    LoadList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(" Procced ?", "Alert", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                Test.Inventory.Database.CreateUMData UM = new Inventory.Database.CreateUMData();

                UM.FnConn();
                UM.DeleteData(lsbUnitNames.SelectedItem + "");
                UM.FnTrans();

                LoadList();
            }
        }

        private void Create_UM_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txtUnitName_Leave(object sender, EventArgs e)
        {
            InitValidationRules();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}