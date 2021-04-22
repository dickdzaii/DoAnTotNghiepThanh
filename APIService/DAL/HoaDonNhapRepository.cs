using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class HoaDonNhapRepository:IHoaDonNhapRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonNhapRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<HoaDonNhapModel> GetHDNbyShop(string mashop,int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gethdnbyshop", "@mashop", mashop,"@page_index", page_index, "@page_size", page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HoaDonNhapModel GetHDNbyID(string mahdn)
        {
            
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gethdnbyid", "@mahdn", mahdn);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
             
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietHoaDonNhapModel> GetCtHDN(string mahdn)
        {
            
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getchthdn", "@mahdn", mahdn);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                
                return dt.ConvertTo<ChiTietHoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhaCungCapModel> AllNCC()
        {
            
                string msgError = "";
                try
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getncc");
                    if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);

                    return dt.ConvertTo<NhaCungCapModel>().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
        }
       
        public NhaCungCapModel GetNCCByHDN(string mahdn)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getnccbyhdn","mahdn",mahdn);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<NhaCungCapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public HoaDonNhapModel Them(HoaDonNhapModel hdn)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "themhdn",
                    "@mancc", hdn.MaNCC,
                    "@mashop",hdn.MaShop,
                    "@chitiet",hdn.chitiet != null ? MessageConvert.SerializeObject(hdn.chitiet) : null);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public KhoModel TangSLSP(string masp,int soluong)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "tangslsp",
                    "@masp", masp,
                    "@soluong", soluong
                   );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                return dt.ConvertTo<KhoModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
