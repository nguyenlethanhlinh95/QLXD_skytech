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

using System.Data.Linq.Mapping;
namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Customer : DevExpress.XtraEditors.XtraForm
    {
        BUS.customerBus customerBus;
        BUS.customerGroupBus customerGroupBus;
        public int index;
        public int indexCustomerGroup;
        public frm_Customer()
        {
            InitializeComponent();
            customerBus = new BUS.customerBus();
            customerGroupBus = new BUS.customerGroupBus();
        }
       
      
        public void loadCustomer()
        {
            grdc_Customer.DataSource = customerBus.getAllCustomer();
        }

        public void loadCustomerGroup()
        {
            grdc_CustomerGroup.DataSource = customerGroupBus.getAllCustomerGroup();
        }

        
        private void frm_CustomerGroup_Load(object sender, EventArgs e)
        {
          
            loadCustomerGroup();
        }

        

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewCustomer frm = new frm_NewCustomer();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.Show();
           
        }
        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewCustomer frm = new frm_NewCustomer();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            Int64 id = Convert.ToInt64(grdv_Customer.GetRowCellValue(index, "customer_id").ToString());
            frm.customerId = id;
            frm.Show();
        }
        private void btn_AddCustomerGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewCustomerGroup frm = new frm_NewCustomerGroup();
            frm.FormClosed += new FormClosedEventHandler(dongformGroup);
            frm.customerGroupId = 0;
            frm.Show();
        }

        private void btn_EditCustomerGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewCustomerGroup frm = new frm_NewCustomerGroup();
            frm.FormClosed += new FormClosedEventHandler(dongformGroup);
            frm.customerGroupId = Convert.ToInt64(grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_id").ToString());
            frm.Show();
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
            Int64 id = Convert.ToInt64(grdv_Customer.GetRowCellValue(index, "customer_id").ToString());
            var idCustomer =grdv_Customer.GetRowCellValue(index, "customer_name").ToString();
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xóa Khách Hàng " + customer_name + " Không!", "Thông Báo!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool boolDeleteCustomer =customerBus.deleteCustomer(id);
                if (boolDeleteCustomer == true)
                {
                    MessageBox.Show("Xóa Khách hàng Thành Công!");
                    loadCustomer();
                }
                else
                {
                    MessageBox.Show("Xóa Khách hàng Không Thành Công!");
                }
            }
            
        }
        public void loadCustomerWithGroup(Int64 customerGroupId)
        {
            grdc_Customer.DataSource = customerBus.getCustomerWithGroup(customerGroupId);
        }
        
        private void grdv_CustomerGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            indexCustomerGroup = e.FocusedRowHandle;
            Int64 customerGroupId = Convert.ToInt64(grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_id").ToString());
            loadCustomerWithGroup(customerGroupId);
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadCustomer();
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_DeleteCustomerGroup_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int64 customerGroupId = Convert.ToInt64(grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_id").ToString());
            var customerGroupName = Convert.ToInt64(grdv_CustomerGroup.GetRowCellValue(indexCustomerGroup, "customer_group_name").ToString());
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xóa Nhóm Khách Hàng " + customerGroupName + " Không!", "Thông Báo!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool boolDeleteCustomer = customerGroupBus.deleteCustomerGroup(customerGroupId);
                if (boolDeleteCustomer == true)
                {
                    MessageBox.Show("Xóa Nhóm Khách hàng Thành Công!");
                    loadCustomer();
                }
                else
                {
                    MessageBox.Show("Xóa Nhóm Khách hàng Không Thành Công!");
                }
            }
        }
   
    }
}