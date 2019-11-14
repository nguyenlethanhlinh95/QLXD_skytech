using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class IncomeCouponDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public object getAllIncomeCouponConstruction()
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_income_coupons
                              join t2 in db.ST_constructions
                              on t1.construction_id equals t2.construction_id
                              join t3 in db.ST_employees
                              on t1.employee_id_created equals t3.employee_id
                              where t1.construction_id != 0
                              select new{
                                 t1.income_coupon_id,
                                 t1.income_coupon_id_custom,
                                 t1.detail_income_and_expenditure_pattern_id,
                                 t1.income_coupon_created_date,
                                 t1.income_coupon_total_price,
                                 t3.employee_name,
                                 t1.income_coupon_description,
                                 t2.construction_name,
                              };
                return listAll;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public object getAllIncomeCouponConstructionWithDayStar(DateTime dateStart)
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_income_coupons
                              join t2 in db.ST_constructions
                              on t1.construction_id equals t2.construction_id
                              join t3 in db.ST_employees
                              on t1.employee_id_created equals t3.employee_id
                              where t1.construction_id != 0 && t1.income_coupon_created_date >= dateStart
                              
                              select new
                              {
                                  t1.income_coupon_id,
                                  t1.income_coupon_id_custom,
                                  t1.detail_income_and_expenditure_pattern_id,
                                  t1.income_coupon_created_date,
                                  t1.income_coupon_total_price,
                                  t3.employee_name,
                                  t1.income_coupon_description,
                                  t2.construction_name,
                              };
                return listAll;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public object getAllIncomeCouponConstructionWithDayStarDayEnd(DateTime dateStart,DateTime dateEnd)
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_income_coupons
                              join t2 in db.ST_constructions
                              on t1.construction_id equals t2.construction_id
                              join t3 in db.ST_employees
                              on t1.employee_id_created equals t3.employee_id
                              where t1.construction_id != 0 && t1.income_coupon_created_date >= dateStart && t1.income_coupon_created_date <= dateEnd

                              select new
                              {
                                  t1.income_coupon_id,
                                  t1.income_coupon_id_custom,
                                  t1.detail_income_and_expenditure_pattern_id,
                                  t1.income_coupon_created_date,
                                  t1.income_coupon_total_price,
                                  t3.employee_name,
                                  t1.income_coupon_description,
                                  t2.construction_name,
                              };
                return listAll;

            }
            catch (Exception)
            {
                return null;
            }
        }




        public bool deleteIncomeCoupon(Int64 incomeCouponId)
        {
            try
            {
                var delete = db.ST_income_coupons.Where(p => p.income_coupon_id.Equals(incomeCouponId)).SingleOrDefault();

                db.ST_income_coupons.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
