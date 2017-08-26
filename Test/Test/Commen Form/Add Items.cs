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
using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace Test
{
    public partial class Add_Items : DevExpress.XtraEditors.XtraForm
    {
        public DataTable Dgv  { get; set; }
        public Add_Items()
        {
            InitializeComponent();
        }

        private void Add_Items_Load(object sender, EventArgs e)
        {
            Sale.Database.SalesData salesData = new Sale.Database.SalesData();
            salesData.FnConn();
            DataTable dt = salesData.FillData("currentstock", "", "spsales");
            dt.Columns.Add("status", Type.GetType("System.Boolean"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["status"] = false;
            }
            if (dt.Rows.Count > 0)
            {
                gridControl1.DataSource = dt;
            }
        }

       

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            gridView1.RefreshData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.RefreshData();
            DataTable dt = gridControl1.DataSource as DataTable;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("productCode");
            dt2.Columns.Add("itemName");
            dt2.Columns.Add("brandName");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i]["status"] + "") == true)
                {
                    dt2.Rows.Add(dt.Rows[i]["productCode"] + "", dt.Rows[i]["itemName"] + "", dt.Rows[i]["brandName"] + "");
                }
            }
            Dgv = dt2;
            this.Close();
        }
    }
}