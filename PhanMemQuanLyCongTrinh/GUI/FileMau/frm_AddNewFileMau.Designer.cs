namespace PhanMemQuanLyCongTrinh.GUI.FileMau
{
    partial class frm_AddNewFileMau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddNewFileMau));
            this.btn_New = new DevExpress.XtraEditors.SimpleButton();
            this.but_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ten = new DevExpress.XtraEditors.TextEdit();
            this.btn_OpenFile = new DevExpress.XtraEditors.SimpleButton();
            this.txt_file = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_file.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.btn_New.Location = new System.Drawing.Point(182, 165);
            this.btn_New.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_New.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_New.LookAndFeel.SkinName = "Office 2010 Black";
            this.btn_New.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_New.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(110, 36);
            this.btn_New.TabIndex = 280;
            this.btn_New.Text = "Thêm mới";
            this.btn_New.ToolTipTitle = "Ctrl +S";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
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
            this.but_Exit.Location = new System.Drawing.Point(318, 165);
            this.but_Exit.LookAndFeel.SkinMaskColor = System.Drawing.Color.Gray;
            this.but_Exit.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.but_Exit.LookAndFeel.SkinName = "Office 2010 Black";
            this.but_Exit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.but_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(110, 36);
            this.but_Exit.TabIndex = 279;
            this.but_Exit.Text = "Đóng";
            this.but_Exit.ToolTipTitle = "ESC";
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(83, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 14);
            this.labelControl1.TabIndex = 278;
            this.labelControl1.Text = "Tên đại diện";
            // 
            // txt_ten
            // 
            this.txt_ten.Location = new System.Drawing.Point(181, 56);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_ten.Properties.Appearance.Options.UseFont = true;
            this.txt_ten.Size = new System.Drawing.Size(291, 22);
            this.txt_ten.TabIndex = 277;
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_OpenFile.ImageOptions.Image")));
            this.btn_OpenFile.Location = new System.Drawing.Point(478, 94);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(23, 23);
            this.btn_OpenFile.TabIndex = 369;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // txt_file
            // 
            this.txt_file.Enabled = false;
            this.txt_file.Location = new System.Drawing.Point(181, 94);
            this.txt_file.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_file.Name = "txt_file";
            this.txt_file.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_file.Properties.Appearance.Options.UseFont = true;
            this.txt_file.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_file.Size = new System.Drawing.Size(291, 22);
            this.txt_file.TabIndex = 368;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(81, 97);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(20, 16);
            this.labelControl8.TabIndex = 367;
            this.labelControl8.Text = "File";
            // 
            // frm_AddNewFileMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 248);
            this.Controls.Add(this.btn_OpenFile);
            this.Controls.Add(this.txt_file);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_ten);
            this.Name = "frm_AddNewFileMau";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_AddNewFileMau";
            ((System.ComponentModel.ISupportInitialize)(this.txt_ten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_file.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_New;
        private DevExpress.XtraEditors.SimpleButton but_Exit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_ten;
        private DevExpress.XtraEditors.SimpleButton btn_OpenFile;
        private DevExpress.XtraEditors.TextEdit txt_file;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}