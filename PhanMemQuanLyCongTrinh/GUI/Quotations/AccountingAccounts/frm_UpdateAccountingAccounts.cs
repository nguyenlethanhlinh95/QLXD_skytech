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
    public partial class frm_UpdateAccountingAccounts : DevExpress.XtraEditors.XtraForm
    {
        BUS.AcountingAcountBus AcountingAccountBus = new BUS.AcountingAcountBus();
        BUS.AccountingAccountGroupBus AAGroupBus = new BUS.AccountingAccountGroupBus();

         public Int64 acountingAccountId { get; set; }
        public frm_UpdateAccountingAccounts()
        {
            InitializeComponent();
        }

        private void loadAcountiongAccount()
        {
            var acountingAccount= AcountingAccountBus.getAcountingAcount(acountingAccountId);
            txt_AAId.Text = acountingAccount.GetType().GetProperty("detail_income_and_expenditure_pattern_id_custom").GetValue(acountingAccount, null).ToString();
            txt_AAName.Text = acountingAccount.GetType().GetProperty("detail_income_and_expenditure_pattern_description").GetValue(acountingAccount, null).ToString();
            lke_AcountingAccount.EditValue = acountingAccount.GetType().GetProperty("income_and_expenditure_pattern_id").GetValue(acountingAccount, null).ToString();
        }

        private void frm_UpdateAccountingAccounts_Load(object sender, EventArgs e)
        {
           
            loadAcountiongAccount();
            loadAAGroup();
        }

        private void btn_AddAcountingAccount_Click(object sender, EventArgs e)
        {
            frm_NewAccountingAccountsGroup frm = new frm_NewAccountingAccountsGroup();
            frm.FormClosed += new FormClosedEventHandler(dongformAcountingAccount);
            frm.ShowDialog();
        }
        private void loadAAGroup()
        {
            lke_AcountingAccount.Properties.DisplayMember = "income_and_expenditure_pattern_name";
            lke_AcountingAccount.Properties.ValueMember = "income_and_expenditure_pattern_id";
            lke_AcountingAccount.Properties.DataSource = AAGroupBus.getAllAccountingAcountGroup();
        }
        private void dongformAcountingAccount(object sender, EventArgs e)
        {
            loadAAGroup();

        }



      

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string checkNull()
        {
            if (txt_AAName.Text == "")
            {
                txt_AAName.Focus();
                return "Vui Lòng Nhập Tên Tài Khoản Ngân Hàng";
            }
            else if (lke_AcountingAccount.Text == lke_AcountingAccount.Properties.NullText)
            {
                lke_AcountingAccount.Focus();
                return "Vui Lòng Nhập Nhóm Tài Khoản!";
            }
            else
            {
                return "true";
            }
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            string check = checkNull();

            if (check == "true")
            {
                Int32 idCustom = Convert.ToInt32(txt_AAId.Text);
               
                    DTO.ST_detail_income_and_expenditure_pattern acountingAccount = new DTO.ST_detail_income_and_expenditure_pattern();
                    acountingAccount.detail_income_and_expenditure_pattern_id = acountingAccountId;
                    acountingAccount.detail_income_and_expenditure_pattern_id_custom =Convert.ToInt32( txt_AAId.Text);
                    acountingAccount.detail_income_and_expenditure_pattern_description = txt_AAName.Text;
                    acountingAccount.income_and_expenditure_pattern_id = Convert.ToInt64(lke_AcountingAccount.EditValue);

                    if (AcountingAccountBus.updateAcountingAcount(acountingAccount) == true)
                    {
                        messeage.success("Cập Nhật Thành Công!");
                        this.Close();
                    }
                    else
                    {
                        messeage.error("Không Thể Cập Nhật!");
                    }
                
               

            }
            else
            {
                messeage.error(check);
            }
        }
    }
}