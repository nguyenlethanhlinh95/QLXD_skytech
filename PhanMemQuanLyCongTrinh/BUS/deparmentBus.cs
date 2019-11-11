using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class DeparmentBus
    {
        DepartmentDao departmentDao = new DepartmentDao();
        public IEnumerable<Object> listAll()
        {
            return departmentDao.getAllDepartment();
        }

        public bool insert(string name)
        {
            bool boolInsert = departmentDao.insertDepartment(name);

            if (boolInsert)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Object getDepartment(Int64 id)
        {
            return departmentDao.getDeparment(id);
        }

        public bool update(string name, Int64 id)
        {
            return departmentDao.update(name, id);
        }

        public bool deleteDepartment(Int64 idDepartment)
        {
            return departmentDao.deleteDepartment(idDepartment);
        }
    }
}
