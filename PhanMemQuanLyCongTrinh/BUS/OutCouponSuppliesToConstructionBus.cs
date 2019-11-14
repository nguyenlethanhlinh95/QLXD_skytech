using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class OutCouponSuppliesToConstructionBus
    {
        DAO.OutCouponSuppliesToConstructionDao outCoupon = new DAO.OutCouponSuppliesToConstructionDao();
        public object getAllOutCouponToConstruction()
        {
           return outCoupon.getAllOutCouponToConstruction();
        }
        public object getOutCouponToConstructionWithDayStar(DateTime dateStart)
        {
            return outCoupon.getOutCouponToConstructionWithDayStar(dateStart);
        }
        public object getOutCouponToConstructionWithDayStarDayEnd(DateTime dateStart, DateTime dateEnd)
        {
            return outCoupon.getOutCouponToConstructionWithDayStarDayEnd(dateStart, dateEnd);
        }

        public object getOutCouponToConstruction(Int64 outCouponId)
        {
            return outCoupon.getOutCouponToConstruction(outCouponId);
        }

        public bool deleteOutCoupon(Int64 id)
        {
            return outCoupon.deleteOutCoupon(id);
        }

        public bool isCouponNumber(string couponNumber)
        {
            var coupon = outCoupon.isCouponNumber(couponNumber);
            if (coupon == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public Int64 insertOutCouponConstruction(DTO.ST_out_coupon_supply outCoupons)
        {
            return outCoupon.insertOutCouponConstruction(outCoupons);
        }

    }
}
