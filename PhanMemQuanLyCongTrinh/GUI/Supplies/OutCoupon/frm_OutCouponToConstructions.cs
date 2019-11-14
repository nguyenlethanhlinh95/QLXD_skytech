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
    public partial class frm_OutCouponToConstructions : DevExpress.XtraEditors.XtraForm
    {

        BUS.OutCouponSuppliesToConstructionBus outCoupon = new BUS.OutCouponSuppliesToConstructionBus();
        BUS.DetailOutCouponSuppliesBus detailOutCoupon = new BUS.DetailOutCouponSuppliesBus();
        BUS.StorehouseDetailBus storehouseDetailBus = new BUS.StorehouseDetailBus();
        Int32 index;
        public frm_OutCouponToConstructions()
        {
            InitializeComponent();
        }
        public void loadAllOutCoupon()
        {
            grdc_OutCoupon.DataSource = outCoupon.getAllOutCouponToConstruction();
        }

        private void frm_OutCouponToConstructions_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_OutCoupon, grdv_OutCoupon);
            loadAllOutCoupon();
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
        private void date_Start_EditValueChanged(object sender, EventArgs e)
        {

            if (date_Start.Text != "")
            {
                if (date_End.Text == "")
                {
                    DateTime date = Convert.ToDateTime(date_Start.Text);
                    grdc_OutCoupon.DataSource = outCoupon.getOutCouponToConstructionWithDayStar(date);
                }
                else
                {
                    DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                    DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                    grdc_OutCoupon.DataSource = outCoupon.getOutCouponToConstructionWithDayStarDayEnd(dateStart, dateEnd);
                }
            }
        }

        private void date_End_EditValueChanged(object sender, EventArgs e)
        {
            if (date_Start.Text != "" && date_End.Text != "")
            {
                DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                grdc_OutCoupon.DataSource = outCoupon.getOutCouponToConstructionWithDayStarDayEnd(dateStart, dateEnd);
            }
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            date_End.Text = "";
            date_Start.Text = "";
            loadAllOutCoupon();
        
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewOutCouponToConstructions frm = new frm_NewOutCouponToConstructions();
            frm.FormClosed += new FormClosedEventHandler(dongform);

            frm.ShowDialog();
        }

        private void dongform(object sender, EventArgs e)
        {
            loadAllOutCoupon();

        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_OutCoupon.RowCount > 0)
            {
                Int64 outCouponId = Convert.ToInt64(grdv_OutCoupon.GetRowCellValue(index, "out_coupon_supplies_id").ToString());
                string outCouponName = grdv_OutCoupon.GetRowCellValue(index, "out_coupon_supplies_id_custom").ToString();

                bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Nhà Cung Cấp ", outCouponName);

                if (boolCheckDelete == true)
                {
                    var detailOC = detailOutCoupon.getDetailCouponWithOutCouton(outCouponId);

                    foreach (var item in detailOC)
                    {
                        Int64 suppliesId = Convert.ToInt64(item.GetType().GetProperty("supplies_id").GetValue(item, null).ToString());
                        Int64 storehouseID = Convert.ToInt64(item.GetType().GetProperty("storehouse_id").GetValue(item, null).ToString());
                        Int32 quality = Convert.ToInt32(item.GetType().GetProperty("detail_out_coupon_supplies_quantity").GetValue(item, null).ToString());
                        storehouseDetailBus.updateEnterSuppliesQuality(storehouseID, suppliesId, quality);
                    }




                    bool boolDeleteDetailOutCoupon = detailOutCoupon.deleteOutCoupon(outCouponId);
                    if (boolDeleteDetailOutCoupon == true)
                    {

                        bool boolDeleteOutCoupon = outCoupon.deleteOutCoupon(outCouponId);
                        if (boolDeleteOutCoupon == true)
                        {
                            messeage.success("Xóa Thành Công!");


                            loadAllOutCoupon();
                        }
                        else
                        {
                            messeage.error("Xóa Thất Bại!");

                        }
                    }
                    else
                    {
                        messeage.error("Xóa Thất Bại!");
                    }

                }

            }
            else
            {
                messeage.error("Không Có gì Để Xóa!!");
            }
        }

        private void grdv_OutCoupon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_OutCoupon.RowCount > 0)
            {
                frm_UpdateOutCouponToConstructions frm = new frm_UpdateOutCouponToConstructions();
                frm.FormClosed += new FormClosedEventHandler(dongform);
                frm.outCouponId = Convert.ToInt64(grdv_OutCoupon.GetRowCellValue(index, "out_coupon_supplies_id").ToString());
                frm.ShowDialog();
            }
            else
            {
                messeage.error("Không Có Gì Để Chỉnh Sửa!");
            }
        }
    }
}