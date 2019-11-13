namespace PhanMemQuanLyCongTrinh
{
    partial class frm_UpdateAccountingAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UpdateAccountingAccounts));
            this.btn_AddAcountingAccount = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lke_AcountingAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_AAName = new DevExpress.XtraEditors.TextEdit();
            this.txt_AAId = new DevExpress.XtraEditors.TextEdit();
            this.lbl_CustomerGroupName = new DevExpress.XtraEditors.LabelControl();
            this.lbl_CustomerGroupId = new DevExpress.XtraEditors.LabelControl();
            this.but_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.but_Update = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lke_AcountingAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AAName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AAId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AddAcountingAccount
            // 
            this.btn_AddAcountingAccount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddAcountingAccount.ImageOptions.Image")));
            this.btn_AddAcountingAccount.Location = new System.Drawing.Point(630, 95);
            this.btn_AddAcountingAccount.Name = "btn_AddAcountingAccount";
            this.btn_AddAcountingAccount.Size = new System.Drawing.Size(23, 23);
            this.btn_AddAcountingAccount.TabIndex = 325;
            this.btn_AddAcountingAccount.Click += new System.EventHandler(this.btn_AddAcountingAccount_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(616, 101);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(8, 16);
            this.labelControl3.TabIndex = 324;
            this.labelControl3.Text = "*";
            // 
            // lke_AcountingAccount
            // 
            this.lke_AcountingAccount.Location = new System.Drawing.Point(306, 97);
            this.lke_AcountingAccount.Name = "lke_AcountingAccount";
            this.lke_AcountingAccount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lke_AcountingAccount.Properties.Appearance.Options.UseFont = true;
            this.lke_AcountingAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_AcountingAccount.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("income_and_expenditure_pattern_id_custom", "Mã Nhóm Tài Khoản"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("income_and_expenditure_pattern_name", "Tên Nhóm Tài Khoản")});
            this.lke_AcountingAccount.Size = new System.Drawing.Size(304, 22);
            this.lke_AcountingAccount.TabIndex = 323;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(129, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(145, 16);
            this.labelControl2.TabIndex = 322;
            this.labelControl2.Text = "Nhóm Tài Khoản Kế Toán";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(616, 63);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 16);
            this.labelControl1.TabIndex = 321;
            this.labelControl1.Text = "*";
            // 
            // lbl1
            // 
            this.lbl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.lbl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Appearance.Options.UseFont = true;
            this.lbl1.Appearance.Options.UseForeColor = true;
            this.lbl1.Location = new System.Drawing.Point(616, 26);
            this.lbl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(8, 16);
            this.lbl1.TabIndex = 320;
            this.lbl1.Text = "*";
            // 
            // txt_AAName
            // 
            this.txt_AAName.Location = new System.Drawing.Point(306, 60);
            this.txt_AAName.Name = "txt_AAName";
            this.txt_AAName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AAName.Properties.Appearance.Options.UseFont = true;
            this.txt_AAName.Size = new System.Drawing.Size(304, 22);
            this.txt_AAName.TabIndex = 319;
            // 
            // txt_AAId
            // 
            this.txt_AAId.Enabled = false;
            this.txt_AAId.Location = new System.Drawing.Point(306, 23);
            this.txt_AAId.Name = "txt_AAId";
            this.txt_AAId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AAId.Properties.Appearance.Options.UseFont = true;
            this.txt_AAId.Size = new System.Drawing.Size(304, 22);
            this.txt_AAId.TabIndex = 318;
            // 
            // lbl_CustomerGroupName
            // 
            this.lbl_CustomerGroupName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CustomerGroupName.Appearance.Options.UseFont = true;
            this.lbl_CustomerGroupName.Location = new System.Drawing.Point(140, 63);
            this.lbl_CustomerGroupName.Name = "lbl_CustomerGroupName";
            this.lbl_CustomerGroupName.Size = new System.Drawing.Size(134, 16);
            this.lbl_CustomerGroupName.TabIndex = 317;
            this.lbl_CustomerGroupName.Text = "Tên Tài Khoản Kế Toán";
            // 
            // lbl_CustomerGroupId
            // 
            this.lbl_CustomerGroupId.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CustomerGroupId.Appearance.Options.UseFont = true;
            this.lbl_CustomerGroupId.Location = new System.Drawing.Point(145, 26);
            this.lbl_CustomerGroupId.Name = "lbl_CustomerGroupId";
            this.lbl_CustomerGroupId.Size = new System.Drawing.Size(129, 16);
            this.lbl_CustomerGroupId.TabIndex = 316;
            this.lbl_CustomerGroupId.Text = "Mã Tài Khoản Kế Toán";
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
            this.but_Exit.Location = new System.Drawing.Point(458, 142);
            this.but_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.but_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.but_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(110, 36);
            this.but_Exit.TabIndex = 315;
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
            this.but_Update.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("but_Add.ImageOptions.Image")));
            this.but_Update.Location = new System.Drawing.Point(304, 142);
            this.but_Update.LookAndFeel.SkinMaskColor = System.Drawing.Color.RoyalBlue;
            this.but_Update.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.but_Update.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Update.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Update.Name = "but_Update";
            this.but_Update.Size = new System.Drawing.Size(110, 36);
            this.but_Update.TabIndex = 314;
            this.but_Update.Text = "Cập Nhật";
            this.but_Update.ToolTipTitle = "Ctrl +S";
            this.but_Update.Click += new System.EventHandler(this.but_Update_Click);
            // 
            // frm_UpdateAccountingAccounts
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 195);
            this.Controls.Add(this.btn_AddAcountingAccount);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lke_AcountingAccount);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txt_AAName);
            this.Controls.Add(this.txt_AAId);
            this.Controls.Add(this.lbl_CustomerGroupName);
            this.Controls.Add(this.lbl_CustomerGroupId);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.but_Update);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_UpdateAccountingAccounts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỈNH SỬA TÀI KHOẢN KẾ TOÁN";
            this.Load += new System.EventHandler(this.frm_UpdateAccountingAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lke_AcountingAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AAName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AAId.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_AddAcountingAccount;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lke_AcountingAccount;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl1;
        private DevExpress.XtraEditors.TextEdit txt_AAName;
        private DevExpress.XtraEditors.TextEdit txt_AAId;
        private DevExpress.XtraEditors.LabelControl lbl_CustomerGroupName;
        private DevExpress.XtraEditors.LabelControl lbl_CustomerGroupId;
        private DevExpress.XtraEditors.SimpleButton but_Exit;
        private DevExpress.XtraEditors.SimpleButton but_Update;
    }
}