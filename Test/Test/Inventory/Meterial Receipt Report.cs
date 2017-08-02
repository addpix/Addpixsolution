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
    public partial class Meterial_Receipt_Report : DevExpress.XtraEditors.XtraForm
    {
        public Meterial_Receipt_Report()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Test.Inventory.Database.MRRData MRR = new Inventory.Database.MRRData();
            MRR.MRRNo = txtMRR_no.Text;
            MRR.MRRDate = dtMRR_date.Text;
            MRR.DelNoteNo = txtDel_note_no.Text;
            MRR.ReqNo = txtReq_no.Text;
            MRR.PONo = txtPO_no.Text;

            MRR.FnConn();
            MRR.fnTransactionData();
            MRR.FnTrans();
            MessageBox.Show(MRR.Result);
        }
    }
}