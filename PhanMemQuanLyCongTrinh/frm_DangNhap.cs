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
    public partial class frm_DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frm_DangNhap( )
        {
            InitializeComponent( );
        }
        private UserBus userBus = new UserBus( );

        private void btn_login_Click(object sender, EventArgs e)
        {
            if ( txt_UserName.Text == "" || txt_PassWord.Text == "" )
            {
                messeage.warnning("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!");
            }
            else
            {
                Int64 IntCheckLogin = userBus.checkLogin(txt_UserName.Text, txt_PassWord.Text);

                if ( IntCheckLogin > 0 )
                {
                    var user = userBus.getUserByID(IntCheckLogin);

                    // check quyen
                    var Quyen = user.GetType( ).GetProperty("permission_id").GetValue(user, null);
                    var Vitual_Quyen = (Quyen == null) ? 0 : Int64.Parse(Quyen.ToString( ));

                    frm_Main.Vitual_Username = txt_UserName.Text;
                    frm_Main.Vitual_Quyen = Vitual_Quyen;
                    frm_Main.Vitual_id = IntCheckLogin;

                    // tao form moi
                    frm_Main f = new frm_Main( );

                    messeage.success("Đăng nhập thành công!");

                    this.DialogResult = DialogResult.OK;
                    this.Close( );
                
                }
                else
                {
                    messeage.error("Tên đăng nhập hoặc mật khẩu không đúng!");
                }

            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_login;
        }

    }
}