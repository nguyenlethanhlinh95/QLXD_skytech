using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class PulicDebtBus
    {
        PulicDebtDao _pu = new PulicDebtDao();
        public IEnumerable<object> getAllPulicDebts( )
        {
            return _pu.getAllPulicDebts();
        }

        public Int64 getPublicFromVenderID(Int64 id)
        {
            return _pu.getPublicIDFromVenderID(id);
        }

        public bool checkVender(Int64 id)
        {
            return _pu.checkVender(id);
        }

        public object getPulicDebt(Int64 id)
        {
            return _pu.getPulicDebt(id);
        }

        public bool deletePulicDebt(Int64 id)
        {
            return _pu.deletePulicDebt(id);
        }

        public Int64 insertPulicDebt(DTO.ST_pulic_debt de)
        {
            return _pu.insertPulicDebt(de);
        }

        public bool updatePulicDebt(DTO.ST_pulic_debt de)
        {
            return _pu.updatePulicDebt(de);
        }
    }
}
