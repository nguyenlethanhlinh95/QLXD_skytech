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
    public partial class frm_AccountingAccounts : DevExpress.XtraEditors.XtraForm
    {
        BUS.AccountingAccountGroupBus AAGBus = new BUS.AccountingAccountGroupBus();
        BUS.AcountingAcountBus AABus = new BUS.AcountingAcountBus();
        int indexAAGroup;
        int indexAcountintAccount;
        public frm_AccountingAccounts()
        {
            InitializeComponent();
        }
        private void loadAcountingAcountGroup()
        {
            grdc_AcountingAcountGroup.DataSource = AAGBus.getAllAccountingAcountGroup();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                //case (Keys.N | Keys.Control):
                //    btn_Add.PerformClick();
                //    break;
                //case (Keys.E | Keys.Control):
                //    btn_Edit.PerformClick();
                //    break;
                //case (Keys.Delete | Keys.Control):
                //    btn_Delete.PerformClick();
                //    break;
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
        private void frm_AccountingAccounts_Load(object sender, EventArgs e)
        {

            StyleDevxpressGridControl.styleGridControl(grdc_AcountingAccount, grdv_AcountingAccount);
            StyleDevxpressGridControl.styleGridControl(grdc_AcountingAcountGroup, grdv_AcountingAcountGroup);
            loadAcountingAcountGroup();
        }

        private void loadAllAcountingAcount()
        {
            grdc_AcountingAccount.DataSource = AABus.getAllAcountingAcount();
        }
        private void loadAcountingAcountWithGroup(Int64 AAGroupId)
        {
            grdc_AcountingAccount.DataSource = AABus.getAcountingAcountWithGroup(AAGroupId);
        }


        private void grdv_AcountingAcountGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            indexAAGroup = e.FocusedRowHandle;
            if (indexAAGroup >= 0)
            {
                Int64 AAGroupId = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());
                loadAcountingAcountWithGroup(AAGroupId);
            }
        }


        private void btn_DeleteAcountiongAcountGroup_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_AcountingAcountGroup.RowCount > 0)
            {
                Int64 AAGroupId = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());

                var AAGroupName = grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_name").ToString();
                if (AAGroupId != 1)
                {
                    bool boolCheckDelete = messeage.info("Bạn Có Muốn Xóa Nhóm Tài Khoản '", AAGroupName);

                    if (boolCheckDelete == true)
                    {
                        bool boolChangeIdGroup = AABus.changeIdParent(AAGroupId);
                        if (boolChangeIdGroup == true)
                        {
                            bool boolDeleteCustomer = AAGBus.deleteAAG(AAGroupId);
                            if (boolDeleteCustomer == true)
                            {
                                messeage.success("Xóa  Thành Công!");

                                loadAcountingAcountGroup();
                            }
                            else
                            {
                                messeage.error("Không Thể Xóa!");

                            }
                        }
                        else
                        {
                            messeage.error("Không Thể Xóa!");
                        }
                        

                    }

                }
                else
                {
                    messeage.error("Nhóm Này Không Thể Xóa Thể Xóa!");
                }

               
            }
            else
            {
                messeage.error("Không Có Gì Để Xóa");
            }
        }

        private void btn_AddAcountiongAcountGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewAccountingAccountsGroup frm = new frm_NewAccountingAccountsGroup();
            frm.FormClosed += new FormClosedEventHandler(dongform);
            frm.ShowDialog();
        }


        private void dongform(object sender, EventArgs e)
        {
            loadAcountingAcountGroup();

        }

        private void btn_EditAcountiongAcountGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_AcountingAcountGroup.RowCount > 0)
            {
                frm_UpdateAccountingAccountsGroup frm = new frm_UpdateAccountingAccountsGroup();
                frm.FormClosed += new FormClosedEventHandler(dongform);
                frm.AAGroupId = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());
                frm.ShowDialog();
            }
            else
            {
                messeage.error("Không Có Gì Để Chỉnh Sửa!");
            }
        }
        private void dongformAcountingAccount(object sender, EventArgs e)
        {
            Int64 AAGroupId = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());
            loadAcountingAcountWithGroup(AAGroupId);

        }
        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewAcountingAccount frm = new frm_NewAcountingAccount();
            frm.FormClosed += new FormClosedEventHandler(dongformAcountingAccount);
            frm.ShowDialog();
        }

        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadAllAcountingAcount();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_AcountingAccount.RowCount > 0)
            {
                Int64 idAcountingAccount = Convert.ToInt64(grdv_AcountingAccount.GetRowCellValue(indexAcountintAccount, "detail_income_and_expenditure_pattern_id").ToString());
                string AcountingAccountName = grdv_AcountingAccount.GetRowCellValue(indexAcountintAccount, "detail_income_and_expenditure_pattern_description").ToString(); 
                bool checkDelete = messeage.info("Bạn Có Muốn Xoa Tài Khoản ",AcountingAccountName);
                if(checkDelete == true)
                {
                    bool boolDeleteAcountingAccount = AABus.deleteAcountingAccount(idAcountingAccount);
                    if (boolDeleteAcountingAccount == true)
                    {
                        messeage.success("Xóa Thành Công!");
                        Int64 idGroup = Convert.ToInt64(grdv_AcountingAcountGroup.GetRowCellValue(indexAAGroup, "income_and_expenditure_pattern_id").ToString());
                        loadAcountingAcountWithGroup(idGroup);
                    }
                    else
                    {
                        messeage.error("Không Thể Xóa!");
                    }
                }
                
            }
            else
            {
                messeage.error("Không Có Gì Để Xóa!");
            }

        }

        private void grdv_AcountingAccount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            indexAcountintAccount = e.FocusedRowHandle;
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_AcountingAccount.RowCount > 0)
            {
                frm_UpdateAccountingAccounts frm = new frm_UpdateAccountingAccounts();
                frm.FormClosed += new FormClosedEventHandler(dongformAcountingAccount);
                frm.acountingAccountId = Convert.ToInt64(grdv_AcountingAccount.GetRowCellValue(indexAcountintAccount, "detail_income_and_expenditure_pattern_id").ToString());
                frm.ShowDialog();
            }
            else
            {
                messeage.error("Không Có Gì Để Chỉnh Sửa!");
            }
        }
    }
}