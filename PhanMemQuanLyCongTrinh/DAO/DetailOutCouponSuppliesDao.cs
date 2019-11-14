using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class DetailOutCouponSuppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Int64 insertDetailOutCoupon(DTO.ST_detail_out_coupon_supply detailOCS)
        {
            try
            {
                db.ST_detail_out_coupon_supplies.InsertOnSubmit(detailOCS);
                db.SubmitChanges();
                return detailOCS.detail_out_coupon_supplies_id;
            }
            catch
            {
                return 0;
            }
        }



        public bool deleteOutCoupon(Int64 id)
        {
            try
            {
                var delete = db.ST_detail_out_coupon_supplies.Where(p => p.out_coupon_supplies_id.Equals(id));

               
                    db.ST_detail_out_coupon_supplies.DeleteAllOnSubmit(delete);
                
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IQueryable<object> getAllDetailOCP(Int64 id)
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_detail_out_coupon_supplies
                              join t2 in db.ST_supplies 
                              on t1.supplies_id equals t2.supplies_id
                              join t3 in db.ST_units
                              on t2.unit_id equals t3.unit_id
                              where t1.out_coupon_supplies_id == id
                              select new
                              {
                                  t1.detail_out_coupon_supplies_id,
                                  t1.supplies_id,
                                  t2.supplies_name,
                                  t3.unit_name,
                                  t1.detail_out_coupon_supplies_quantity,
                                  t2.supplies_commercial_price,
                                 t2.supplies_id_custom
                              };


                return listAll;
            }
            catch (Exception)
            {
                return null;
            }
        }



        public IQueryable<object> getDetailCouponWithOutCouton(Int64 id)
        {
            try
            {
                db.Dispose();
                db = new DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from t1 in db.ST_detail_out_coupon_supplies
                              join t2 in db.ST_out_coupon_supplies
                             on t1.out_coupon_supplies_id equals t2.out_coupon_supplies_id
                              where t1.out_coupon_supplies_id == id
                              select new
                              {
                                  t1.detail_out_coupon_supplies_id,
                                  t1.supplies_id,
                                  t1.detail_out_coupon_supplies_quantity,
                                  t2.storehouse_id
                              };
                            
                             
                return listAll;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
