using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
   public interface IKhachHangRepository
    {
        List<KhachHangModel> GetKh(int index, int size, out long total);
        KhachHangModel getbyid(string id);
        List<DiaChiModel> GeDiachi(string id);
        TaiKhoanModel GetTaiKhoan(string makh);
        Provinces GetTinh(int id);
        Districts GetHuyen(int id);
        Wards GetXa(int id);
        DiaChiModel themdiachi(DiaChiModel dc);
        DiaChiModel Getdcbyid(int id);
        KhachHangModel DangNhap(string tendn, string mk, string email);
        DiaChiModel GeDiachibyid(int id);
        int xoaDiachi(int madiachi);
        int ThietLapDiaChi(int madiachi);
    }
}
