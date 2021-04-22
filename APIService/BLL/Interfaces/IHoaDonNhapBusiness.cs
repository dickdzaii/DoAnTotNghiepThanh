using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IHoaDonNhapBusiness
    {
        List<NhaCungCapModel> GetAllNCC();
        List<ChiTietHoaDonNhapModel> getbyhdn(string mahdn);
        HoaDonNhapModel GetHDNbyID(string mahdn);
        List<HoaDonNhapModel> GetHDNbyShop(string mashop, int page_index, int page_size, out long total);
       
        HoaDonNhapModel Them(HoaDonNhapModel hdn);
    }
}
