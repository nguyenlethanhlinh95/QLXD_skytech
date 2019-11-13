using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace PhanMemQuanLyCongTrinh.BUS
{
    public static class StyleDevxpressGridControl
    {
        // Design by Linh Nguyen
        public static void styleGridControl(DevExpress.XtraGrid.GridControl gc, DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            //gc.LookAndFeel.UseDefaultLookAndFeel = true;
            //gc.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            //gv.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;

            //gv.Appearance.HeaderPanel.BackColor = Color.FromArgb(41, 112, 195);
            gv.ColumnPanelRowHeight = 21;
            
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gv.Appearance.HeaderPanel.Options.UseBackColor = true;
            gc.UseEmbeddedNavigator = true;
            gv.OptionsView.ShowIndicator = true;
            foreach (GridColumn item in gv.Columns)  
            {  
                item.AppearanceHeader.Options.UseFont = false;
            }
            gv.Appearance.HeaderPanel.Font = new Font("Tahoma", 11, FontStyle.Bold);
            ////gv.RowSeparatorHeight = 1;
            ////gv.OptionsView.EnableAppearanceEvenRow = true;
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            gv.Appearance.FocusedCell.BackColor = Color.FromArgb(30, 160, 86);
            gv.Appearance.FocusedCell.ForeColor = Color.White;
            gv.Appearance.Row.Font = new Font("Tahoma", 10, FontStyle.Regular);
            //gc.
            //gv.Appearance.HeaderPanel.
            gv.OptionsView.ShowAutoFilterRow = true;
            gv.IndicatorWidth = 20;
            gv.OptionsView.ShowFooter = true;
            gv.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            
        }



        public static void styleTextBoxVND(DevExpress.XtraEditors.TextEdit text)
        {
            text.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            text.Properties.DisplayFormat.FormatString = "{0:n0}";
            text.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            text.Properties.Mask.EditMask = "n0";
            text.RightToLeft = RightToLeft.Yes;
            text.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        }


        public static void autoLookUpEdit(DevExpress.XtraEditors.LookUpEdit lue)
        {
            lue.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            lue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }

        public static string convertDecimaToNumberic(Decimal value)
        {
            return string.Format("{0:0,0}", value);
        }

        
    }
}
