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
    public partial class frm_Vendor : DevExpress.XtraEditors.XtraForm
    {
        BUS.VendorBus vendorBus = new VendorBus( );
        BUS.SupliesBus supliesBus = new SupliesBus( );
        int index;

        public frm_Vendor()
        {
            InitializeComponent();
        }
        void loadAllVenDor()
        {
            grdc_Vendor.DataSource = vendorBus.loadAllVendor();
        }
        private void frm_Vendor_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_Vendor, grdv_Vendor);
            loadAllVenDor();
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
        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdv_Vendor.ClearColumnsFilter();
            loadAllVenDor();
        }

        private void grdv_Vendor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Vendor.RowCount > 0)
            {
                if (index >= 0)
                {
                    Int64 vendorId = Convert.ToInt64(grdv_Vendor.GetRowCellValue(index, "vendor_id").ToString());

                    if (vendorId != 1)
                    {
                        bool boolChangeSupliesWithVendor = supliesBus.changeSuppliesWithVendor(vendorId);
                        if (boolChangeSupliesWithVendor == true)
                        {
                            string vendorName = grdv_Vendor.GetRowCellValue(index, "vendor_name").ToString();

                            bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Nhà Cung Cấp '", vendorName);

                            if (boolCheckDelete == true)
                            {





                                bool boolDeleteBuildContractor = vendorBus.deleteVendor(vendorId);
                                if (boolDeleteBuildContractor == true)
                                {
                                    messeage.success("Xóa Nhà Cung cấp Thành Công!");


                                    loadAllVenDor();
                                }
                                else
                                {
                                    messeage.error("Xóa Nhà Cung Cấp  Thất Bại!");

                                }
                            }
                        }
                        else
                        {
                            messeage.error("Xóa Nhà Cung Cấp  Thất Bại!");
                        }

                    }
                    else
                    {
                        messeage.error("Bạn Không Thể Xóa Nhóm Này!");
                    }
                }
            }
            else
            {
                messeage.error("Không Có gì Để Xóa!!");
            }
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewVendor frm = new frm_NewVendor();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.Show();
        }
        private void dongform(object sender, EventArgs e)
        {
            loadAllVenDor();
            
        }
        

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
           
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Vendor.RowCount > 0)
            {
                if (index >= 0)
                {
                    frm_UpdateVendor frm = new frm_UpdateVendor();
                    frm.FormClosed += new FormClosedEventHandler(dongform);
                    frm.vendorId = Convert.ToInt64(grdv_Vendor.GetRowCellValue(index, "vendor_id").ToString());
                    frm.Show();
                }
            }
            else
            {
                messeage.error("Không Có Nhà Cung Cấp Để Chĩnh Sửa");
            }
           
        }

        private void tabPane2_Click(object sender, EventArgs e)
        {

        }
    }
}