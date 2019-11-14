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
    public partial class frm_IncomeCoupon : DevExpress.XtraEditors.XtraForm
    {
        BUS.IncomeCouponBus IncomeCouponBus = new BUS.IncomeCouponBus();
        Int32 index;
        public frm_IncomeCoupon()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.N | Keys.Control):
                    btn_Add.PerformClick();
                    break;
                case (Keys.E | Keys.Control):
                    btn_Edit.PerformClick();
                    break;
                case (Keys.Delete | Keys.Control):
                    btn_Delete.PerformClick();
                    break;
                case (Keys.F5 | Keys.Control):
                    btn_Refesh.PerformClick();
                    break;
                //case (Keys.R | Keys.Control):
                //    btn_.PerformClick( );
                //    break;
                case (Keys.F8 | Keys.Control):
                    btn_Import.PerformClick();
                    break;
                case (Keys.F9 | Keys.Control):
                    btn_Export.PerformClick();
                    break;
                case (Keys.P | Keys.Control):
                    btn_Print.PerformClick();
                    break;
                case (Keys.Escape):
                    btn_Close.PerformClick();
                    break;

            }
            // return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void loadAllIncomeCoupon()
        {
            grdc_Receipts.DataSource = IncomeCouponBus.getAllIncomeCouponConstruction();
        }
        private void loadIncomeCouponWithDayStart()
        {
            if (date_Start.Text != "")
            {
                if (date_End.Text == "")
                {
                    DateTime date = Convert.ToDateTime(date_Start.Text);
                    grdc_Receipts.DataSource = IncomeCouponBus.getAllIncomeCouponConstructionWithDayStar(date);
                }
                else
                {
                    DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                    DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                    grdc_Receipts.DataSource = IncomeCouponBus.getAllIncomeCouponConstructionWithDayStarDayEnd(dateStart, dateEnd);
                }
            }
        }
        private void loadIncomeCouponWithDayStartDayEnd()
        {
            DateTime dateStart = Convert.ToDateTime(date_Start.Text);
            DateTime dateEnd = Convert.ToDateTime(date_End.Text);
            grdc_Receipts.DataSource = IncomeCouponBus.getAllIncomeCouponConstructionWithDayStarDayEnd(dateStart, dateEnd);
        }


        private void frm_ReceiptsConstruction_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_Receipts, grdv_Receipts);
            loadAllIncomeCoupon();
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadAllIncomeCoupon();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Receipts.RowCount > 0)
            {
                if (index >= 0)
                {
                    Int64 incomeCoupon = Convert.ToInt64(grdv_Receipts.GetRowCellValue(index, "income_coupon_id").ToString());
                    String incomeCouponName = grdv_Receipts.GetRowCellValue(index, "income_coupon_id_custom").ToString();
                    bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Phiếu Thu '", incomeCouponName);

                    if (boolCheckDelete == true)
                    {





                        bool boolDeleteBuildContractor = IncomeCouponBus.deleteIncomeCoupon(incomeCoupon);
                        if (boolDeleteBuildContractor == true)
                        {
                            messeage.success("Xóa Nhà Cung cấp Thành Công!");


                            loadAllIncomeCoupon();
                        }
                        else
                        {
                            messeage.error("Xóa Nhà Cung Cấp  Thất Bại!");

                        }
                    }
                }
                else {
                    messeage.error("Bạn Chưa Chọn!");
                }

            }
            else
            {
                messeage.error("Không Có Gì Để Xóa!");
            }
        }

        private void grdv_Receipts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void date_Start_EditValueChanged(object sender, EventArgs e)
        {
            loadIncomeCouponWithDayStart();
        }

        private void date_End_EditValueChanged(object sender, EventArgs e)
        {
            loadIncomeCouponWithDayStartDayEnd();
        }
    }
}