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
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {
        public frm_Login( )
        {
            InitializeComponent( );
        }

        DataClasses1DataContext db = new DataClasses1DataContext();


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if ( txt_UserName.Text == "" || txt_PassWord.Text == "" )
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var user = from p in db.ST_employees
                        where p.employee_username == txt_UserName.Text
                        && p.employee_password == txt_PassWord.Text
                        select p;

                if ( user.Any())
                {
                    // tao form moi
                    frm_Main f = new frm_Main( );
                    // an form hien tai
                    this.Hide( );
                    // show form
                    f.ShowDialog( );
                    this.Show( );


                    frm_Main.Vitual_Username = user.Single( ).employee_username;
                    frm_Main.Vitual_Quyen = Int64.Parse(user.Single( ).permission_id.ToString());

                    this.DialogResult = DialogResult.OK;
                    this.Close( );
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }

            }
        }


  
       
    }
}