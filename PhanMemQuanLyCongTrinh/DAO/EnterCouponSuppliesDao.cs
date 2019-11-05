using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class EnterCouponSuppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public bool isCheckNumber(string name)
        {
            var collection = from b in db.ST_enter_coupon_supplies
                            where b.enter_coupon_supplies_number == name
                            select b.enter_coupon_supplies_id;
            if (collection.Any())
            {
                return true;
            }
            else
                return false;
            
        }

        public object getAllEnterCoupon( )
        {
            try
            {
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_enter_coupon_supplies
                              join t2 in db.ST_storehouses
                             on t1.storehouse_id equals t2.storehouse_id
                              join t3 in db.ST_employees
                              on t1.employee_created equals t3.employee_id
                              select new
                              {
                                  t1.enter_coupon_supplies_id,
                                  t1.enter_coupon_supplies_created_date,
                                  t1.enter_coupon_supplies_description,
                                  t1.enter_coupon_supplies_id_custom,
                                  t1.enter_coupon_supplies_number,
                                  t1.enter_coupon_supplies_total_price,
                                  t1.enter_coupon_supplies_total_percent_discount,
                                  t2.storehouse_name,
                                  t3.employee_name
                              };
                return listAll;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public object getEnterCouponWithDayStar(DateTime dateStart)
        {
            try
            {
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_enter_coupon_supplies
                              join t2 in db.ST_storehouses
                              on t1.storehouse_id equals t2.storehouse_id
                              join t3 in db.ST_employees
                              on t1.employee_created equals t3.employee_id
                              where t1.enter_coupon_supplies_created_date >= dateStart
                              select new
                              {
                                  t1.enter_coupon_supplies_id,
                                  t1.enter_coupon_supplies_created_date,
                                  t1.enter_coupon_supplies_description,
                                  t1.enter_coupon_supplies_id_custom,
                                  t1.enter_coupon_supplies_number,
                                  t1.enter_coupon_supplies_total_percent_discount,
                                  t1.enter_coupon_supplies_total_price,
                                  t2.storehouse_name,
                                  t3.employee_name
                              };
                return listAll;
            }
            catch ( Exception )
            {
                return null;
            }
        }
        public object getEnterCouponWithDayStarDayEnd(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_enter_coupon_supplies
                              join t2 in db.ST_storehouses
                              on t1.storehouse_id equals t2.storehouse_id
                              join t3 in db.ST_employees
                              on t1.employee_created equals t3.employee_id
                              where t1.enter_coupon_supplies_created_date >= dateStart
                              where t1.enter_coupon_supplies_created_date >= dateStart && t1.enter_coupon_supplies_created_date <= dateEnd
                              select new
                              {
                                  t1.enter_coupon_supplies_id,
                                  t1.enter_coupon_supplies_created_date,
                                  t1.enter_coupon_supplies_description,
                                  t1.enter_coupon_supplies_id_custom,
                                  t1.enter_coupon_supplies_number,
                                  t1.enter_coupon_supplies_total_price,
                                  t1.enter_coupon_supplies_total_percent_discount,
                                  t2.storehouse_name,
                                  t3.employee_name
                              };
                return listAll;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public IEnumerable<object> getAllEnterCouponSupplies( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from pm in db.ST_enter_coupon_supplies
                                 select pm;
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

        public object getEnterCouponSupplies(Int64 id)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_enter_coupon_supplies
                            where t1.enter_coupon_supplies_id == id
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public bool deleteEnterCouponSupplies(Int64 id)
        {
            try
            {
                var delete = db.ST_enter_coupon_supplies.Where(p => p.enter_coupon_supplies_id.Equals(id)).SingleOrDefault( );

                db.ST_enter_coupon_supplies.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Int64 insertEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            try
            {
                db.ST_enter_coupon_supplies.InsertOnSubmit(enter);
                db.SubmitChanges( );
                return enter.enter_coupon_supplies_id;
            }
            catch ( Exception )
            {
                return 0;
            }
        }

        public bool updateEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            try
            {
                var updateVendor = db.ST_enter_coupon_supplies.Where(p => p.enter_coupon_supplies_id.Equals(enter.enter_coupon_supplies_id)).SingleOrDefault( );

                //updateVendor. = unit.unit_name;

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
