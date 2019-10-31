using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class constructionBus
    {
        DAO.constructionDao constructionDao = new DAO.constructionDao();
        public object getAllContruction()
        {
            return constructionDao.getAllContruction();
        }
        public bool deleteContruction(Int64 id)
        {
            return constructionDao.deleteContruction(id);
        }
        
    }
}
