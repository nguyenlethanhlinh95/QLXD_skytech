namespace PhanMemQuanLyCongTrinh
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
            this.btn_AddNew = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            // btn_AddNew
            // 
            this.btn_AddNew.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btn_AddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_AddNew.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_AddNew.Appearance.Options.UseBackColor = true;
            this.btn_AddNew.Appearance.Options.UseFont = true;
            this.btn_AddNew.Appearance.Options.UseForeColor = true;
            this.btn_AddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddNew.ImageOptions.Image")));
            this.btn_AddNew.Location = new System.Drawing.Point(369, 96);
            this.btn_AddNew.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btn_AddNew.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Transparent;
            this.btn_AddNew.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_AddNew.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_AddNew.Name = "btn_AddNew";
            this.btn_AddNew.Size = new System.Drawing.Size(100, 30);
            this.btn_AddNew.TabIndex = 2;
            this.btn_AddNew.Text = "Thêm Mới";
            this.btn_AddNew.Click += new System.EventHandler(this.btn_AddNew_Click);
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
            // frm_department
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 176);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_AddNew);
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
        private DevExpress.XtraEditors.SimpleButton btn_AddNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}