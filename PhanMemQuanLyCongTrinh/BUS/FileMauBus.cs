using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class FileMauBus
    {
        FileMauDao _file = new FileMauDao();

        public IEnumerable<object> getAll( )
        {
            return _file.getAll();
        }

        public object Detail(Int64 id)
        {
            return _file.Detail(id);
        }

        public bool delete(Int64 id)
        {
            return _file.delete(id);
        }

        public bool insert(DTO.ST_FileMau fileMau)
        {
            return _file.insert(fileMau);
        }

        public bool update(DTO.ST_FileMau fileMau)
        {
            return _file.update(fileMau);
        }
    }
}
