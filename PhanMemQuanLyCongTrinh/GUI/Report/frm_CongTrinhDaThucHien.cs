﻿using System;
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
    public partial class frm_CongTrinhDaThucHien : DevExpress.XtraEditors.XtraForm
    {
        public frm_CongTrinhDaThucHien( )
        {
            InitializeComponent( );
        }

        ConstructionBus _contruct = new ConstructionBus( );

        private void frm_CongTrinhDaThucHien_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_CongTrinhDaThucHien, grdv_CongTrinhDaThucHien);
            try
            {
                var data = _contruct.getAllContruct_DaThucHien( );
                if ( data != null )
                {
                    grdc_CongTrinhDaThucHien.DataSource = data;
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