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
    public partial class frm_NewCustomerGroup : DevExpress.XtraEditors.XtraForm
    {

        BUS.CustomerGroupBus customerGroupBus = new BUS.CustomerGroupBus( );
        public frm_NewCustomerGroup()
        {
            InitializeComponent();
            
        }
       

        private void frm_NewCustomerGroup_Load(object sender, EventArgs e)
        {
           
            
            this.AcceptButton = but_Update;
        }

       
        private bool insertCustomerGroup()
        {
            DTO.ST_customer_group customerGroup = new DTO.ST_customer_group();
            
            customerGroup.customer_group_name = txt_CustomerGroupName.Text;
            bool boolInsertCustomerGroup = customerGroupBus.insertCustomerGroup(customerGroup);
            if (boolInsertCustomerGroup == true)
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
                    if (insertCustomerGroup() == true)
                    {
                        messeage.success("Thêm Mới Thành Công!");
                        this.Close();
                    }
                    else
                    {
                        messeage.error("Không Thể Thêm Mới!");
                    }
                }
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_CustomerGroupName_Click(object sender, EventArgs e)
        {
           
        }

        private void lbl_CustomerGroupId_Click(object sender, EventArgs e)
        {

        }

       
    }
}