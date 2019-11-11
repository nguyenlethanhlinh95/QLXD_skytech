using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyCongTrinh.BUS;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Newdepartment : DevExpress.XtraEditors.XtraForm
    {
        public frm_Newdepartment( )
        {
            InitializeComponent( );
        }

        DeparmentBus depBus = new DeparmentBus();



        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_department_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_New;
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            if ( txt_deparment.Text != "" )
            {
                bool status = depBus.insert(txt_deparment.Text);

                if ( status )
                {
                    messeage.success("Thêm mới thành công");

                    this.Close( );
                }
                else
                {
                    messeage.error("Không thể thêm mới");
                }
            }
            else
            {
                XtraMessageBox.Show("Dữ liệu trống?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

 
    }
}