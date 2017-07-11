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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Warranty_Claim a = new New_Warranty_Claim();
            a.ShowDialog();
        }
        Sale.Database.WarrantyClameData warrenty = new Sale.Database.WarrantyClameData();

        private void Warranty_Claim_List_Load(object sender, EventArgs e)
        {
            try
            {
                warrenty.FnConn();
                DataTable dt = warrenty.FillData();
                gridControl1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
    }
}