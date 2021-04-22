using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DonHangRepository:IDonHangRepository
    {

        private IDatabaseHelper _dbHelper;
        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<DonHangModel> GetDonHangByShop(string mashop, int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdhbyshop", "@mashop",mashop, "@page_index", page_index, "@page_size", page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DonHangModel> GetDonHangByTrangThai(string mashop, int trangthai, int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdhbyshop", "@mashop", mashop, "@trangthai", trangthai, "@page_index", page_index, "@page_size", page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DonHangModel> GetDonHangByKhachHang(string makh, int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdhbykhachhang", "@makh", makh, "@page_index", page_index, "@page_size", page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonHangModel Getbyid(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdonhangbyid", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonHangModel Them(DonHangModel dh)
        {
            string msgError = "";
            try
            {
                
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "themdonhang",
                    "@MaKH",dh.MaKH,
                    "@MaShop",dh.MaShop,
                    "@ThanhToan",dh.ThanhToan,
                    "@MaDiaChi",dh.MaDiaChi,
                    "@chitiet",dh.chitiet != null ? MessageConvert.SerializeObject(dh.chitiet) : null,
                    "@TenKh",dh.TenKH,
                    "@Email",dh.Email, 
                    "@SoDienThoai",dh.SoDienThoai,
                     "@Xa",dh.Xa,
                     "@Huyen",dh.Huyen,
                     "@Tinh",dh.Tinh,
                     "@DCChiTiet",dh.DCChitiet
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietDonHangModel> getctbymadonhang(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getchitietdonhang", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChiTietDonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Provinces> getalltinh()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getallTinh");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Provinces>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonHangModel thaydoitrangthaidonhang(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "doittdonhang", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonHangModel huydon(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HuyDon", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Districts> gethuyenbytinh(int matinh) 
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gethuyenbytinh", "@matinh", matinh);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Districts>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Wards> getxabyhuyen(int mahuyen)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getxabyhuyen", "@mahuyen", mahuyen);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Wards>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
