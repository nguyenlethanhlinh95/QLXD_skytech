using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class group_suppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public IEnumerable<Object> getAllGroupSupplies()
        {
            try{
                var listAll = from g in db.ST_group_supplies
                              select g;
                return listAll;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public Object getGroupSupplie(Int64 id)
        {
            try{
                var item = (from b in db.ST_group_supplies
                            where b.group_supplies_id == id
                            select b).Single( );

                return item;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public bool insertGroupSupplie(ST_group_supply group)
        {
            try{
                db.ST_group_supplies.InsertOnSubmit(group);
                db.SubmitChanges( );

                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public bool updateGroupSupplie(ST_group_supply group_supp)
        {
            try
            {
                var group = (from b in db.ST_group_supplies
                            where group_supp.group_supplies_id == b.group_supplies_id
                            select b).Single();
                group.group_supplies_name = group_supp.group_supplies_name;              
                db.SubmitChanges( );

                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool deleteGroupSupplie(Int64 id)
        {
            try
            {
                var delete = db.ST_group_supplies.Where(p => p.group_supplies_id.Equals(id)).SingleOrDefault( );

                db.ST_group_supplies.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}
