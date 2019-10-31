using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class constructionItemDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public object isContructionIdtemGroup(Int64 contructionId)
        {
            try
            {
                var Contruction = from d in db.ST_construction_items where d.construction_id == contructionId select d;
                return Contruction.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getContructionItemWithGroup(Int64 contructionId)
        {

            db.Dispose();
            db = new DataClasses1DataContext();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

            var customer = from t1 in db.ST_construction_items
                           join t2 in db.ST_constructions
                           on t1.construction_id equals t2.construction_id
                           join t3 in db.ST_building_contractors
                           on t1.building_contractor_id equals t3.building_contractor_id
                           where t1.construction_id == contructionId
                           select new
                           {
                               t1.construction_item_id,
                               t1.construction_item_custom,
                               t1.construction_item_name,
                               t2.construction_name,
                               t3.building_contractor_name,
                               t1.construction_item_total_price,
                               t1.construction_item_date_start,
                               t1.construction_item_date_end,
                               t1.construction_item_status,

                           }
                                  ;
            return customer;
        }

    }
}
