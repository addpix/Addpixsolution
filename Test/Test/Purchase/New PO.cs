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
    public partial class New_PO : DevExpress.XtraEditors.XtraForm
    {
        public New_PO()
        {
            InitializeComponent();
        }

        private void New_PO_Load(object sender, EventArgs e)
        {
            Test.Purchase.database.PurchaseOrder po = new Purchase.database.PurchaseOrder();
            po.FnConn();

            DataTable dt = new DataTable();
            dt.Columns.Add("slno", Type.GetType("System.Int32"));
            dt.Columns.Add("itemcode", Type.GetType("System.String"));
            dt.Columns.Add("description", Type.GetType("System.String"));
            dt.Columns.Add("brand", Type.GetType("System.String"));
            dt.Columns.Add("um", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.Double"));
            dt.Columns.Add("unitprice", Type.GetType("System.Double"));
            dt.Columns.Add("amount", Type.GetType("System.Double"));
            dt.Columns.Add("taxpercent", Type.GetType("System.Double"));
            dt.Columns.Add("taxamount", Type.GetType("System.Double"));
            dt.Columns.Add("total", Type.GetType("System.Double"));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable source = gridControl1.DataSource as DataTable;
            source.Columns.Add("purchaseOrderNo", typeof(System.Int32));

            foreach (DataRow row in source.Rows)
            {
                //need to set value to NewColumn column
                row["purchaseOrderNo"] = txtPO.Text;   // or set it to some other value
            }

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("slno");
            dt.Columns.Add("orderNo");
            dt.Columns.Add("date");
            dt.Columns.Add("purchaseRequestNo");
            dt.Columns.Add("quotationRequestNo");
            dt.Columns.Add("QuotationRefrenceNo");
            dt.Columns.Add("location");
            dt.Columns.Add("requester");
            dt.Columns.Add("vendor");
            dt.Columns.Add("vendorId");
            dt.Columns.Add("address");
            dt.Columns.Add("ph");
            dt.Columns.Add("paymentType");
            dt.Columns.Add("paymentDays");
            dt.Columns.Add("notes");
            dt.Columns.Add("conditions");
            dt.Rows.Add(new object[] {"11", txtPO.Text, datePOdate.Text, txtPRNo.Text, txtRFQNo.Text, TtxtQtnRfNo.Text, txtLocation.Text, txtrequester.Text, txtVendor.Text, "0000", txtAddress.Text, txtPh.Text, "cash", spnPaymtDays.Text, txtNotes.Text,txtTnC.Text});
            Test.Purchase.database.PurchaseOrder purchase = new Purchase.database.PurchaseOrder(source, dt);
            purchase.FnConn();
            purchase.fnTransactionData();
            purchase.FnTrans();
        }
    }
}