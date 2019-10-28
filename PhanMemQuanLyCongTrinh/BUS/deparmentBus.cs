using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class deparmentBus
    {
        departmentDao departmentDao = new departmentDao();
        public IEnumerable<Object> listAll()
        {
            return departmentDao.getAllDepartment();
        }
    }
}
