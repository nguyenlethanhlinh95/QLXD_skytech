using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class userBus
    {
        userDao _userDao = new userDao();

       public Int64 checkLogin(string userName, string passWord)
       {
           Int64 IntCheck = _userDao.CheckLogin(userName, passWord);

           if ( IntCheck > 0)
           {
               return IntCheck;
           }
           else
               return 0;
       }

       public Object getUserByID(Int64 id)
       {
            var user = _userDao.getUserById(id);

            return user;
       }


    }
}
