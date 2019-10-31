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
    public partial class frm_AddNewEnterCouponSupplies : DevExpress.XtraEditors.XtraForm
    {
        
        public frm_AddNewEnterCouponSupplies( )
        {
            InitializeComponent( );
        }

        supliesBus _sup = new supliesBus();
        private Int64 idSupplies = 0;

 
        private void frm_AddNewEnterCouponSupplies_Load(object sender, EventArgs e)
        {
            LoadSearchLookUp();
        }

        #region Load

        private void LoadSearchLookUp( )
        {
            slue_Supplies.Properties.DataSource = _sup.getAllSuplies_LoadSerach( );
            slue_Supplies.Properties.ValueMember = "supplies_id";
            slue_Supplies.Properties.DisplayMember = "supplies_name";
            slue_Supplies.Properties.ShowClearButton = false;
        }

        #endregion End Load

        #region Event
        private void slue_Supplies_EditValueChanged(object sender, EventArgs e)
        {
            idSupplies = Int64.Parse(slue_Supplies.EditValue.ToString( ));

            Int64[] idList;


            //if ( idList )
            
            //for ( int runs = 0; runs < 400; runs++ )
            //{
            //    termsList.Add(value);
            //}


        }
        #endregion End Event



    }
}