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
    public partial class frm_NewAcountingAccount : DevExpress.XtraEditors.XtraForm
    {
        BUS.AcountingAcountBus AcountingAccountBus = new BUS.AcountingAcountBus();
        BUS.AccountingAccountGroupBus AAGroupBus = new BUS.AccountingAccountGroupBus();
        public frm_NewAcountingAccount()
        {
            InitializeComponent();
        }



        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string checkNull()
        {
            if (txt_AAId.Text == "")
            {
                txt_AAId.Focus();
                return "Vui Lòng Nhập Mã Tài Khoản Ngân Hàng";
            }
            else if (txt_AAName.Text == "")
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

        
        private void but_Add_Click(object sender, EventArgs e)
        {
            string check = checkNull();

            if (check == "true")
            {
                Int32 idCustom = Convert.ToInt32(txt_AAId.Text);
                if (AcountingAccountBus.IsAAIdCustom(idCustom) == false)
                {
                    DTO.ST_detail_income_and_expenditure_pattern acountingAccount = new DTO.ST_detail_income_and_expenditure_pattern();
                    acountingAccount.detail_income_and_expenditure_pattern_id_custom = idCustom;
                    acountingAccount.detail_income_and_expenditure_pattern_description = txt_AAName.Text;
                    acountingAccount.income_and_expenditure_pattern_id = Convert.ToInt64(lke_AcountingAccount.EditValue);

                    if (AcountingAccountBus.insertAcountingAcount(acountingAccount) == true)
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
                    messeage.error("Tài Khoản Kế Toán Đã Tồn Tại!");
                }
               
            }
            else
            {
                messeage.error(check);
            }
        }

        private void loadAAGroup()
        {
            lke_AcountingAccount.Properties.DisplayMember = "income_and_expenditure_pattern_name";
            lke_AcountingAccount.Properties.ValueMember = "income_and_expenditure_pattern_id";
            lke_AcountingAccount.Properties.DataSource = AAGroupBus.getAllAccountingAcountGroup();
        }

        private void frm_NewAcountingAccount_Load(object sender, EventArgs e)
        {
            loadAAGroup();
        }

        private void btn_AddAcountingAccount_Click(object sender, EventArgs e)
        {
            frm_NewAccountingAccountsGroup frm = new frm_NewAccountingAccountsGroup();
            frm.FormClosed += new FormClosedEventHandler(dongformAcountingAccount);
            frm.ShowDialog();
        }
        private void dongformAcountingAccount(object sender, EventArgs e)
        {
            loadAAGroup();

        }
    }
}