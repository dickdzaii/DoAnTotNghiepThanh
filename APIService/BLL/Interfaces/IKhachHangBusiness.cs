using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IKhachHangBusiness
    {

        public List<KhachHangModel> GetKh(int index, int size, out long total);
        public KhachHangModel Cusbyid(string id);
        public List<DiaChiModel> GetAddress(string id);
        public List<KhachHangModel> KhwDiaChi(int index, int size, out long total);
        List<KhachHangModel> Getfulldetails(int index, int size, out long total);
        DiaChiModel ThemDiaChi(DiaChiModel dc);
        KhachHangModel DangNhap(string tk, string mk, string email);
        DiaChiModel GetDiaChiByID(int id);
        int xoaDiaChi(int madiachi);
        int ThietLapDiaChi(int madiachi);
    }
}
