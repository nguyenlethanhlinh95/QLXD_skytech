﻿namespace PhanMemQuanLyCongTrinh
{
    partial class frm_department
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_department));
            this.txt_deparment = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.but_Update = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_deparment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_deparment
            // 
            this.txt_deparment.Location = new System.Drawing.Point(241, 50);
            this.txt_deparment.Name = "txt_deparment";
            this.txt_deparment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_deparment.Properties.Appearance.Options.UseFont = true;
            this.txt_deparment.Size = new System.Drawing.Size(229, 22);
            this.txt_deparment.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(143, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Tên chức vụ";
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
            this.but_Update.Location = new System.Drawing.Point(360, 100);
            this.but_Update.LookAndFeel.SkinMaskColor = System.Drawing.Color.RoyalBlue;
            this.but_Update.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.but_Update.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Update.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Update.Name = "but_Update";
            this.but_Update.Size = new System.Drawing.Size(110, 36);
            this.but_Update.TabIndex = 16;
            this.but_Update.Text = "Thêm mới";
            this.but_Update.ToolTipTitle = "Ctrl +S";
            this.but_Update.Click += new System.EventHandler(this.but_Update_Click);
            // 
            // frm_department
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 176);
            this.Controls.Add(this.but_Update);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_deparment);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frm_department";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MỚI CHỨC VỤ";
            ((System.ComponentModel.ISupportInitialize)(this.txt_deparment.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_deparment;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton but_Update;
    }
}