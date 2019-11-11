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
    public partial class frm_OutCouponToConstructions : DevExpress.XtraEditors.XtraForm
    {

        BUS.OutCouponSuppliesToConstructionBus outCoupon = new BUS.OutCouponSuppliesToConstructionBus();
        public frm_OutCouponToConstructions()
        {
            InitializeComponent();
        }
        public void loadAllOutCoupon()
        {
            grdc_OutCoupon.DataSource = outCoupon.getAllOutCouponToConstruction();
        }

        private void frm_OutCouponToConstructions_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(grdc_OutCoupon, grdv_OutCoupon);
            loadAllOutCoupon();
        }

        private void date_Start_EditValueChanged(object sender, EventArgs e)
        {

            if (date_Start.Text != "")
            {
                if (date_End.Text == "")
                {
                    DateTime date = Convert.ToDateTime(date_Start.Text);
                    grdc_OutCoupon.DataSource = outCoupon.getOutCouponToConstructionWithDayStar(date);
                }
                else
                {
                    DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                    DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                    grdc_OutCoupon.DataSource = outCoupon.getOutCouponToConstructionWithDayStarDayEnd(dateStart, dateEnd);
                }
            }
        }

        private void date_End_EditValueChanged(object sender, EventArgs e)
        {
            if (date_Start.Text != "" && date_End.Text != "")
            {
                DateTime dateStart = Convert.ToDateTime(date_Start.Text);
                DateTime dateEnd = Convert.ToDateTime(date_End.Text);
                grdc_OutCoupon.DataSource = outCoupon.getOutCouponToConstructionWithDayStarDayEnd(dateStart, dateEnd);
            }
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            date_End.Text = "";
            date_Start.Text = "";
            loadAllOutCoupon();
        
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NewOutCouponToConstructions frm = new frm_NewOutCouponToConstructions();
            frm.FormClosed += new FormClosedEventHandler(dongform);

            frm.ShowDialog();
        }

        private void dongform(object sender, EventArgs e)
        {
            loadAllOutCoupon();

        }
    }
}