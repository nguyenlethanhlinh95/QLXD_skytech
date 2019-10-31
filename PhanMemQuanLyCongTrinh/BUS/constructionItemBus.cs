using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    
    class constructionItemBus
    {
        DAO.constructionItemDao constructionItemDao = new DAO.constructionItemDao();
        public bool isContructionIdtemGroup(Int64 contructionId)
        {
            var construction = constructionItemDao.isContructionIdtemGroup(contructionId);
          
            if (construction!=null)
            
                return true;
            
            else
            
                return false;
            

           
        }
        public object getContructionItemWithGroup(Int64 contructionId)
        {
            return constructionItemDao.getContructionItemWithGroup(contructionId);
        }
    }
}
