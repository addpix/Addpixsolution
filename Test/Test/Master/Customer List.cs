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
            try
            {
                Master.Customer a = new Master.Customer(null);
                a.ShowDialog();
                Master.Database.CustomerData Cust = new Master.Database.CustomerData();
                try
                {
                    Cust.FnConn();
                    DataTable dt = Cust.FillData();
                    gridControl1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch(Exception ex)
            {}
        }

        private void Customer_List_Load(object sender, EventArgs e)
        {
            try
            {
                Master.Database.CustomerData Cust = new Master.Database.CustomerData();
                try
                {
                    Cust.FnConn();
                    DataTable dt = Cust.FillData();
                    gridControl1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch(Exception ex)
            { }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

       

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string Cus_ID = row["customerID"].ToString();
            Master.Customer NewCus = new Master.Customer(Cus_ID);
            NewCus.ShowDialog();
            Master.Database.CustomerData Cust = new Master.Database.CustomerData();
            try
            {
                Cust.FnConn();
                DataTable dt = Cust.FillData();
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}