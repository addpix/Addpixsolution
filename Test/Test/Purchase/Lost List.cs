﻿using System;
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
    public partial class Lost_List : DevExpress.XtraEditors.XtraForm
    {
        public Lost_List()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New_Lost a = new New_Lost();
            a.ShowDialog();
        }

        private void Lost_List_Load(object sender, EventArgs e)
        {

        }
    }
}