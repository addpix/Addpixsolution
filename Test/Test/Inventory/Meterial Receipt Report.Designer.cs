namespace Test
{
    partial class Meterial_Receipt_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meterial_Receipt_Report));
            this.bmStoreKeeper = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewMRR = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtStoreKeeper = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UoM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeliveredQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BalanceQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPO_no = new DevExpress.XtraEditors.TextEdit();
            this.txtReq_no = new DevExpress.XtraEditors.TextEdit();
            this.txtDel_note_no = new DevExpress.XtraEditors.TextEdit();
            this.dtMRR_date = new DevExpress.XtraEditors.DateEdit();
            this.txtMRR_no = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.bmStoreKeeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreKeeper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPO_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReq_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDel_note_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMRR_date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMRR_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMRR_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // bmStoreKeeper
            // 
            this.bmStoreKeeper.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.bmStoreKeeper.DockControls.Add(this.barDockControlTop);
            this.bmStoreKeeper.DockControls.Add(this.barDockControlBottom);
            this.bmStoreKeeper.DockControls.Add(this.barDockControlLeft);
            this.bmStoreKeeper.DockControls.Add(this.barDockControlRight);
            this.bmStoreKeeper.Form = this;
            this.bmStoreKeeper.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnNewMRR,
            this.btnClose});
            this.bmStoreKeeper.MainMenu = this.bar2;
            this.bmStoreKeeper.MaxItemId = 3;
            this.bmStoreKeeper.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNewMRR, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 0;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnNewMRR
            // 
            this.btnNewMRR.Caption = "New";
            this.btnNewMRR.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNewMRR.Glyph")));
            this.btnNewMRR.Id = 1;
            this.btnNewMRR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNewMRR.LargeGlyph")));
            this.btnNewMRR.Name = "btnNewMRR";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 2;
            this.btnClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClose.LargeGlyph")));
            this.btnClose.Name = "btnClose";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(922, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 483);
            this.barDockControlBottom.Size = new System.Drawing.Size(922, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 459);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(922, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 459);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtStoreKeeper);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.txtPO_no);
            this.layoutControl1.Controls.Add(this.txtReq_no);
            this.layoutControl1.Controls.Add(this.txtDel_note_no);
            this.layoutControl1.Controls.Add(this.dtMRR_date);
            this.layoutControl1.Controls.Add(this.txtMRR_no);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(922, 459);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtStoreKeeper
            // 
            this.txtStoreKeeper.Location = new System.Drawing.Point(106, 12);
            this.txtStoreKeeper.MenuManager = this.bmStoreKeeper;
            this.txtStoreKeeper.Name = "txtStoreKeeper";
            this.txtStoreKeeper.Size = new System.Drawing.Size(542, 20);
            this.txtStoreKeeper.StyleController = this.layoutControl1;
            this.txtStoreKeeper.TabIndex = 11;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 132);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.bmStoreKeeper;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(898, 315);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.No,
            this.ItemCode,
            this.Description,
            this.Quantity,
            this.UoM,
            this.DeliveredQty,
            this.BalanceQty,
            this.Remark});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // No
            // 
            this.No.Caption = "#";
            this.No.Name = "No";
            this.No.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.No.OptionsColumn.AllowIncrementalSearch = false;
            this.No.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.No.OptionsColumn.AllowMove = false;
            this.No.OptionsColumn.AllowSize = false;
            this.No.OptionsColumn.FixedWidth = true;
            this.No.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.No.Visible = true;
            this.No.VisibleIndex = 0;
            this.No.Width = 30;
            // 
            // ItemCode
            // 
            this.ItemCode.Caption = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ItemCode.OptionsColumn.AllowIncrementalSearch = false;
            this.ItemCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ItemCode.OptionsColumn.AllowMove = false;
            this.ItemCode.OptionsColumn.AllowSize = false;
            this.ItemCode.OptionsColumn.FixedWidth = true;
            this.ItemCode.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.ItemCode.Visible = true;
            this.ItemCode.VisibleIndex = 1;
            // 
            // Description
            // 
            this.Description.Caption = "Description";
            this.Description.Name = "Description";
            this.Description.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Description.OptionsColumn.AllowIncrementalSearch = false;
            this.Description.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Description.OptionsColumn.AllowMove = false;
            this.Description.OptionsColumn.AllowSize = false;
            this.Description.OptionsColumn.FixedWidth = true;
            this.Description.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 2;
            this.Description.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Quantity.OptionsColumn.AllowIncrementalSearch = false;
            this.Quantity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Quantity.OptionsColumn.AllowMove = false;
            this.Quantity.OptionsColumn.AllowSize = false;
            this.Quantity.OptionsColumn.FixedWidth = true;
            this.Quantity.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 3;
            this.Quantity.Width = 45;
            // 
            // UoM
            // 
            this.UoM.Caption = "UoM";
            this.UoM.Name = "UoM";
            this.UoM.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.UoM.OptionsColumn.AllowIncrementalSearch = false;
            this.UoM.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.UoM.OptionsColumn.AllowMove = false;
            this.UoM.OptionsColumn.AllowSize = false;
            this.UoM.OptionsColumn.FixedWidth = true;
            this.UoM.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.UoM.Visible = true;
            this.UoM.VisibleIndex = 4;
            this.UoM.Width = 45;
            // 
            // DeliveredQty
            // 
            this.DeliveredQty.Caption = "Delivered Qty";
            this.DeliveredQty.Name = "DeliveredQty";
            this.DeliveredQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.DeliveredQty.OptionsColumn.AllowIncrementalSearch = false;
            this.DeliveredQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DeliveredQty.OptionsColumn.AllowMove = false;
            this.DeliveredQty.OptionsColumn.AllowSize = false;
            this.DeliveredQty.OptionsColumn.FixedWidth = true;
            this.DeliveredQty.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.DeliveredQty.Visible = true;
            this.DeliveredQty.VisibleIndex = 5;
            this.DeliveredQty.Width = 70;
            // 
            // BalanceQty
            // 
            this.BalanceQty.Caption = "Balance Qty";
            this.BalanceQty.Name = "BalanceQty";
            this.BalanceQty.OptionsColumn.AllowMove = false;
            this.BalanceQty.OptionsColumn.AllowSize = false;
            this.BalanceQty.OptionsColumn.FixedWidth = true;
            this.BalanceQty.Visible = true;
            this.BalanceQty.VisibleIndex = 6;
            this.BalanceQty.Width = 70;
            // 
            // Remark
            // 
            this.Remark.Caption = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.OptionsColumn.AllowMove = false;
            this.Remark.OptionsColumn.AllowSize = false;
            this.Remark.OptionsColumn.FixedWidth = true;
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 7;
            this.Remark.Width = 100;
            // 
            // txtPO_no
            // 
            this.txtPO_no.Location = new System.Drawing.Point(746, 108);
            this.txtPO_no.MenuManager = this.bmStoreKeeper;
            this.txtPO_no.Name = "txtPO_no";
            this.txtPO_no.Size = new System.Drawing.Size(164, 20);
            this.txtPO_no.StyleController = this.layoutControl1;
            this.txtPO_no.TabIndex = 8;
            // 
            // txtReq_no
            // 
            this.txtReq_no.Location = new System.Drawing.Point(746, 84);
            this.txtReq_no.MenuManager = this.bmStoreKeeper;
            this.txtReq_no.Name = "txtReq_no";
            this.txtReq_no.Size = new System.Drawing.Size(164, 20);
            this.txtReq_no.StyleController = this.layoutControl1;
            this.txtReq_no.TabIndex = 7;
            // 
            // txtDel_note_no
            // 
            this.txtDel_note_no.Location = new System.Drawing.Point(746, 60);
            this.txtDel_note_no.MenuManager = this.bmStoreKeeper;
            this.txtDel_note_no.Name = "txtDel_note_no";
            this.txtDel_note_no.Size = new System.Drawing.Size(164, 20);
            this.txtDel_note_no.StyleController = this.layoutControl1;
            this.txtDel_note_no.TabIndex = 6;
            // 
            // dtMRR_date
            // 
            this.dtMRR_date.EditValue = null;
            this.dtMRR_date.Location = new System.Drawing.Point(746, 36);
            this.dtMRR_date.MenuManager = this.bmStoreKeeper;
            this.dtMRR_date.Name = "dtMRR_date";
            this.dtMRR_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMRR_date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMRR_date.Size = new System.Drawing.Size(164, 20);
            this.dtMRR_date.StyleController = this.layoutControl1;
            this.dtMRR_date.TabIndex = 5;
            // 
            // txtMRR_no
            // 
            this.txtMRR_no.Location = new System.Drawing.Point(746, 12);
            this.txtMRR_no.MenuManager = this.bmStoreKeeper;
            this.txtMRR_no.Name = "txtMRR_no";
            this.txtMRR_no.Size = new System.Drawing.Size(164, 20);
            this.txtMRR_no.StyleController = this.layoutControl1;
            this.txtMRR_no.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(922, 459);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMRR_no;
            this.layoutControlItem1.Location = new System.Drawing.Point(640, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(262, 24);
            this.layoutControlItem1.Text = "MRR No";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtMRR_date;
            this.layoutControlItem2.Location = new System.Drawing.Point(640, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(262, 24);
            this.layoutControlItem2.Text = "Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDel_note_no;
            this.layoutControlItem3.Location = new System.Drawing.Point(640, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(262, 24);
            this.layoutControlItem3.Text = "Delivery Note No";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtReq_no;
            this.layoutControlItem4.Location = new System.Drawing.Point(640, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(262, 24);
            this.layoutControlItem4.Text = "Requisition No";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPO_no;
            this.layoutControlItem5.Location = new System.Drawing.Point(640, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(262, 24);
            this.layoutControlItem5.Text = "Purchase Order No";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridControl1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(902, 319);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtStoreKeeper;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(640, 120);
            this.layoutControlItem6.Text = "Store Keeper";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(91, 13);
            // 
            // Meterial_Receipt_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 506);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(938, 545);
            this.MinimumSize = new System.Drawing.Size(938, 544);
            this.Name = "Meterial_Receipt_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meterial Receipt Report";
            ((System.ComponentModel.ISupportInitialize)(this.bmStoreKeeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreKeeper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPO_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReq_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDel_note_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMRR_date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMRR_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMRR_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmStoreKeeper;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnNewMRR;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn No;
        private DevExpress.XtraGrid.Columns.GridColumn ItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn UoM;
        private DevExpress.XtraGrid.Columns.GridColumn DeliveredQty;
        private DevExpress.XtraEditors.TextEdit txtPO_no;
        private DevExpress.XtraEditors.TextEdit txtReq_no;
        private DevExpress.XtraEditors.TextEdit txtDel_note_no;
        private DevExpress.XtraEditors.DateEdit dtMRR_date;
        private DevExpress.XtraEditors.TextEdit txtMRR_no;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn BalanceQty;
        private DevExpress.XtraGrid.Columns.GridColumn Remark;
        private DevExpress.XtraEditors.TextEdit txtStoreKeeper;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}