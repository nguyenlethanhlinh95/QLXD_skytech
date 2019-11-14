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
using PhanMemQuanLyCongTrinh.GUI.FileMau;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_DanhSachFileMau : DevExpress.XtraEditors.XtraForm
    {
        public frm_DanhSachFileMau( )
        {
            InitializeComponent( );
        }

        FileMauBus _file = new FileMauBus();

        private void frm_DanhSachFileMau_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_FileMau, grdv_FileMau);
            loadGridView( );
        }

        private void loadGridView( )
        {
            var datasource = _file.getAll( );
            if ( datasource != null )
            {
                grdc_FileMau.DataSource = datasource;
            }
            else
            {
                messeage.error("Không thể tải dữ liệu !");
            }
        }


        private void dongform(object sender, EventArgs e)
        {
            loadGridView( );

        }

        private void btn_Add_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddNewFileMau frm = new frm_AddNewFileMau( );
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.ShowDialog( );
        }
    }
}