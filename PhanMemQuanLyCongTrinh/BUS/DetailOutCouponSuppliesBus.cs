using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class DetailOutCouponSuppliesBus
    {
        DAO.DetailOutCouponSuppliesDao detailOCSDao = new DAO.DetailOutCouponSuppliesDao();
        public Int64 insertDetailOutCoupon(DTO.ST_detail_out_coupon_supply detailOCS)
        {
            return detailOCSDao.insertDetailOutCoupon(detailOCS);
        }
        public bool deleteOutCoupon(Int64 id)
        {
            return detailOCSDao.deleteOutCoupon(id);
        }
        public IQueryable<object> getDetailCouponWithOutCouton(Int64 id)
        {
            return detailOCSDao.getDetailCouponWithOutCouton(id);
        }
        public IQueryable<object> getAllDetailOCP(Int64 id)
        {
            return detailOCSDao.getAllDetailOCP(id);
        }
    }
}
