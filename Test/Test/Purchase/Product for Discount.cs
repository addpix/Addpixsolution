using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Test
{
    public partial class Product_for_Discount : DevExpress.XtraEditors.XtraForm
    {
        String no;
        
        public Product_for_Discount(String no)
        {
            InitializeComponent();
            this.no = no;
        }

        private void Product_for_Discount_Load(object sender, EventArgs e)
        {
            Test.Purchase.database.discountData dis = new Purchase.database.discountData();
            dis.FnConn();
            DataTable dt = dis.FillData("products", no);
            if (dt.Rows.Count > 0)
            {
                txtPCode.Text = dt.Rows[0]["productCode"] + "";
                txtDescription.Text = dt.Rows[0]["itemName"] + "";
                txtSalesRate.Text = dt.Rows[0]["salesRate1"] + "";
            }
        }
        private string calcUnitprice()
        {
            double Actualprice = Convert.ToDouble(txtSalesRate.Text);
            double discount = Convert.ToDouble(txtDiscount.Text);
            double unitprice;
            if (chkDisType.Checked == true)
            {
                 unitprice = Actualprice - ((Actualprice * discount) / 100);
                return unitprice.ToString();
            }
            else
            {
                unitprice = Actualprice - discount;
                return unitprice.ToString();
            }
                
             
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtDescription.Text.Length!=0&&txtDiscount.Text.Length!=0&&txtPCode.Text.Length!=0&&txtSalesRate.Text.Length!=0)
            {
                DateTime startdate = DateTime.Parse(Convert.ToDateTime(dateEnd.Text).ToShortDateString());
                DateTime enddate = DateTime.Parse(Convert.ToDateTime(dateStart.Text).ToShortDateString());
                if (startdate < enddate)
                {
                    MessageBox.Show("Start date is greater than End date");
                }
                else
                {
                    string type;
                    if (chkDisType.Checked == true)
                        type = "Percentage";
                    else
                        type = "Cash";
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("productCode");
                    dt.Columns.Add("description");
                    dt.Columns.Add("salesRate");
                    dt.Columns.Add("discount");
                    dt.Columns.Add("discountType");
                    dt.Columns.Add("startDate");
                    dt.Columns.Add("endDate");
                    dt.Columns.Add("unitprice");
                    dt.Rows.Add(new object[] { txtPCode.Text, txtDescription.Text, txtSalesRate.Text, txtDiscount.Text, type, dateEnd.Text, dateStart.Text, calcUnitprice() });
                    Test.Purchase.database.discountData dis = new Purchase.database.discountData(dt);
                    dis.FnConn();
                    dis.fnTransactionData();
                    dis.FnTrans();
                    MessageBox.Show("Discount Added.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            
        }
    }
}