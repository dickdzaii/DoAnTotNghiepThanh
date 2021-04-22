using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Model;

namespace DAL
{
    public partial class SanPhamRepository:ISanPhamRepository
    {
        private IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<SanPhamModel> GetSanPhams(int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getsp", "@page_index",page_index,"@page_size",page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> Getspbyshop(string mashop, int pageIndex, int pageSize, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getspbyshop", "@linkshop",mashop, "@page_index", pageIndex, "@page_size", pageSize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SanPhamModel GetSPbyID( string link)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getspbylink","@id",link);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<KhoModel> GetKho()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkho");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GiaBanModel> GetGiaBans(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getgiabanbysp", "@masp",masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiaBanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GiaBanModel Getgiahientai(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getgiahientai","@masp",masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiaBanModel>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public KhoModel Getkhobysp(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkhobysp", "@masp", masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhoModel>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> allwithpagedlist(int pageIndex, int pageSize, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "phantrang",
                    "@page_index",pageIndex, "@page_size",pageSize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> TimkiemTheoShop(int maloai, string maloai1, string maloai2,
            string keyword,int min,int max,int pageIndex,int pageSize,out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "timkiemtheoshop",
                    "@maloai",maloai,"@maloai1",maloai1,"@maloai2",maloai2,
                    "@keyword",keyword,"@min",min,"@max",max,
                    "@page_index", pageIndex, "@page_size", pageSize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> GetByLoai2(int pageIndex, int pageSize, string link, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getsploai2",
                    "@page_index", pageIndex, "@page_size", pageSize, "@loai2", link);
                
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LoaiModel getloaibySanPham(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getloaibysp", "@masp", masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiModel>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LoaiCon1Model getloai1bySanPham(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getloai1bysp", "@masp", masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiCon1Model>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LoaiCon2Model getloai2bySanPham(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getloai2bysp", "@masp", masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiCon2Model>().ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> SPtheoKhoangGia(int min, int max)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "giabantheokhoang", "@min", min,"@max",max);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> GetCungLoai(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sptuongtu", "@masp", masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<SanPhamModel> Getspbyloai1(int index, int size, out long total, string loai1)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getspbyloai1", "@page_index", index, "@page_size", size, "@loai1", loai1);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<SanPhamModel> Getspbyloai(int pageIndex, int pageSize, string link, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getspbyloai",
                    "@page_index", pageIndex, "@page_size", pageSize, "@loai", link);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> Getspbyshop(int pageIndex, int pageSize, string link, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getsanphambyshop",
                    "@page_index", pageIndex, "@page_size", pageSize,"@link",link);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> timkiemtheodanhmuc(int ma,string keyword,int index, int size,out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Timkemtheodanhmuc",
                    "@maloai",ma, "@keyword",keyword,
                    "@page_index", index, "@page_size", size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SanPhamModel Create(SanPhamModel spmoi)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "themsp",
                          "@MaLoai2", spmoi.MaLoai2,
                          "@TenSanPham", spmoi.TenSanPham,
                            "@MoTa", spmoi.MoTa,
                            "@GhiChu", spmoi.GhiChu,
                            "@Link", spmoi.Link,
                            "@anh",spmoi.Anh,
                             "@mashop",spmoi.kho.MaShop,
                                "@soluong", spmoi.kho.SoLuong,
                                "@gianhap", spmoi.kho.GiaNhap,
                                    "@giaban", spmoi.giahientai.Gia);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GiaBanModel Addprice(GiaBanModel gb)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "themgiaban",
                          "@MaSanPham", gb.MaSanPham,
                         "@Gia", gb.Gia);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiaBanModel>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<KhoModel> AddKho(KhoModel kho)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "themkho",
                          "@MaSanPham", kho.MaSanPham,
                          "@MaShop",kho.MaShop,"@SoLuong",kho.SoLuong,
                         "@GiaNhap", kho.GiaNhap);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhoModel>().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update() { 

        }
        public int getRevenue(string magb)
        {
            int kq = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getRevenueByPrice",
                          "@magb", magb);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0 && dt.Rows[0]["Revenue"] != DBNull.Value) kq = (int)dt.Rows[0]["Revenue"];
                return kq;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteScalarSProcedure(out msgError, "xoasp", "@masp", masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return Convert.ToInt32(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietLuaChonModel> getluachonbysp(string masp)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getluachonbysp", "@masp", masp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChiTietLuaChonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
