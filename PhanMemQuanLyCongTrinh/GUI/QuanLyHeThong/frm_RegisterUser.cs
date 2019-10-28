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
    public partial class frm_RegisterUser : DevExpress.XtraEditors.XtraForm
    {
        deparmentBus deparmentBus = new deparmentBus();

        public frm_RegisterUser( )
        {
            InitializeComponent( );
        }

        #region Load
        private void frm_RegisterUser_Load(object sender, EventArgs e)
        {
            loadDeparment();
        }

        private void loadDeparment()
        {
            var data = deparmentBus.listAll();

            lue_deparment.Properties.DataSource = data;
            lue_deparment.Properties.ValueMember = "department_id";
            lue_deparment.Properties.DisplayMember = "department_name";
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
        private void btn_AddNewDerpament_Click(object sender, EventArgs e)
        {
            frm_department f = new frm_department( );
            f.ShowDialog( );

        }
        #endregion End Event

        


  
        
        // su ly dang ky tai khoan
    


    }
}