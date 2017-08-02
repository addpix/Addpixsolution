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
        }

        private void Category_Load(object sender, EventArgs e)
        {
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
    }
}