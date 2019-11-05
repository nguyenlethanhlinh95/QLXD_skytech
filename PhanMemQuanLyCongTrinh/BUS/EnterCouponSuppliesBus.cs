using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class EnterCouponSuppliesBus
    {
        EnterCouponSuppliesDao _enter = new EnterCouponSuppliesDao();

        public bool isCheckNumber(string name)
        {
            return _enter.isCheckNumber(name);
        }

        public object getAllEnterCoupon( )
        {
            return _enter.getAllEnterCoupon( );
        }
        public object getEnterCouponWithDayStar(DateTime dateStart)
        {
            return _enter.getEnterCouponWithDayStar(dateStart);
        }
        public object getEnterCouponWithDayStarDayEnd(DateTime dateStart, DateTime dateEnd)
        {
            return _enter.getEnterCouponWithDayStarDayEnd(dateStart, dateEnd);
        }

        public IEnumerable<object> getAllEnterCouponSupplies( )
        {
            return _enter.getAllEnterCouponSupplies();
        }

        public object getEnterCouponSupplies(Int64 id)
        {
            return _enter.getEnterCouponSupplies(id);
        }

        public bool deleteEnterCouponSupplies(Int64 id)
        {
            return _enter.deleteEnterCouponSupplies(id);
        }

        public Int64 insertEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            return _enter.insertEnterCouponSupplies(enter);
        }

        public bool updateEnterCouponSupplies(DTO.ST_enter_coupon_supply enter)
        {
            return _enter.updateEnterCouponSupplies(enter);
        }
    }
}
