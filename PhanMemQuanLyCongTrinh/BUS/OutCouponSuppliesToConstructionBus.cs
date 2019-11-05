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




    }
}
