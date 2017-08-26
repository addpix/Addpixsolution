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
    public partial class Category : DevExpress.XtraEditors.XtraForm
    {
        public Category()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Category a = new New_Category();
            a.ShowDialog();
            Test.Inventory.Database.CategoryData Cat = new Inventory.Database.CategoryData();
            try
            {
                Cat.FnConn();
                DataTable dt = Cat.FillData();
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {
            Inventory.Database.CategoryData Cat = new Inventory.Database.CategoryData();
            try
            {
                Cat.FnConn();
                DataTable dt = Cat.FillData();
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
            string Slno = row["slno"].ToString();
            if (Slno != null)
            {
                DialogResult rs = MessageBox.Show("Delete Category ?", "Alert", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    Inventory.Database.CategoryData Cat = new Inventory.Database.CategoryData();
                    Cat.FnConn();
                    Cat.DeleteData(Slno);
                    Cat.FnTrans();
                }
                Category_Load(sender, null);
            }
        }
    }
}