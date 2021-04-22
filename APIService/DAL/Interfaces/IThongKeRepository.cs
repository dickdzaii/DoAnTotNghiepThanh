using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IThongKeRepository
    {
        void doanhthutheoloaitheonam(string mashop, int maloai, int nam, out int doanhthu, out int chiphi);
        void doanhthutheoloaitheothang(string mashop, int maloai, int thang, out int doanhthu,out int chiphi);
        List<DonHangModel> donhangtheonam(string mashop, int nam);
        List<DonHangModel> donhangtheothang(string mashop, int thang);
        List<HoaDonNhapModel> phieunhaptheonam(string mashop, int nam);
        List<HoaDonNhapModel> phieunhaptheothang(string mashop, int thang);
        List<SanPhamModel> Spbanchay(string mashop, int thang);
        List<SanPhamModel> Spbanchaytheonam(string mashop, int nam);
        List<SanPhamModel> Sphethang(string mashop);
        ThongKeModel TongQuanNam(string mashop, int nam);
        ThongKeModel TongQuanThang(string mashop, int thang);
    }
}
