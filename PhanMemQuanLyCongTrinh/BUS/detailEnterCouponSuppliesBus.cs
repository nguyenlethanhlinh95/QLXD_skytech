﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class DetailEnterCouponSuppliesBus
    {
        DetailEnterCouponSuppliesDao _de = new DetailEnterCouponSuppliesDao();
        public IEnumerable<object> getAll( )
        {
            return _de.getAll();
        }


        public IEnumerable<Object> getAllSupplies(Int64 idEnter)
        {
            return _de.getAllSupplies(idEnter);
        }

        public object getDetail(Int64 id)
        {
            return _de.getDetail(id);
        }

        public bool delete(Int64 id)
        {
            return _de.delete(id);
        }

        public bool insert(DTO.ST_detail_enter_coupon_supply de)
        {
            return _de.insert(de);
        }

        public bool updatet(DTO.ST_detail_enter_coupon_supply de)
        {
            return _de.updatet(de);
        }
    }
}