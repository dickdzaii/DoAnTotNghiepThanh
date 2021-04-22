using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDonHangBusiness
    {
        List<DonHangModel> GetOdersByShop(string mashop, int pageIndex, int pageSize, out long total);
        List<Provinces> getalltinh();
        List<Districts> gethuyenbytinh(int matinh);
        List<Wards> getxabyhuyen(int mahuyen);
        DonHangModel huydon(string madon);
        DonHangModel doitrangthai(string madon);
        DonHangModel GetOdersById(string madon);
        List<DonHangModel> GetOdersByStatus(string mashop, int trangthai, int pageIndex, int pageSize, out long total);
        DonHangModel them(DonHangModel dh);
        List<DonHangModel> GetOdersByKH(string makh, int pageIndex, int pageSize, out long total);
    }
}
