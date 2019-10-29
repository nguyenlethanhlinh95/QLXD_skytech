using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public static class messeage
    {
        public static void success(string mess)
        {
            MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void error(string mess)
        {
            MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
