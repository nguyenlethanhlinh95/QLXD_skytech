using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class AcountingAcountDaocs
    {
        DataClasses1DataContext db = new DTO.DataClasses1DataContext();

        public object getAllAcountingAcount()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var AcountingAcount = from t1 in db.ST_detail_income_and_expenditure_patterns
                               join t2 in db.ST_income_and_expenditure_patterns
                               on t1.income_and_expenditure_pattern_id equals t2.income_and_expenditure_pattern_id
                               select new
                               {
                                   t1.detail_income_and_expenditure_pattern_id,
                                   t1.detail_income_and_expenditure_pattern_id_custom,
                                   t1.detail_income_and_expenditure_pattern_description,
                                   t2.income_and_expenditure_pattern_name,
                               }
                                   ;
                return AcountingAcount;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getAcountingAcount(Int64 AAId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var AcountingAcount = from t1 in db.ST_detail_income_and_expenditure_patterns
                               join t2 in db.ST_income_and_expenditure_patterns
                               on t1.income_and_expenditure_pattern_id equals t2.income_and_expenditure_pattern_id
                               where t1.detail_income_and_expenditure_pattern_id == AAId
                               select new
                               {
                                   t1.detail_income_and_expenditure_pattern_id,
                                   t1.detail_income_and_expenditure_pattern_id_custom,
                                   t1.detail_income_and_expenditure_pattern_description,
                                   t2.income_and_expenditure_pattern_name,
                               }
                                   ;
                return AcountingAcount;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getAcountingAcountWithGroup(Int64 AcountingAcountGroupId)
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var AcountingAcount = from t1 in db.ST_detail_income_and_expenditure_patterns
                                      join t2 in db.ST_income_and_expenditure_patterns
                                      on t1.income_and_expenditure_pattern_id equals t2.income_and_expenditure_pattern_id
                                      where t1.income_and_expenditure_pattern_id == AcountingAcountGroupId
                                      select new
                                      {
                                          t1.detail_income_and_expenditure_pattern_id,
                                          t1.detail_income_and_expenditure_pattern_id_custom,
                                          t1.detail_income_and_expenditure_pattern_description,
                                          t2.income_and_expenditure_pattern_name,
                                      }
                                   ;
                return AcountingAcount;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool insertAcountingAcount(DTO.ST_detail_income_and_expenditure_pattern AcountingAcount)
        {
            try
            {
                db.ST_detail_income_and_expenditure_patterns.InsertOnSubmit(AcountingAcount);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool updateAcountingAcount(DTO.ST_detail_income_and_expenditure_pattern AcountingAcount)
        {
            try
            {
                var updateAcountingAcount = db.ST_detail_income_and_expenditure_patterns.Where(p => p.detail_income_and_expenditure_pattern_id.Equals(AcountingAcount.detail_income_and_expenditure_pattern_id)).SingleOrDefault();

                updateAcountingAcount.detail_income_and_expenditure_pattern_id_custom = AcountingAcount.detail_income_and_expenditure_pattern_id_custom;
                updateAcountingAcount.detail_income_and_expenditure_pattern_description = AcountingAcount.detail_income_and_expenditure_pattern_description;
                updateAcountingAcount.income_and_expenditure_pattern_id = AcountingAcount.income_and_expenditure_pattern_id;
                
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteCustomer(Int64 id)
        {
            try
            {
                var delete = db.ST_customers.Where(p => p.customer_id.Equals(id)).SingleOrDefault();

                db.ST_customers.DeleteOnSubmit(delete);
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
