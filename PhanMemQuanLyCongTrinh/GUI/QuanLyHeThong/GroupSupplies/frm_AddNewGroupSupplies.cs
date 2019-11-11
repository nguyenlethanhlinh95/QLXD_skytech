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
    public partial class frm_AddNewGroupSupplies : DevExpress.XtraEditors.XtraForm
    {
        public frm_AddNewGroupSupplies( )
        {
            InitializeComponent( );
        }

        Group_suppliesBus _group = new Group_suppliesBus();

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txt_name.Text != "" )
                {
                    bool status = _group.insert(txt_name.Text);

                    if ( status )
                    {
                        messeage.success("Thêm mới thành công !");

                        this.Close( );
                    }
                    else
                    {
                        messeage.error("Không thể thêm mới !");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Dữ liệu trống?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                messeage.error("Không thể thêm mới !");
            }
        }

        private void frm_AddNewGroupSupplies_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_New;
        }

        
    }
}