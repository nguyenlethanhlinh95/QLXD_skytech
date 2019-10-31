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
        BUS.constructionBus constructionBus = new BUS.constructionBus();
        BUS.constructionItemBus constructionItemBus = new BUS.constructionItemBus();
        int indexConstruction;


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
            loadContruction();
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
                Int64 constructionId = Convert.ToInt64(grdv_Construction.GetRowCellValue(indexConstruction, "construction_id").ToString());
                

                var constructionName = grdv_Construction.GetRowCellValue(indexConstruction, "construction_name").ToString();

                if (constructionItemBus.isContructionIdtemGroup(constructionId) == false)
                {

                    bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Khách Hàng '", constructionName);

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
                messeage.error("Không có  Khách Hàng Để Xóa!!!");

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
    }
}