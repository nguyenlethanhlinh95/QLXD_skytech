using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class constructionDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public object getAllContruction()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var buildingContractor = from t1 in db.ST_constructions
                                         join t2 in db.ST_customers
                                         on t1.customer_id equals t2.customer_id
                                         select new
                                         {
                                             t1.construction_id,
                                             t1.construction_id_custom,
                                             t1.construction_name,
                                            
                                         }
                                              ;
                return buildingContractor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool deleteContruction(Int64 id)
        {
            try
            {
                var delete = db.ST_constructions.Where(p => p.construction_id.Equals(id)).SingleOrDefault();

                db.ST_constructions.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
