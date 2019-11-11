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
    public partial class frm_EnterCoupon : DevExpress.XtraEditors.XtraForm
    {
        BUS.EnterCouponSuppliesBus enterCouponBus = new BUS.EnterCouponSuppliesBus( );

        int index;
        public Int64 idEnter = 0;
        public frm_EnterCoupon()
        {
            InitializeComponent();
        }

        private void loadAllEnterCoupon()
        {
            grdc_EnterCoupon.DataSource = enterCouponBus.getAllEnterCoupon();
        }
        private void frm_EnterCoupon_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_EnterCoupon, grdv_EnterCoupon);
            loadAllEnterCoupon();            
        }

        private void date_Start_EditValueChanged(object sender, EventArgs e)
        {
            if (date_Start.Text != "")
            {
                if (date_End.Text == "")
                {
                    DateTime date = Convert.ToDateTime(date_Start.Text);
                    grdc_EnterCoupon.DataSource = enterCouponBus.getEnterCouponWithDayStar(date);
                }
                else
                {
                    DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                    DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                    grdc_EnterCoupon.DataSource = enterCouponBus.getEnterCouponWithDayStarDayEnd(dateStart, dateEnd);
                }
            }
        }

        private void date_End_EditValueChanged(object sender, EventArgs e)
        {
            if (date_Start.Text != "" && date_End.Text != "")
            {
                DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                grdc_EnterCoupon.DataSource = enterCouponBus.getEnterCouponWithDayStarDayEnd(dateStart, dateEnd);
            }
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            date_End.Text = "";
            date_Start.Text = "";
            loadAllEnterCoupon();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            grdc_EnterCoupon.ExportToXls("D:/asv.xls");
        }

        private void grdv_EnterCoupon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;

            if ( index >= 0 )
            {
                idEnter = Convert.ToInt64(grdv_EnterCoupon.GetRowCellValue(index, "enter_coupon_supplies_id").ToString( ));
            }
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (idEnter == 0)
            {
                messeage.error("Bạn chưa chọn dữ liệu !");
            }
            else
            {
                frm_AddNewEnterCouponSupplies frm = new frm_AddNewEnterCouponSupplies();
                frm.checkEdit = 1;
                frm.idEnterSupplies = idEnter;

                frm.FormClosed += new FormClosedEventHandler(dongformEnter);
                frm.ShowDialog();
            }
        }

        private void dongformEnter(object sender, EventArgs e)
        {
            loadAllEnterCoupon();
        }

  
        

        
    }
}