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

        
    }
}