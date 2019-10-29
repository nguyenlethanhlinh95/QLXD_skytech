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
            catch(Exception )
            {
                return null;
            }
        }

        public Object getDeparment(Int64 id)
        {
            
            try{
                var depament = from b in db.ST_departments
                               where b.department_id == id
                               select b;

                return depament;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public bool insertDepartment(string name)
        {
            try{
                ST_department dp = new ST_department( );

                dp.department_name = name;

                db.ST_departments.InsertOnSubmit(dp);
                db.SubmitChanges( );
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
    }
}
