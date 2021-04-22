using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ISanPhamBusiness
    {
        List<SanPhamModel> all(int pageIndex, int pageSize, out long total);
        SanPhamModel Chitietsanpham(string link);
        List<SanPhamModel> getspbyshop(string mashop, int pageIndex, int pageSize, out long total);
        List<SanPhamModel> xemlichsugia(int pageIndex, int pageSize, out long total);
        List<SanPhamModel> getspwithfulldetail(int pageIndex, int pageSize, out long total);
        List<SanPhamModel> phantrang(int index, int size, out long total);
        List<SanPhamModel> SanphamtheoLoaiCon2(int pageIndex, int pageSize, string link, out long total);
        List<SanPhamModel> SPtheoKhoangGia(int min, int max);
        List<SanPhamModel> SPtuongtu(string maloai);
        
        List<SanPhamModel> spbyloai(int pageIndex, int pageSize, string link, out long total);
        List<SanPhamModel> Getspbyshop(int index, int size, string link, out long total);
        SanPhamModel Create(SanPhamModel spmoi);
        int delete(string masp);
        GiaBanModel ThemGiaBan(GiaBanModel gb);
        List<KhoModel> ThemKho(KhoModel kho);
        List<SanPhamModel> getspbanchay(string mashop, int thang);
        List<SanPhamModel> timkiemtheodanhmuc(int maloai, string keyword, int index, int size, out long total);
        List<SanPhamModel> spbyloai1(int pageIndex, int pageSize, string link, out long total);
        List<SanPhamModel> TimkiemTheoShop(int maloai, string maloai1, string maloai2, string keyword, int min, int max, int pageIndex, int pageSize, out long total);
    }
}
