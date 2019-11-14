﻿namespace PhanMemQuanLyCongTrinh
{
    partial class frm_NewProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NewProgress));
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.btn_AddBuildingContractor = new DevExpress.XtraEditors.SimpleButton();
            this.lke_ConstractionItem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.btn_AddConstruction = new DevExpress.XtraEditors.SimpleButton();
            this.lke_Constraction = new DevExpress.XtraEditors.LookUpEdit();
            this.date_Start = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Img = new DevExpress.XtraEditors.SimpleButton();
            this.but_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.pic_Logo = new DevExpress.XtraEditors.PictureEdit();
            this.txt_description = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.date_End = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_ConstractionItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_Constraction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_Start.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_Start.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_description.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_End.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_End.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Appearance.Options.UseForeColor = true;
            this.labelControl18.Location = new System.Drawing.Point(460, 76);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(8, 16);
            this.labelControl18.TabIndex = 406;
            this.labelControl18.Text = "*";
            // 
            // btn_AddBuildingContractor
            // 
            this.btn_AddBuildingContractor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddBuildingContractor.ImageOptions.Image")));
            this.btn_AddBuildingContractor.Location = new System.Drawing.Point(431, 73);
            this.btn_AddBuildingContractor.Name = "btn_AddBuildingContractor";
            this.btn_AddBuildingContractor.Size = new System.Drawing.Size(23, 23);
            this.btn_AddBuildingContractor.TabIndex = 405;
            this.btn_AddBuildingContractor.Click += new System.EventHandler(this.btn_AddBuildingContractor_Click);
            // 
            // lke_ConstractionItem
            // 
            this.lke_ConstractionItem.Location = new System.Drawing.Point(134, 77);
            this.lke_ConstractionItem.Name = "lke_ConstractionItem";
            this.lke_ConstractionItem.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lke_ConstractionItem.Properties.Appearance.Options.UseFont = true;
            this.lke_ConstractionItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_ConstractionItem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("construction_item_custom", "Mã Hạng Mục"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("construction_item_name", "Tên Hạng Mục")});
            this.lke_ConstractionItem.Properties.NullText = "Chọn";
            this.lke_ConstractionItem.Size = new System.Drawing.Size(291, 22);
            this.lke_ConstractionItem.TabIndex = 403;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Location = new System.Drawing.Point(45, 83);
            this.labelControl19.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(63, 16);
            this.labelControl19.TabIndex = 404;
            this.labelControl19.Text = "Hạng Mục";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(431, 114);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(8, 16);
            this.labelControl12.TabIndex = 400;
            this.labelControl12.Text = "*";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl14.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseForeColor = true;
            this.labelControl14.Location = new System.Drawing.Point(460, 41);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(8, 16);
            this.labelControl14.TabIndex = 393;
            this.labelControl14.Text = "*";
            // 
            // btn_AddConstruction
            // 
            this.btn_AddConstruction.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddConstruction.ImageOptions.Image")));
            this.btn_AddConstruction.Location = new System.Drawing.Point(431, 38);
            this.btn_AddConstruction.Name = "btn_AddConstruction";
            this.btn_AddConstruction.Size = new System.Drawing.Size(23, 23);
            this.btn_AddConstruction.TabIndex = 391;
            this.btn_AddConstruction.Click += new System.EventHandler(this.btn_AddConstruction_Click);
            // 
            // lke_Constraction
            // 
            this.lke_Constraction.Location = new System.Drawing.Point(134, 39);
            this.lke_Constraction.Name = "lke_Constraction";
            this.lke_Constraction.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lke_Constraction.Properties.Appearance.Options.UseFont = true;
            this.lke_Constraction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_Constraction.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("construction_id_custom", "Mã Công Trình"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("construction_name", "Tên Công Trình")});
            this.lke_Constraction.Properties.NullText = "Chọn";
            this.lke_Constraction.Size = new System.Drawing.Size(291, 22);
            this.lke_Constraction.TabIndex = 375;
            this.lke_Constraction.EditValueChanged += new System.EventHandler(this.lke_Constraction_EditValueChanged);
            // 
            // date_Start
            // 
            this.date_Start.EditValue = null;
            this.date_Start.Location = new System.Drawing.Point(134, 114);
            this.date_Start.Name = "date_Start";
            this.date_Start.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_Start.Properties.Appearance.Options.UseFont = true;
            this.date_Start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_Start.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_Start.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.date_Start.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_Start.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.date_Start.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_Start.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.date_Start.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.date_Start.Size = new System.Drawing.Size(291, 22);
            this.date_Start.TabIndex = 377;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(40, 45);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(68, 16);
            this.labelControl9.TabIndex = 387;
            this.labelControl9.Text = "Công Trình";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(16, 120);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 16);
            this.labelControl2.TabIndex = 386;
            this.labelControl2.Text = "Ngày Bắt Đầu";
            // 
            // btn_Img
            // 
            this.btn_Img.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Img.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Img.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Img.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_Img.Appearance.Options.UseBackColor = true;
            this.btn_Img.Appearance.Options.UseFont = true;
            this.btn_Img.Appearance.Options.UseForeColor = true;
            this.btn_Img.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Img.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Img.ImageOptions.Image")));
            this.btn_Img.Location = new System.Drawing.Point(618, 214);
            this.btn_Img.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Img.Name = "btn_Img";
            this.btn_Img.Size = new System.Drawing.Size(100, 23);
            this.btn_Img.TabIndex = 380;
            this.btn_Img.Text = "Hình ảnh";
            this.btn_Img.Click += new System.EventHandler(this.btn_Img_Click);
            // 
            // but_Exit
            // 
            this.but_Exit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Exit.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Exit.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.but_Exit.Appearance.ForeColor = System.Drawing.Color.White;
            this.but_Exit.Appearance.Options.UseBackColor = true;
            this.but_Exit.Appearance.Options.UseFont = true;
            this.but_Exit.Appearance.Options.UseForeColor = true;
            this.but_Exit.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.but_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("but_Exit.ImageOptions.Image")));
            this.but_Exit.Location = new System.Drawing.Point(431, 270);
            this.but_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.but_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.but_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(110, 36);
            this.but_Exit.TabIndex = 379;
            this.but_Exit.Text = "Đóng";
            this.but_Exit.ToolTipTitle = "ESC";
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Add.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Add.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Appearance.Options.UseBackColor = true;
            this.btn_Add.Appearance.Options.UseFont = true;
            this.btn_Add.Appearance.Options.UseForeColor = true;
            this.btn_Add.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btn_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.ImageOptions.Image")));
            this.btn_Add.Location = new System.Drawing.Point(283, 270);
            this.btn_Add.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Add.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Add.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn_Add.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(110, 36);
            this.btn_Add.TabIndex = 378;
            this.btn_Add.Text = "Thêm Mới";
            this.btn_Add.ToolTipTitle = "Ctrl +S";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // pic_Logo
            // 
            this.pic_Logo.Location = new System.Drawing.Point(573, 38);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_Logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pic_Logo.Size = new System.Drawing.Size(176, 169);
            this.pic_Logo.TabIndex = 381;
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(134, 185);
            this.txt_description.Name = "txt_description";
            this.txt_description.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.Properties.Appearance.Options.UseFont = true;
            this.txt_description.Size = new System.Drawing.Size(291, 22);
            this.txt_description.TabIndex = 407;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(61, 189);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 408;
            this.labelControl1.Text = "Ghi Chú";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(755, 38);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(8, 16);
            this.labelControl3.TabIndex = 409;
            this.labelControl3.Text = "*";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(431, 190);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(8, 16);
            this.labelControl5.TabIndex = 412;
            this.labelControl5.Text = "*";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(16, 157);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(92, 16);
            this.labelControl6.TabIndex = 386;
            this.labelControl6.Text = "Ngày Kết Thúc";
            // 
            // date_End
            // 
            this.date_End.EditValue = null;
            this.date_End.Location = new System.Drawing.Point(134, 151);
            this.date_End.Name = "date_End";
            this.date_End.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_End.Properties.Appearance.Options.UseFont = true;
            this.date_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_End.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_End.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.date_End.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_End.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.date_End.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_End.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.date_End.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.date_End.Size = new System.Drawing.Size(291, 22);
            this.date_End.TabIndex = 377;
            // 
            // frm_NewProgress
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 345);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.btn_AddBuildingContractor);
            this.Controls.Add(this.lke_ConstractionItem);
            this.Controls.Add(this.labelControl19);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.btn_AddConstruction);
            this.Controls.Add(this.lke_Constraction);
            this.Controls.Add(this.date_End);
            this.Controls.Add(this.date_Start);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_Img);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.pic_Logo);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_NewProgress";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIẾN ĐỘ HẠNG MỤC";
            this.Load += new System.EventHandler(this.frm_NewProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lke_ConstractionItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_Constraction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_Start.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_Start.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_description.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_End.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_End.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.SimpleButton btn_AddBuildingContractor;
        private DevExpress.XtraEditors.LookUpEdit lke_ConstractionItem;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.SimpleButton btn_AddConstruction;
        private DevExpress.XtraEditors.LookUpEdit lke_Constraction;
        private DevExpress.XtraEditors.DateEdit date_Start;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Img;
        private DevExpress.XtraEditors.SimpleButton but_Exit;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.PictureEdit pic_Logo;
        private DevExpress.XtraEditors.TextEdit txt_description;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit date_End;
    }
}