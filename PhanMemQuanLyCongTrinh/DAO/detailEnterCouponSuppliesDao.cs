using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class DetailEnterCouponSuppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public IEnumerable<object> getAll( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from t1 in db.ST_detail_enter_coupon_supplies
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

        public IEnumerable<Object> getAllSupplies(Int64 idEnter)
        {
            try{
                var data = from b in db.ST_detail_enter_coupon_supplies
                            where b.enter_coupon_supplies_id == idEnter
                            select b;
                return data;
            }
            catch(Exception )
            {
                return null;
            }
        }

        

        public object getDetail(Int64 id)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_detail_enter_coupon_supplies
                            where t1.detail_enter_coupon_supplies_id == id
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public bool delete(Int64 id)
        {
            try
            {
                var delete = db.ST_detail_enter_coupon_supplies.Where(p => p.detail_enter_coupon_supplies_id.Equals(id)).SingleOrDefault( );

                db.ST_detail_enter_coupon_supplies.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insert(DTO.ST_detail_enter_coupon_supply de)
        {
            try
            {
                db.ST_detail_enter_coupon_supplies.InsertOnSubmit(de);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool updatet(DTO.ST_detail_enter_coupon_supply de)
        {
            try
            {
                var update = db.ST_detail_enter_coupon_supplies.Where(p => p.detail_enter_coupon_supplies_id.Equals(de.detail_enter_coupon_supplies_id)).SingleOrDefault( );

                update.supplies_id = de.supplies_id;
                update.enter_coupon_supplies_id = de.enter_coupon_supplies_id;
                update.detail_enter_coupon_supplies_quatity = de.detail_enter_coupon_supplies_quatity;
                update.detail_enter_coupon_supplies_total = de.detail_enter_coupon_supplies_total;

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
