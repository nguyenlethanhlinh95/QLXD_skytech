using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_department : DevExpress.XtraEditors.XtraForm
    {
        public frm_department( )
        {
            InitializeComponent( );
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            if (txt_deparment.Text != "")
            {
                
            }
            else
            {
                XtraMessageBox.Show("Dữ liệu trống?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

 
    }
}