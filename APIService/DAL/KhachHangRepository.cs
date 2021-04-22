using DAL.Helper;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class KhachHangRepository:IKhachHangRepository
    {
        private IDatabaseHelper _dbHelper;
        public KhachHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<KhachHangModel> GetKh(int index, int size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkh",
                    "@page_index", index,
                    "@page_size", size
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KhachHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public KhachHangModel getbyid(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkhid","@id",id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachHangModel>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public KhachHangModel DangNhap(string tendn, string mk,string email)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "dangnhap", "@TenTK", tendn,
                    "@Mk",mk, "@Email",email
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachHangModel>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DiaChiModel Getdcbyid(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdiachibyid", "@madc", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiaChiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DiaChiModel> GeDiachi(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdiachi", "@makh",id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiaChiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DiaChiModel GeDiachibyid(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdiachibyid", "@madc", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiaChiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public int xoaDiachi(int madiachi)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteScalarSProcedure(out msgError, "xoadiachi", "@madiachi", madiachi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ThietLapDiaChi(int madiachi)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteScalarSProcedure(out msgError, "thietlapdiachi", "@madiachi", madiachi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DiaChiModel themdiachi(DiaChiModel dc)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "themdiachi",
                   "@makh", dc.MaKhachHang,
                   "@xa",dc.Xa,
                   "@huyen",dc.Huyen,
                   "@tinh",dc.Tinh,
                   "@chitiet",dc.ChiTiet,
                   "@sdt",dc.SoDienThoai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DiaChiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TaiKhoanModel GetTaiKhoan(string makh)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gettaikhoanbykh", "@makh", makh);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Provinces GetTinh(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getProvinceById", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Provinces>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Districts GetHuyen(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getDistrictByID", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Districts>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Wards GetXa(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getWardByID", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Wards>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
