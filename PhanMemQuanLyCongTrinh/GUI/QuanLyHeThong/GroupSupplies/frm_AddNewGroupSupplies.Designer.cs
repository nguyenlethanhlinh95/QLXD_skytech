﻿namespace PhanMemQuanLyCongTrinh
{
    partial class frm_AddNewGroupSupplies
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
            if ( disposing && (components != null) )
            {
                components.Dispose( );
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddNewGroupSupplies));
            this.but_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.btn_New = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
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
            this.but_Exit.Location = new System.Drawing.Point(319, 98);
            this.but_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.but_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.but_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(110, 36);
            this.but_Exit.TabIndex = 21;
            this.but_Exit.Text = "Đóng";
            this.but_Exit.ToolTipTitle = "ESC";
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(105, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 14);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Tên nhóm vật tư";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(241, 43);
            this.txt_name.Name = "txt_name";
            this.txt_name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_name.Properties.Appearance.Options.UseFont = true;
            this.txt_name.Size = new System.Drawing.Size(229, 22);
            this.txt_name.TabIndex = 18;
            // 
            // btn_New
            // 
            this.btn_New.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_New.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_New.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btn_New.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_New.Appearance.Options.UseBackColor = true;
            this.btn_New.Appearance.Options.UseFont = true;
            this.btn_New.Appearance.Options.UseForeColor = true;
            this.btn_New.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btn_New.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_New.ImageOptions.Image")));
            this.btn_New.Location = new System.Drawing.Point(183, 98);
            this.btn_New.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_New.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_New.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn_New.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_New.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(110, 36);
            this.btn_New.TabIndex = 276;
            this.btn_New.Text = "Thêm mới";
            this.btn_New.ToolTipTitle = "Ctrl +S";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // frm_AddNewGroupSupplies
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 176);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_name);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frm_AddNewGroupSupplies";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MỚI NHÓM VẬT TƯ";
            this.Load += new System.EventHandler(this.frm_AddNewGroupSupplies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton but_Exit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_name;
        private DevExpress.XtraEditors.SimpleButton btn_New;
    }
}