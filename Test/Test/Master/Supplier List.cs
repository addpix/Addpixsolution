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

namespace Test.Master
{
    public partial class Supplier_List : DevExpress.XtraEditors.XtraForm
    {
        public Supplier_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Supplier a = new New_Supplier(null);
            a.ShowDialog();
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string Sup_ID = row["supplierId"].ToString();
            New_Supplier NewSup = new New_Supplier(Sup_ID);
            NewSup.ShowDialog();

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