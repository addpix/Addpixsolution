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
    public partial class Sales_Quatation_List : DevExpress.XtraEditors.XtraForm
    {
        public Sales_Quatation_List()
        {
            InitializeComponent();
        }

        private void Sales_Quatation_List_Load(object sender, EventArgs e)
        {
            Sale.Database.QuatationData quatationData = new Sale.Database.QuatationData();
            quatationData.FnConn();
           DataTable dt= quatationData.FillData("quo", "");
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }
    }
}