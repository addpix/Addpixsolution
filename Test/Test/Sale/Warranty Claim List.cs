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
    public partial class Warranty_Claim_List : DevExpress.XtraEditors.XtraForm
    {
        public Warranty_Claim_List()
        {
            InitializeComponent();
        }
        void loadData()
        {
            try
            {
                warrenty.FnConn();
                DataTable dt = warrenty.FillData("S", "spWarrenty", "");
                gridControl1.DataSource = dt;
                warrenty.FnTrans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Warranty_Claim a = new New_Warranty_Claim();
            a.ShowDialog();
            loadData();
        }
        Sale.Database.WarrantyClameData warrenty = new Sale.Database.WarrantyClameData();

        private void Warranty_Claim_List_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        
       
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string claimNo = row["claimNo"].ToString();
                New_Warranty_Claim warrenty1 = new New_Warranty_Claim();
                warrenty1.claimeNo = claimNo;
                warrenty1.ShowDialog();
                loadData();
            }
            catch (Exception ex) { }
        }
    }
}