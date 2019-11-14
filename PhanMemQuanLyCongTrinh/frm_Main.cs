using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils.Taskbar.Core;
using PhanMemQuanLyCongTrinh.BUS;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string Vitual_Username;
        public static Int64 Vitual_id = 0;
        public static string Vitual_Chinhanh;
        public static Int64 Vitual_Quyen;
        private Form kiemtraform(Type ftype)
        {
            foreach ( Form f in this.MdiChildren )
            {
                if ( f.GetType( ) == ftype )
                {
                    return f;
                }
            }
            return null;
        }
        public frm_Main()
        {
            InitializeComponent();

            // The following line provides localization for the application's user interface.  
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("vi");

            // The following line provides localization for data formats.  
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo("vi-VN");  
        }

        private void btnUserInformation_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_UserInfo));
            if ( frm == null )
            {
                frm_UserInfo forms = new frm_UserInfo( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnRegistered_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_RegisterUser));
            if ( frm == null )
            {
                frm_RegisterUser forms = new frm_RegisterUser( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(skinRibbonGalleryBarItem2, true);

            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Bezier, SkinSvgPalette.Bezier.OfficeColorful);

            taskbarAssistant1.ProgressMode = TaskbarButtonProgressMode.Indeterminate;
            taskbarAssistant1.ProgressCurrentValue = 100;


            load_login( );

        }

        private void load_login( )
        {
            btnUserInformation.Visibility = BarItemVisibility.Never;
            btnPermission.Visibility = BarItemVisibility.Never;
            btnRegistered.Visibility = BarItemVisibility.Never;
            ribbonPageGroup11.Visible = false;

            ribbonPage1.Visible = false;
            ribbonPage9.Visible = false;
            ribbonPage2.Visible = false;
            ribbonPage3.Visible = false;
            ribbonPage5.Visible = false;
            ribbonPage6.Visible = false;
            ribbonPage7.Visible = false;
            ribbonPage8.Visible = false;
            LoginEvent( );
        }

        private void LoginEvent( )
        {
            foreach ( Form childForm in MdiChildren )
            {
                childForm.Close( );
            }
            frm_DangNhap log = new frm_DangNhap( );
            if ( log.ShowDialog( ) == DialogResult.OK )
            {
                try
                {
                    //xử lí sự kiện đăng nhập thành công
                    // quyen 1 admin
                    if ( Vitual_Quyen == 1 )
                    {
                        barButtonItem_login.Visibility = BarItemVisibility.Never;
                        Menu_adminstrator_true();
                        //Menu_adminstrator_true( );
                    }
                    else
                    {
                        //if (Vitual_Quyen == "Quản lý chi nhánh")
                        //{
                        //    Menu_quanly_true();
                        //}
                        //else
                        //{
                        //Menu_NHANVIEN_true( );
                        //}

                    }
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thao tác với CSDL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void Menu_adminstrator_true( )
        {
            btnUserInformation.Visibility = BarItemVisibility.Always;
            btnPermission.Visibility = BarItemVisibility.Always;
            btnRegistered.Visibility = BarItemVisibility.Always;
            ribbonPageGroup11.Visible = true;

            barButtonItem1_DangXuat.Visibility = BarItemVisibility.Always;

            ribbonPage1.Visible = true;
            ribbonPage9.Visible = true;
            ribbonPage2.Visible = true;
            ribbonPage3.Visible = true;
            ribbonPage5.Visible = true;
            ribbonPage6.Visible = true;
            ribbonPage7.Visible = true;
            ribbonPage8.Visible = true;

        }

        private void btnCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Customer));
            if ( frm == null )
            {
                frm_Customer forms = new frm_Customer( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnCustomerGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Form frm = kiemtraform(typeof(frm_NewCustomerGroup));
            //if ( frm == null )
            //{
            //    frm_NewCustomerGroup forms = new frm_NewCustomerGroup( );
            //    forms.MdiParent = this;
            //    forms.Show( );
            //}
            //else
            //{
            //    frm.Activate( );
            //}
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_RePassword));
            if ( frm == null )
            {
                frm_RePassword forms = new frm_RePassword( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Employees));
            if ( frm == null )
            {
                frm_Employees forms = new frm_Employees( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Units));
            if ( frm == null )
            {
                frm_Units forms = new frm_Units( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnConstructors_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_BuildingContractor));
            if ( frm == null )
            {
                frm_BuildingContractor forms = new frm_BuildingContractor( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnVendor_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Vendor));
            if ( frm == null )
            {
                frm_Vendor forms = new frm_Vendor( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Supplies));
            if ( frm == null )
            {
                frm_Supplies forms = new frm_Supplies( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnStorehouses_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Storehouse));
            if ( frm == null )
            {
                frm_Storehouse forms = new frm_Storehouse( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnRevenueAndExpenditure_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_AccountingAccounts));
            if ( frm == null )
            {
                frm_AccountingAccounts forms = new frm_AccountingAccounts( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnEnterCouponSupplies_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_AddNewEnterCouponSupplies));
            if ( frm == null )
            {
                frm_AddNewEnterCouponSupplies forms = new frm_AddNewEnterCouponSupplies( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnListEnterCouponSupplies_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_EnterCoupon));
            if ( frm == null )
            {
                frm_EnterCoupon forms = new frm_EnterCoupon( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnConstructions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Constructions));
            if ( frm == null )
            {
                frm_Constructions forms = new frm_Constructions( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnSuppliesInWearHouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_StorehouseDetail));
            if ( frm == null )
            {
                frm_StorehouseDetail forms = new frm_StorehouseDetail( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnEmployeeConstructions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_Employees_Contruct));
            if ( frm == null )
            {
                frm_Employees_Contruct forms = new frm_Employees_Contruct( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnConstructionItems_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnProgressConstructionItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frm_progress));
            if ( frm == null )
            {
                frm_progress forms = new frm_progress( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        private void btnPlanConstructions_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_DangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (messeage.info("Bạn có muốn thoát?", "Thông báo"))
            {
                this.Close( );
            }
            
        }

        private void barButtonItem_login_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_DangNhap frm = new frm_DangNhap();
            frm.ShowDialog();
        }

        private void btnProgress_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = kiemtraform(typeof(frm_TienDoCongTrinh));
            if ( frm == null )
            {
                frm_TienDoCongTrinh forms = new frm_TienDoCongTrinh( );
                forms.MdiParent = this;
                forms.Show( );
            }
            else
            {
                frm.Activate( );
            }
        }

        
        
    }
}