using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class pulicDebtDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public bool checkVender(Int64 id)
        {
            var collection = from b in db.ST_pulic_debts
                            where b.vendor_id == id
                            select b.vendor_id;

            if (collection.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Int64 getPublicIDFromVenderID(Int64 id)
        {
            try{
                var collection = (from b in db.ST_pulic_debts
                                  where b.vendor_id == id
                                  select b).Single( );
                if (collection.pulic_debt_id != 0)
                {
                    return collection.pulic_debt_id;
                }
                else
                {
                    return 0;
                }
                
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public IEnumerable<object> getAllPulicDebts( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from t1 in db.ST_pulic_debts
                             select t1;
                return datasource;
            }
            catch ( Exception )
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
        }

        public object getPulicDebt(Int64 id)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_pulic_debts
                            where t1.pulic_debt_id == id
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public bool deletePulicDebt(Int64 id)
        {
            try
            {
                var delete = db.ST_pulic_debts.Where(p => p.pulic_debt_id.Equals(id)).SingleOrDefault( );

                db.ST_pulic_debts.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Int64 insertPulicDebt(DTO.ST_pulic_debt de)
        {
            try
            {
                db.ST_pulic_debts.InsertOnSubmit(de);
                db.SubmitChanges( );
                return de.pulic_debt_id;
            }
            catch ( Exception )
            {
                return 0;
            }
        }

        public bool updatePulicDebt(DTO.ST_pulic_debt de)
        {
            try
            {
                var update = db.ST_pulic_debts.Where(p => p.pulic_debt_id.Equals(de.pulic_debt_id)).SingleOrDefault( );

                update.vendor_id = de.vendor_id;
                update.customer_id = de.customer_id;

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
