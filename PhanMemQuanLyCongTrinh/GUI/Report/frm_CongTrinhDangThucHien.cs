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
    public partial class frm_CongTrinhDangThucHien : DevExpress.XtraEditors.XtraForm
    {
        public frm_CongTrinhDangThucHien( )
        {
            InitializeComponent( );
        }

        ConstructionBus _contruct = new ConstructionBus();

        private void frm_CongTrinhDangThucHien_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_CongTrinhDangThucHien, grdv_CongTrinhDangThucHien);
            try
            {
                var data = _contruct.getAllContruct_DangThucHien( );
                if ( data != null )
                {
                    grdc_CongTrinhDangThucHien.DataSource = data;
                }
                else
                {
                    messeage.warnning("Dữ liệu rỗng !");
                }
            }
            catch ( Exception )
            {
                messeage.err( );
            }
            
        }

    }
}