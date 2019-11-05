using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class detailPulicDebtDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public IEnumerable<object> getAllDetailPulicDebts( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from t1 in db.ST_detail_pulic_debts
                                 select t1;
                return datasource;
            }
            catch ( Exception )
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
        }

        public object getDetailPulicDebts(Int64 id)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_detail_pulic_debts
                            where t1.detail_pulic_debt_id == id
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public bool deleteDetailPulicDebts(Int64 id)
        {
            try
            {
                var delete = db.ST_detail_pulic_debts.Where(p => p.detail_pulic_debt_id.Equals(id)).SingleOrDefault( );

                db.ST_detail_pulic_debts.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertDetailPulicDebts(DTO.ST_detail_pulic_debt de)
        {
            try
            {
                db.ST_detail_pulic_debts.InsertOnSubmit(de);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool updateDetailPulicDebts(DTO.ST_detail_pulic_debt de)
        {
            try
            {
                var update = db.ST_detail_pulic_debts.Where(p => p.detail_pulic_debt_id.Equals(de.detail_pulic_debt_id)).SingleOrDefault( );

                update.pulic_debt_id = de.pulic_debt_id;
                update.payment_slip_id = de.payment_slip_id;
                update.income_coupon_id = de.income_coupon_id;
                update.detail_pulic_debt_total = de.detail_pulic_debt_total;

                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}
