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
    public partial class frm_Supplies : DevExpress.XtraEditors.XtraForm
    {
        public frm_Supplies( )
        {
            InitializeComponent( );
        }

        public int index_group;
        public int index;

        group_suppliesBus _group = new group_suppliesBus();
        

        private void frm_Supplies_Load(object sender, EventArgs e)
        {
            LoadGroupSupplies( );

            LoadSupplies();
        }

        #region Load
        private void LoadGroupSupplies()
        {
            var datasource = _group.getAllGroup( );
            if ( datasource == null )
            {
                messeage.error("Không thể load dữ liệu");
            }
            else
            {
                grdc_group_supplies.DataSource = datasource;
            }
        }

        private void LoadSupplies()
        {
            var datasource = _group.getAllGroup( );
            if ( datasource == null )
            {
                messeage.error("Không thể load dữ liệu");
            }
            else
            {
                grdc_group_supplies.DataSource = datasource;
            }
        }
        #endregion Endload


        #region Event
        private void btn_AddGroup_supplies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddNewGroupSupplies f = new frm_AddNewGroupSupplies();
            f.FormClosed += new FormClosedEventHandler(dongformGroup);

            f.ShowDialog();
        }

        private void dongformGroup(object sender, EventArgs e)
        {
            LoadGroupSupplies();
        }


        #endregion EndEvent

        private void btn_DeleteGroup_supplies_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_EditGroup_supplies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( grdv_group_supplies.RowCount > 0 )
            {
                Int64 id = Convert.ToInt64(grdv_group_supplies.GetRowCellValue(index_group, "group_supplies_id").ToString( ));


                frm_UpdateGroupSupplies frm = new frm_UpdateGroupSupplies( );

                frm.id_group = id;
                frm.FormClosed += new FormClosedEventHandler(dongformGroup);

                //frm.id = id;
                frm.Show( );
            }
        }

        private void grdv_group_supplies_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index_group = e.FocusedRowHandle;
        }
        
    }
}