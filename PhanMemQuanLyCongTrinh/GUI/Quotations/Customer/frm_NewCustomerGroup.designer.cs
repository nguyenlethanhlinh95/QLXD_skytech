﻿namespace PhanMemQuanLyCongTrinh
{
    partial class frm_NewCustomerGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NewCustomerGroup));
            this.but_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.but_Update = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_CustomerGroupName = new DevExpress.XtraEditors.LabelControl();
            this.txt_CustomerGroupName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerGroupName.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.but_Exit.Location = new System.Drawing.Point(313, 84);
            this.but_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.but_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.but_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(126, 36);
            this.but_Exit.TabIndex = 16;
            this.but_Exit.Text = "Đóng";
            this.but_Exit.ToolTipTitle = "ESC";
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // but_Update
            // 
            this.but_Update.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Update.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.but_Update.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.but_Update.Appearance.ForeColor = System.Drawing.Color.White;
            this.but_Update.Appearance.Options.UseBackColor = true;
            this.but_Update.Appearance.Options.UseFont = true;
            this.but_Update.Appearance.Options.UseForeColor = true;
            this.but_Update.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.but_Update.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("but_Update.ImageOptions.Image")));
            this.but_Update.Location = new System.Drawing.Point(147, 84);
            this.but_Update.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.but_Update.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.but_Update.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Update.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Update.Name = "but_Update";
            this.but_Update.Size = new System.Drawing.Size(127, 36);
            this.but_Update.TabIndex = 15;
            this.but_Update.Text = "Thêm Mới";
            this.but_Update.ToolTipTitle = "Ctrl +S";
            this.but_Update.Click += new System.EventHandler(this.but_Update_Click);
            // 
            // lbl_CustomerGroupName
            // 
            this.lbl_CustomerGroupName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CustomerGroupName.Appearance.Options.UseFont = true;
            this.lbl_CustomerGroupName.Location = new System.Drawing.Point(41, 30);
            this.lbl_CustomerGroupName.Name = "lbl_CustomerGroupName";
            this.lbl_CustomerGroupName.Size = new System.Drawing.Size(142, 16);
            this.lbl_CustomerGroupName.TabIndex = 18;
            this.lbl_CustomerGroupName.Text = "Tên Nhóm Khách Hàng";
            this.lbl_CustomerGroupName.Click += new System.EventHandler(this.lbl_CustomerGroupName_Click);
            // 
            // txt_CustomerGroupName
            // 
            this.txt_CustomerGroupName.Location = new System.Drawing.Point(191, 28);
            this.txt_CustomerGroupName.Name = "txt_CustomerGroupName";
            this.txt_CustomerGroupName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CustomerGroupName.Properties.Appearance.Options.UseFont = true;
            this.txt_CustomerGroupName.Size = new System.Drawing.Size(304, 22);
            this.txt_CustomerGroupName.TabIndex = 20;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(501, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 16);
            this.labelControl1.TabIndex = 293;
            this.labelControl1.Text = "*";
            // 
            // frm_NewCustomerGroup
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 164);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_CustomerGroupName);
            this.Controls.Add(this.lbl_CustomerGroupName);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.but_Update);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_NewCustomerGroup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHÓM KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.frm_NewCustomerGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerGroupName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton but_Exit;
        private DevExpress.XtraEditors.SimpleButton but_Update;
        private DevExpress.XtraEditors.LabelControl lbl_CustomerGroupName;
        private DevExpress.XtraEditors.TextEdit txt_CustomerGroupName;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}