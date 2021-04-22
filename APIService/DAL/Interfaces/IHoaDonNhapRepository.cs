using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IHoaDonNhapRepository
    {
        List<NhaCungCapModel> AllNCC();

        List<ChiTietHoaDonNhapModel> GetCtHDN(string mahdn);
        HoaDonNhapModel GetHDNbyID(string mahdn);
        List<HoaDonNhapModel> GetHDNbyShop(string mashop, int page_index, int page_size, out long total);
        
        NhaCungCapModel GetNCCByHDN(string mahdn);
       
        KhoModel TangSLSP(string masp, int soluong);
        HoaDonNhapModel Them(HoaDonNhapModel hdn);
    }
}
