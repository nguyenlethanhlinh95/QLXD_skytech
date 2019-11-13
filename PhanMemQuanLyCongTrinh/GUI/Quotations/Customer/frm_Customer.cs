using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using PhanMemQuanLyCongTrinh.BUS;
using System.Data.Linq.Mapping;
namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Customer : DevExpress.XtraEditors.XtraForm
    {
        BUS.CustomerBus customerBus = new BUS.CustomerBus( );
        BUS.CustomerGroupBus customerGroupBus = new BUS.CustomerGroupBus( );

     
        public int index;
        public int indexCustomerGroup;

        public frm_Customer()
        {
            InitializeComponent();
           
        }
       
      
        public void loadCustomer()
        {
            grdc_Customer.DataSource = customerBus.getAllCustomer();
        }

        public void loadCustomerGroup()
        {
            grdc_CustomerGroup.DataSource = customerGroupBus.getAllCustomerGroup();
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
        private void frm_CustomerGroup_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_Customer, grdv_Customer);
            StyleDevxpressGridControl.styleGridControl(grdc_CustomerGroup, grdv_CustomerGroup);
            loadCustomerGroup();
        }

        

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewCustomer frm = new frm_NewCustomer();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.ShowDialog();
           
        }
        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_Customer.RowCount > 0)
            {
                if (index >= 0)
                {
                    Int64 customerId = Convert.ToInt64(grdv_Customer.GetRowCellValue(index, "customer_id").ToString());
                    frm_UpdateCustomer frm = new frm_UpdateCustomer();
                    frm.FormClosed += new FormClosedEventHandler(dongform);
                    frm.customerId = customerId;
                    frm.ShowDialog();
                }
            }
            else
            {
                messeage.error("Không Có Khách Hàng Để Sửa");
            }
        }
        private void btn_AddCustomerGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewCustomerGroup frm = new frm_NewCustomerGroup();
            frm.FormClosed += new FormClosedEventHandler(dongformGroup);
          
            frm.ShowDialog();
        }

        private void btn_EditCustomerGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_CustomerGroup.RowCount > 0)
            {
                if (indexCustomerGroup >= 0)
                {
                    Int64 customerGroupId = Convert.ToInt64(grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_id").ToString());
                    frm_UpdateCustomerGroup frm = new frm_UpdateCustomerGroup();
                    frm.FormClosed += new FormClosedEventHandler(dongformGroup);
                    frm.customerGroupId = customerGroupId;
                    frm.ShowDialog();
                }
            }
            else
            {
                messeage.error("không có Nhóm Khách Hàng Để Sửa!!!");
                
            }
        }

        private void grdv_Customer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
         
        }
        private void dongformGroup(object sender, EventArgs e)
        {
            loadCustomerGroup();
        }
        private void dongform(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             if (grdv_Customer.RowCount > 0)
            {

                if (index >= 0)
                {
                    Int64 customerId = Convert.ToInt64(grdv_Customer.GetRowCellValue(index, "customer_id").ToString());
                    var CustomerName = grdv_Customer.GetRowCellValue(index, "customer_name").ToString();

                    bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Khách Hàng '", CustomerName);

                    if (boolCheckDelete == true)
                    {
                        bool boolDeleteCustomer = customerBus.deleteCustomer(customerId);
                        if (boolDeleteCustomer == true)
                        {
                            messeage.success("Xóa Khách hàng Thành Công!");
                            customerId = 0;
                            loadCustomer();
                        }
                        else
                        {
                            messeage.error("Xóa Khách hàng Không Thành Công!");

                        }
                    }
                }
                
            }
             else
             {
                 messeage.error("Không có  Khách Hàng Để Xóa!!!");
                
             }
            
        }
        public void loadCustomerWithGroup(Int64 customerGroupId)
        {
            grdc_Customer.DataSource = customerBus.getCustomerWithGroup(customerGroupId);
        }
        
        private void grdv_CustomerGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            indexCustomerGroup = e.FocusedRowHandle;
            if (indexCustomerGroup >= 0)
            {
                Int64 customerGroupId = Convert.ToInt64(grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_id").ToString());
                loadCustomerWithGroup(customerGroupId);
            }
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdv_Customer.ClearColumnsFilter();
            loadCustomer();
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_DeleteCustomerGroup_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_CustomerGroup.RowCount > 0)
            {
                if (indexCustomerGroup >= 0)
                {
                    Int64 customerGroupId = Convert.ToInt64(grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_id").ToString());


                    var customerGroupName = grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_name").ToString();
                    if (customerGroupId != 1)
                    {
                        bool boolCheckDeleteGroup = messeage.info("Bạn Có Muốn Xóa Nhóm Khách Hàng '", customerGroupName);

                        if (boolCheckDeleteGroup == true)
                        {

                            bool changeGroupId = customerBus.changeIdParent(customerGroupId);
                            if (changeGroupId == true)
                            {
                                bool boolDeleteCustomerGroup = customerGroupBus.deleteCustomerGroup(customerGroupId);
                                if (boolDeleteCustomerGroup == true)
                                {

                                    messeage.success("Xóa Nhóm Khách hàng Thành Công!");
                                    loadCustomerGroup();

                                }
                                else
                                {
                                    messeage.error("Xóa Nhóm Khách hàng Không Thành Công!");

                                }
                            }
                            else
                            {
                                messeage.error("Xóa Nhóm Khách hàng Không Thành Công!");

                            }

                        }


                    }
                    else
                    {
                        messeage.error("Nhóm Khách Hàng Này Không Thể Xóa");
                    }
                }
            }
            else
            {
                    messeage.error("Không có Nhóm  Khách Hàng Để Xóa!!!");

            }         
        }
   
    }
}