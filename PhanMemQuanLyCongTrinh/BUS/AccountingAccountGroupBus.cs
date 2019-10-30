﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class AccountingAccountGroupBus
    {
        DAO.AccountingAccountGroupDao AAG = new DAO.AccountingAccountGroupDao();
        public object getAllAccountingAcountGroup()
        {
            return AAG.getAllAccountingAcountGroup();
        }
        public bool deleteAAG(Int64 AAGId)
        {
            return AAG.deleteAAG(AAGId);
        }
        public bool insertAAGroup(DTO.ST_income_and_expenditure_pattern AAgroup)
        {
            return AAG.insertAAGroup(AAgroup);
        }
        public bool updateAAGroup(DTO.ST_income_and_expenditure_pattern AAgroup)
        {
            return  AAG.updateAAGroup(AAgroup);
        }
        public object getAccountingAcountGroup(Int64 AAGroupId)
        {
            return AAG.getAccountingAcountGroup(AAGroupId);
        }
    }
}
