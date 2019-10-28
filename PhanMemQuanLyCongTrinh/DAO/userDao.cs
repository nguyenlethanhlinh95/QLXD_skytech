using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class userDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Int64 CheckLogin(string username, string password)
        {
            try{
                var user = (from u in db.ST_employees
                           where u.employee_username == username && u.employee_password == password
                           select u.employee_id).First();

                //var propertyName = user.GetType( ).GetProperty("employee_id").GetValue(user, null);
                //Int64 userID = Convert.ToInt64(propertyName);
                if ( user > 0 )
                {
                    return user;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        public IEnumerable<Object> getAllUser()
        {
            var users = from u in db.ST_employees
                        select u;

            return users;
        }

        public Object getUserByUserName(string userName)
        {
            var users = (from u in db.ST_employees
                        where u.employee_username == userName
                        select u).First();
            return users;
        }

        public Object getUserById(Int64 id)
        {
            var users = (from u in db.ST_employees
                         where u.employee_id == id
                         select u).First( );
            return users;
        }

        public Int64 getIDByUserName(string userName)
        {
            var users = (from u in db.ST_employees
                         where u.employee_username == userName
                         select u).First( );

            var propertyName = users.GetType( ).GetProperty("employee_id").GetValue(users, null);

            return Convert.ToInt64(propertyName);
        }
    }
}
