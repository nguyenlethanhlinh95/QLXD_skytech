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

        private void btnConstructors_ItemClick(object sender, ItemClickEventArgs e)
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

        
    }
}