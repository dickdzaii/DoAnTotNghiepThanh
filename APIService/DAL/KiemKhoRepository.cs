using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class KiemKhoRepository:IKiemKhoRepository
    {
        private IDatabaseHelper _dbHelper;
        public KiemKhoRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<KiemKhoModel> GetKiemKhos(string linkshop,int index, int size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkiemkho",
                    "@linkshop",linkshop,
                    "@page_index", index,
                    "@page_size", size
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KiemKhoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietKiemKhoModel> GetChiTietKiemKhos(string makiemkho)
        {
            
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetchitietKK",
                    "@MaKiemKho", makiemkho
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
             
                return dt.ConvertTo<ChiTietKiemKhoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public KiemKhoModel GetKiemKhoById(string makiemkho)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkiemkhobyid",
                    "@MaKiemKho", makiemkho
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<KiemKhoModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
