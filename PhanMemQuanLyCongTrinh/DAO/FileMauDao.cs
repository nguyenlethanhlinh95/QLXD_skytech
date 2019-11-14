using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class FileMauDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public IEnumerable<object> getAll( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from t1 in db.ST_FileMaus
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

        public object Detail(Int64 id)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_FileMaus
                            where t1.fileMau_id == id
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }


        public bool delete(Int64 id)
        {
            try
            {
                var delete = db.ST_FileMaus.Where(p => p.fileMau_id.Equals(id)).SingleOrDefault( );

                db.ST_FileMaus.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insert(DTO.ST_FileMau fileMau)
        {
            try
            {
                db.ST_FileMaus.InsertOnSubmit(fileMau);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }


        public bool update(DTO.ST_FileMau fileMau)
        {
            try
            {
                var update = db.ST_FileMaus.Where(p => p.fileMau_id.Equals(fileMau.fileMau_id)).SingleOrDefault( );

                update.fileMau_TenDanhMuc = fileMau.fileMau_TenDanhMuc;
                update.fileMau_File = fileMau.fileMau_File;

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
