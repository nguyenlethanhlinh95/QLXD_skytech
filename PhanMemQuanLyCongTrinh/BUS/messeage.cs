using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public static class messeage
    {
        public static void success(string mess)
        {
            XtraMessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void error(string mess)
        {
            XtraMessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void warnning(string mess)
        {
            XtraMessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool info(string mess, string name)
        {
            
            DialogResult dialogResult = XtraMessageBox.Show(mess + name, "Thông Báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
