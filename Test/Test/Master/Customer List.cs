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
    public partial class Customer_List : DevExpress.XtraEditors.XtraForm
    {
        public Customer_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer a = new Customer();
            a.ShowDialog();
        }

        private void Customer_List_Load(object sender, EventArgs e)
        {
            Master.Database.CustomerData Cust = new Master.Database.CustomerData();
            try
            {
                Cust.FnConn();
                DataTable dt = Cust.FillData("S","");
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}