using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class departmentDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public IEnumerable<Object> getAllDepartment()
        {
            try
            {
                var data = from d in db.ST_departments
                           select d;

                return data;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
