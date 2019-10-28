using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_RegisterUser : DevExpress.XtraEditors.XtraForm
    {
        public frm_RegisterUser( )
        {
            InitializeComponent( );
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

        #region Load
        private void frm_RegisterUser_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Event
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            var username = txt_UserName.Text;
            var password = txt_Pass.Text;

        }
        #endregion End Event

        private void btn_AddNewDerpament_Click(object sender, EventArgs e)
        {
            //frm f = new frm_TableManager( );
            //// an form hien tai
            //this.Hide( );
            //// show form
            //f.ShowDialog( );

        }


  
        
        // su ly dang ky tai khoan
    


    }
}