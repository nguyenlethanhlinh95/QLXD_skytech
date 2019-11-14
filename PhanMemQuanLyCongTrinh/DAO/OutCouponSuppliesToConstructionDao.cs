using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{

    class OutCouponSuppliesToConstructionDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public object getAllOutCouponToConstruction()
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_out_coupon_supplies
                              join t2 in db.ST_storehouses
                             on t1.storehouse_id equals t2.storehouse_id
                              join t3 in db.ST_employees
                              on t1.employee_id_created equals t3.employee_id
                              join t4 in db.ST_constructions
                              on t1.construction_id equals t4.construction_id
                              select new
                              {
                                  t1.out_coupon_supplies_id,
                                  t1.out_coupon_supplies_created_date,
                                  t1.out_coupon_supplies_description,
                                  t1.out_coupon_supplies_id_custom,
                                  t1.out_coupon_supplies_number,
                                  t1.out_coupon_supplies_total_price,
                                  t1.out_coupon_supplies_total_percent_discount,
                                  t2.storehouse_name,
                                  t3.employee_name,
                                  t4.construction_name
                              };
                return listAll;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getOutCouponToConstructionWithDayStar(DateTime dateStart)
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_out_coupon_supplies
                              join t2 in db.ST_storehouses
                             on t1.storehouse_id equals t2.storehouse_id
                              join t3 in db.ST_employees
                              on t1.employee_id_created equals t3.employee_id
                              join t4 in db.ST_constructions
                              on t1.construction_id equals t4.construction_id
                              where t1.out_coupon_supplies_created_date >= dateStart
                              select new
                              {
                                  t1.out_coupon_supplies_id,
                                  t1.out_coupon_supplies_created_date,
                                  t1.out_coupon_supplies_description,
                                  t1.out_coupon_supplies_id_custom,
                                  t1.out_coupon_supplies_number,
                                  t1.out_coupon_supplies_total_price,
                                  t1.out_coupon_supplies_total_percent_discount,
                                  t2.storehouse_name,
                                  t3.employee_name,
                                  t4.construction_name
                              };
                return listAll;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object getOutCouponToConstructionWithDayStarDayEnd(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_out_coupon_supplies
                              join t2 in db.ST_storehouses
                             on t1.storehouse_id equals t2.storehouse_id
                              join t3 in db.ST_employees
                              on t1.employee_id_created equals t3.employee_id
                              join t4 in db.ST_constructions
                              on t1.construction_id equals t4.construction_id
                              where t1.out_coupon_supplies_created_date >= dateStart && t1.out_coupon_supplies_created_date <= dateEnd
                              select new
                              {
                                  t1.out_coupon_supplies_id,
                                  t1.out_coupon_supplies_created_date,
                                  t1.out_coupon_supplies_description,
                                  t1.out_coupon_supplies_id_custom,
                                  t1.out_coupon_supplies_number,
                                  t1.out_coupon_supplies_total_price,
                                  t1.out_coupon_supplies_total_percent_discount,
                                  t2.storehouse_name,
                                  t3.employee_name,
                                  t4.construction_name
                              };
                return listAll;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Int64 insertOutCouponConstruction(DTO.ST_out_coupon_supply outCoupon)
        {
            try
            {
                db.ST_out_coupon_supplies.InsertOnSubmit(outCoupon);
                db.SubmitChanges( );
                return outCoupon.out_coupon_supplies_id;
            }
            catch
            {
                return 0;
            }
        }
        public object isCouponNumber(string couponNumber)
        {
            try
            {
                var coupon = from t1 in db.ST_out_coupon_supplies where t1.out_coupon_supplies_number == couponNumber select t1;
                return coupon.First( );
            }
            catch
            {
                return null;
            }
        }
        public bool deleteOutCoupon(Int64 id)
        {
            try
            {
                var delete = db.ST_out_coupon_supplies.Where(p => p.out_coupon_supplies_id.Equals(id)).SingleOrDefault( );
                db.ST_out_coupon_supplies.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }
        public object getOutCouponToConstruction(Int64 outCouponId)
        {
            try
            {
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var listAll = from t1 in db.ST_out_coupon_supplies
                              join t4 in db.ST_construction_items
                               on t1.construction_item_id equals t4.construction_item_id
                              join t5 in db.ST_constructions
                              on t4.construction_id equals t5.construction_id
                              select new
                              {
                                  t1.out_coupon_supplies_id,
                                  t1.out_coupon_supplies_created_date,
                                  t1.out_coupon_supplies_description,
                                  t1.out_coupon_supplies_id_custom,
                                  t1.out_coupon_supplies_number,
                                  t1.out_coupon_supplies_receiver,
                                  t1.out_coupon_supplies_total_price,
                                  t1.out_coupon_supplies_total_percent_discount,
                                  t1.storehouse_id,
                                  t1.construction_item_id,
                                  t5.construction_id,
                              };
                return listAll.First( );
            }
            catch ( Exception )
            {
                return null;
            }
        }
        


    }
}
