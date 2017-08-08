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
    public partial class Supplier_List : DevExpress.XtraEditors.XtraForm
    {
        public Supplier_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Supplier a = new New_Supplier();
            a.ShowDialog();
        }

        private void Supplier_List_Load(object sender, EventArgs e)
        {
            Master.Database.SupplierData Sup = new Master.Database.SupplierData();
            try
            {
                Sup.FnConn();
                DataTable dt = Sup.FillData();
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}