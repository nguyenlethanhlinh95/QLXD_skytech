﻿using System;
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
    public partial class frm_NewAccountingAccountsGroup : DevExpress.XtraEditors.XtraForm
    {
        BUS.AccountingAccountGroupBus AAGroupBus = new BUS.AccountingAccountGroupBus();
        public frm_NewAccountingAccountsGroup()
        {
            InitializeComponent();
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string checkNull()
        {
            if (txt_AAGroupId.Text == "")
            {
                txt_AAGroupId.Focus();
                return "Vui Lòng Nhập Mã Nhóm Tài Khoản Ngân Hàng";
            }
            else if (txt_AAGroupName.Text == "")
            {
                txt_AAGroupName.Focus();
                return "Vui Lòng Nhập Tên Nhóm Tài Khoản Ngân Hàng";
            }
            else
            {
                return "true";
            }
        }

        #region insert Acounting acount group

        
        

        private void but_Add_Click(object sender, EventArgs e)
        {
            string check = checkNull();


            if (check == "true")
            {
                bool boolIsAAGroup = AAGroupBus.IsAAGroupIdCustom(Convert.ToInt32(txt_AAGroupId.Text));
                if (boolIsAAGroup != true)
                {
                    DTO.ST_income_and_expenditure_pattern newAAGroup = new DTO.ST_income_and_expenditure_pattern();
                    newAAGroup.income_and_expenditure_pattern_id_custom = Convert.ToInt32(txt_AAGroupId.Text);
                    newAAGroup.income_and_expenditure_pattern_name = txt_AAGroupName.Text;

                    bool boolInsertAAGroup = AAGroupBus.insertAAGroup(newAAGroup);
                    if (boolInsertAAGroup == true)
                    {
                        messeage.success("Thêm Mới Thành Công!");
                        this.Close();
                    }
                    else
                    {
                        messeage.error("Không Thể Thêm Mới!");
                    }
                }
                else
                {
                    messeage.error("Mã Nhóm Tài Khoản Đã Tồn Tại!");
                }
            }
            else
            {
                messeage.error(check);
            }
        }

        private void frm_NewAccountingAccountsGroup_Load(object sender, EventArgs e)
        {

        }
    }
        #endregion
}