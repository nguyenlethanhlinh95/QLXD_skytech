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
    public partial class frm_UpdateCustomerGroup : DevExpress.XtraEditors.XtraForm
    {
        public Int64 customerGroupId { set; get; }
        BUS.CustomerGroupBus customerGroupBus = new BUS.CustomerGroupBus( );
        public frm_UpdateCustomerGroup()
        {
            InitializeComponent();
        }

        private void frm_UpdateCustomerGroup_Load(object sender, EventArgs e)
        {
            
            loadCustomerGroup();
            this.AcceptButton = but_Update;
        }
        public void loadCustomerGroup()
        {
            var dt = customerGroupBus.getCustomerGroup(customerGroupId);
            txt_CustomerGroupId.Text = dt.GetType().GetProperty("customer_group_id_custom").GetValue(dt, null).ToString();
            txt_CustomerGroupName.Text = dt.GetType().GetProperty("customer_group_name").GetValue(dt, null).ToString();
        }
        private bool updateCustomerGroup()
        {
            DTO.ST_customer_group customerGroup = new DTO.ST_customer_group();
            customerGroup.customer_group_id = customerGroupId;
            customerGroup.customer_group_name = txt_CustomerGroupName.Text;
            bool boolUpdateCustomerGroup = customerGroupBus.updateCustomerGroup(customerGroup);
            if (boolUpdateCustomerGroup == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            if (txt_CustomerGroupName.Text == "")
            {
                txt_CustomerGroupName.Focus();
                messeage.error("Vui Lòng Nhập Tên Nhóm Khách Hàng!");
            }
            else
            {
                if (updateCustomerGroup() == true)
                {
                    messeage.success("Chỉnh Sửa Thành Công!");
                }
                else
                {
                    messeage.error("Không Thể Chỉnh Sửa!");
                }
            }
                
            
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}