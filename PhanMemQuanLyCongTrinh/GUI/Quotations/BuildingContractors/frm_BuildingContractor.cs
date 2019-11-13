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
    public partial class frm_BuildingContractor : DevExpress.XtraEditors.XtraForm
    {
        BUS.BuildingContractorBus buildingContractorBus = new BUS.BuildingContractorBus( );
          
        int index;
        
        public frm_BuildingContractor()
        {
            InitializeComponent();
        }

        private void loadAllBuildingContractor()
        {
            grdc_BuidingContractor.DataSource = buildingContractorBus.loadAllBuildingContractor();
                
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
        private void frm_BuildingContractor_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_BuidingContractor, grdv_BuidingContractor);
            loadAllBuildingContractor();
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdv_BuidingContractor.ClearColumnsFilter();
            loadAllBuildingContractor();
        }

        private void grdv_BuidingContractor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
           
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                

                if (grdv_BuidingContractor.RowCount > 0)
                {
                    if (index >= 0)
                    {
                        Int64 buildingContractorId = Convert.ToInt64(grdv_BuidingContractor.GetRowCellValue(index, "building_contractor_id").ToString());
                        string buildingContractorName = grdv_BuidingContractor.GetRowCellValue(index, "building_contractor_name").ToString();


                        bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Thầu '", buildingContractorName);

                        if (boolCheckDelete == true)
                        {
                            bool boolDeleteBuildContractor = buildingContractorBus.deleteBuildingContractor(buildingContractorId);
                            if (boolDeleteBuildContractor == true)
                            {
                                messeage.success("Xóa Thầu Xây Dựng Thành Công!");

                                buildingContractorId = 0;

                                loadAllBuildingContractor();

                            }
                            else
                            {
                                messeage.error("Xóa Thầu Xây Dựng Không Thất Bại!");

                            }
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
             
            frm_NewBuildingContractor frm = new frm_NewBuildingContractor();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            
            frm.ShowDialog();
            
        }


        private void dongform(object sender, EventArgs e)
        {
            loadAllBuildingContractor();
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_BuidingContractor.RowCount > 0)
            {
                if (index >= 0)
                {
                    frm_UpdateBuildingContractor frm = new frm_UpdateBuildingContractor();
                    frm.FormClosed += new FormClosedEventHandler(dongform);
                    frm.buildingContractorId = Convert.ToInt64(grdv_BuidingContractor.GetRowCellValue(index, "building_contractor_id").ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                messeage.error("Không Có gì Để Sửa!!!");
            }
        }
    }
}