using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
using PhanMemQuanLyCongTrinh.DAO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class DetailPulicDebtBus
    {
        DetailPulicDebtDao _de = new DetailPulicDebtDao( );

        public IEnumerable<object> getAllDetailPulicDebts( )
        {
            return _de.getAllDetailPulicDebts();
        }

        public object getDetailPulicDebts(Int64 id)
        {
            return _de.getDetailPulicDebts(id);
        }

        public bool deleteDetailPulicDebts(Int64 id)
        {
            return _de.deleteDetailPulicDebts(id);
        }

        public bool insertDetailPulicDebts(DTO.ST_detail_pulic_debt de)
        {
            return _de.insertDetailPulicDebts(de);
        }

        public bool updateDetailPulicDebts(DTO.ST_detail_pulic_debt de)
        {
            return _de.updateDetailPulicDebts(de);
        }
    }
}
