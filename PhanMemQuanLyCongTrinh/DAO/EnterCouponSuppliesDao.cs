﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class EnterCouponSuppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public Int64 getIdStoreHouse(Int64 idEnter)
        {
            try
            {
                Int64 id = (from b in db.ST_enter_coupon_supplies
                            where b.enter_coupon_supplies_id == idEnter
                            select b.storehouse_id).Single();

                return id;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        // lay tien thanh toan dau tien
        public Decimal getPrice_Pay(Int64 idPhieuNhap)
        {
            try
            {
                var data = (from b in db.ST_payment_slips
                            where b.enter_coupon_supplies_id == idPhieuNhap
                            orderby b.payment_slip_created_date ascending
                            select b.payment_slip_total_price).First( );
                return data.Value;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public Int64 getIdVender(Int64 idEnter)
        {
            try
            {
                Int64 id = (from b in db.ST_enter_coupon_supplies
                            where b.enter_coupon_supplies_id == idEnter
                            select b.vendor_id).Single( );

                return id;
            }
            catch ( Exception )
            {
                return 0;
            }

        }

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
                var update = db.ST_enter_coupon_supplies.Where(p => p.enter_coupon_supplies_id.Equals(enter.enter_coupon_supplies_id)).SingleOrDefault( );

                if ( update.storehouse_id == enter.storehouse_id)
                {
                    update.enter_coupon_supplies_id = enter.enter_coupon_supplies_id;
                    update.vendor_id = enter.vendor_id;
                    update.storehouse_id = enter.storehouse_id;
                    update.enter_coupon_supplies_number = enter.enter_coupon_supplies_number;
                    update.enter_coupon_supplies_created_date = enter.enter_coupon_supplies_created_date;
                    update.enter_coupon_supplies_description = enter.enter_coupon_supplies_description;
                    update.enter_coupon_supplies_total_price = enter.enter_coupon_supplies_total_price;
                    update.enter_coupon_supplies_document = enter.enter_coupon_supplies_document;
                    update.employee_created = enter.employee_created;
                    update.enter_coupon_supplies_deliver = enter.enter_coupon_supplies_deliver;
                    db.SubmitChanges( );
                    return true;
                }

                return false;
                
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}
