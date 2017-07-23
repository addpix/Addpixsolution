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
    public partial class Sales_Quotation : DevExpress.XtraEditors.XtraForm
    {
        public Sales_Quotation()
        {
            InitializeComponent();
        }

        private void Sales_Quotation_Load(object sender, EventArgs e)
        {
            Test.Sale.Database.QuatationData quatation = new Sale.Database.QuatationData();
            quatation.FnConn();
            DataTable dt1=quatation.FillData();
            if (dt1.Rows.Count > 0)
            {
                int number = Convert.ToInt32(dt1.Rows[0]["number"].ToString()) + 1;
                txtquatationnno.Text = "Quo" + number;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("slno", Type.GetType("System.Int32"));
            dt.Columns.Add("quotationNo", Type.GetType("System.String"));
            dt.Columns.Add("barcode", Type.GetType("System.String"));
            dt.Columns.Add("itemcode", Type.GetType("System.String"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("brandName", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.Double"));
            dt.Columns.Add("unitPrice", Type.GetType("System.Double"));
            dt.Columns.Add("totalAmount", Type.GetType("System.Double"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sales_Quatation_List a = new Sales_Quatation_List();
            a.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable source = gridControl1.DataSource as DataTable;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("quotationno");
            dt.Columns.Add("date");
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("address");
            dt.Columns.Add("phone");
            dt.Columns.Add("totalamount");
            dt.Rows.Add(new object[] { txtquatationnno.Text,dtpdate.Text,"cs1002",cmbcustomer.Text,txtaddress.Text,txtphone.Text,txtnetamount.Text });
            Test.Sale.Database.QuatationData quatationData = new Sale.Database.QuatationData(source,dt);
            quatationData.FnConn();
            quatationData.fnTransactionData();
            quatationData.FnTrans();

        }
    }
}