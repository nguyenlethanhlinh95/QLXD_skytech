using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class IncomeCouponBus
    {
        DAO.IncomeCouponDao IncomeCouponDao = new DAO.IncomeCouponDao();
        public object getAllIncomeCouponConstruction()
        {
           return IncomeCouponDao.getAllIncomeCouponConstruction();
        }
        public bool deleteIncomeCoupon(Int64 incomeCouponId)
        {
            return IncomeCouponDao.deleteIncomeCoupon(incomeCouponId);
        }
        public object getAllIncomeCouponConstructionWithDayStarDayEnd(DateTime dateStart, DateTime dateEnd)
        {
            return IncomeCouponDao.getAllIncomeCouponConstructionWithDayStarDayEnd(dateStart, dateEnd);
        }
        public object getAllIncomeCouponConstructionWithDayStar(DateTime dateStart)
        {
            return IncomeCouponDao.getAllIncomeCouponConstructionWithDayStar(dateStart);
        }
    }
}
