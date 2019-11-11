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
    public partial class frm_StorehouseDetail : DevExpress.XtraEditors.XtraForm
    {
        BUS.StorehouseBus storehouseBus = new BUS.StorehouseBus();
        BUS.StorehouseDetailBus storehouseDetailBus = new BUS.StorehouseDetailBus();

        int index;
        public frm_StorehouseDetail()
        {
            InitializeComponent();
        }

        private void loadStorehouse()
        {
            grdc_Storehouse.DataSource = storehouseBus.getAllStorehouse();
        }

        private void frm_StorehouseDetail_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_Storehouse, grdv_Storehouse);
            StyleDevxpressGridControl.styleGridControl(grdc_StorehouseDetail, grdv_StorehouseDetail);
            loadStorehouse();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void loadStorehouseDetail(Int64 StorehouseId)
        {
            grdc_StorehouseDetail.DataSource = storehouseDetailBus.getSuppliesAndQuantityWithStoreHouse(StorehouseId);
        }

        private void grdv_Storehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;

            if (index >= 0)
            {
                Int64 StorehouseId =Convert.ToInt64(grdv_Storehouse.GetRowCellValue(index, "storehouse_id").ToString());
                loadStorehouseDetail(StorehouseId);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdc_StorehouseDetail.DataSource = storehouseDetailBus.getAllStorehouseDetail();
        }
    }
}