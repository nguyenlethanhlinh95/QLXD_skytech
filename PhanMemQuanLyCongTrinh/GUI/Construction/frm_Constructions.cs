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
    public partial class frm_Constructions : DevExpress.XtraEditors.XtraForm
    {
        BUS.ConstructionBus constructionBus = new BUS.ConstructionBus( );
        BUS.ConstructionItemBus constructionItemBus = new BUS.ConstructionItemBus( );
        int indexConstruction;
        int indexConstructionItem;

        public frm_Constructions()
        {
            InitializeComponent();
        }
        private void loadContruction()
        {
            grdc_Construction.DataSource = constructionBus.getAllContruction();
        }
        private void loadContructionItem(Int64 constructionId)
        {
            grdc_ConstructionItem.DataSource = constructionItemBus.getContructionItemWithGroup(constructionId);
        }
        private void frm_Constructions_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_Construction, grdv_Construction);
            StyleDevxpressGridControl.styleGridControl(grdc_ConstructionItem, grdv_ConstructionItem);
            loadContruction();
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
        private void grdv_Construction_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            indexConstruction = e.FocusedRowHandle;
            if (indexConstruction >= 0)
            {
                Int64 ContructionIdd = Convert.ToInt64(grdv_Construction.GetRowCellValue(indexConstruction, "construction_id").ToString());
                loadContructionItem(ContructionIdd);
            }
        }

        private void btn_DeleteCustomerGroup_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Construction.RowCount > 0)
            {
                if (indexConstruction >= 0)
                {
                    Int64 constructionId = Convert.ToInt64(grdv_Construction.GetRowCellValue(indexConstruction, "construction_id").ToString());


                    var constructionName = grdv_Construction.GetRowCellValue(indexConstruction, "construction_name").ToString();

                    if (constructionItemBus.isContructionIdtemGroup(constructionId) == false)
                    {

                        bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Công Trình", constructionName);

                        if (boolCheckDelete == true)
                        {
                            bool boolDeleteCustomer = constructionBus.deleteContruction(constructionId);
                            if (boolDeleteCustomer == true)
                            {
                                messeage.success("Xóa Khách hàng Thành Công!");

                                loadContruction();
                            }
                            else
                            {
                                messeage.error("Xóa Khách hàng Không Thành Công!");

                            }
                        }
                    }
               
                else
                {
                    messeage.error("Vui Lòng Xóa Tất Cả Các hạng Mục Của Công Trình!");

                }
                }
                else
                {
                    messeage.error("Bạn Hãy Chọn Công  Trình Để Xóa!!!");

                }
            }
            else
            {
                messeage.error("Không có Gì Để Xóa!!!");

            }
            
        }

        private void btn_AddCustomerGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewConstructions frm = new frm_NewConstructions();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.ShowDialog();
        }
        private void dongform(object sender, EventArgs e)
        {
            loadContruction();
        }

        private void btn_EditCustomerGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Construction.RowCount > 0)
            {
                if (indexConstruction >= 0)
                {
                    frm_UpdateContruction frm = new frm_UpdateContruction();
                    frm.FormClosed += new FormClosedEventHandler(dongform);
                    frm.counstructionId = Convert.ToInt64(grdv_Construction.GetRowCellValue(indexConstruction, "construction_id").ToString());
                    frm.ShowDialog();
                }
                else
                {
                    messeage.error("Bạn Chưa Chọn Công Trình Để Chỉnh Sửa!");
                }
            }
            else
            {
                messeage.error("Không Có Gì Để Chỉnh Sửa!");
            }
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void loadAllConstructionItem()
        {
            grdc_ConstructionItem.DataSource = constructionItemBus.getAllContructionItem();  
        }
        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadAllConstructionItem();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_ConstructionItem.RowCount > 0)
            {
                if (indexConstructionItem >= 0)
                {
                    Int64 Id = Convert.ToInt64(grdv_ConstructionItem.GetRowCellValue(indexConstructionItem, "construction_item_id").ToString());
                    string Name = grdv_ConstructionItem.GetRowCellValue(indexConstructionItem, "construction_item_name").ToString();

                    bool boolCheckDelete = messeage.info("Bạn Có Muốn Hạng Mục ", Name);

                    if (boolCheckDelete == true)
                    {
                        bool boolDeleteBuildContractor = constructionItemBus.deleteConstructionItem(Id);
                        if (boolDeleteBuildContractor == true)
                        {
                            messeage.success("Xóa Hạng Mục Thành Công!");
                            if (indexConstruction >= 0)
                            {
                                Int64 ContructionIdd = Convert.ToInt64(grdv_Construction.GetRowCellValue(indexConstruction, "construction_id").ToString());
                                loadContructionItem(ContructionIdd);
                            }
                        }
                        else
                        {
                            messeage.error("Xóa Nhà Cung Cấp Không Thất Bại!");

                        }
                    }
                }
                else
                {
                    messeage.error("Bạn Hãy Chọn Hạng Mục Để Xóa!!");
                }

            }
            else
            {
                messeage.error("Không Có gì Để Xóa!!");
            }
        }

        private void grdv_ConstructionItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            indexConstructionItem = e.FocusedRowHandle;
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frm_NewConstructionItem frm = new frm_NewConstructionItem();
            frm.FormClosed += new FormClosedEventHandler(dongformItem);
            frm.ShowDialog();
        }
        private void dongformItem(object sender, EventArgs e)
        {
            if (grdv_Construction.RowCount > 0)
            {
                Int64 ContructionIdd = Convert.ToInt64(grdv_Construction.GetRowCellValue(indexConstruction, "construction_id").ToString());
                loadContructionItem(ContructionIdd);
            }
           
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_ConstructionItem.RowCount >= 0)
            {
                if (indexConstructionItem >= 0)
                {
                    frm_UpdateConstructionItem frm = new frm_UpdateConstructionItem();
                    frm.FormClosed += new FormClosedEventHandler(dongformItem);
                    frm.counstructionItemId = Convert.ToInt64(grdv_ConstructionItem.GetRowCellValue(indexConstructionItem, "construction_item_id").ToString());
                    frm.ShowDialog();
                }
                else
                {
                    messeage.error("Bạn Hãy Chọn Hạng Mục Để Chỉnh Sửa!");
                }
            }
            else
            {
                messeage.error("Không Có Gì Để Chỉnh Sửa!");
            }
        }
    }
}