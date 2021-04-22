using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class KhachHangBusiness:IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        public KhachHangBusiness(IKhachHangRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<KhachHangModel> GetKh(int index, int size, out long total)
        {
            return _res.GetKh(index,size,out total);
        }
        public KhachHangModel DangNhap(string tk,string mk,string email)
        {
            var kh = _res.DangNhap(tk, mk, email);
            if (kh!=null) {
            kh.dsdiachi = _res.GeDiachi(kh.MaKhachHang);
            foreach (var dc in kh.dsdiachi)
            {
                dc.tttinh = _res.GetTinh(dc.Tinh);
                dc.tthuyen = _res.GetHuyen(dc.Huyen);
                dc.ttxa = _res.GetXa(dc.Xa);
            }
            kh.tk = _res.GetTaiKhoan(kh.MaKhachHang); }
            return kh;
        }
        public List<KhachHangModel> KhwDiaChi(int index, int size, out long total)
        {
            var kh = _res.GetKh(index, size, out total);
            foreach(var item in kh)
            {
                item.dsdiachi = _res.GeDiachi(item.MaKhachHang);
                foreach (var dc in item.dsdiachi)
                {
                    dc.tttinh = _res.GetTinh(dc.Tinh);
                    dc.tthuyen = _res.GetHuyen(dc.Huyen);
                    dc.ttxa = _res.GetXa(dc.Xa);
                }
            }
            return kh;
        }
        public KhachHangModel Cusbyid(string id)
        {
            var kh = _res.getbyid(id);
            kh.dsdiachi = _res.GeDiachi(id);
            foreach (var dc in kh.dsdiachi)
            {
                dc.tttinh = _res.GetTinh(dc.Tinh);
                dc.tthuyen = _res.GetHuyen(dc.Huyen);
                dc.ttxa = _res.GetXa(dc.Xa);
            }
            kh.tk = _res.GetTaiKhoan(kh.MaKhachHang);
            return kh;
        }
        public List<DiaChiModel> GetAddress(string id)
        {
            var kq= _res.GeDiachi(id);
            foreach (var dc in kq)
            {
                dc.tttinh = _res.GetTinh(dc.Tinh);
                dc.tthuyen = _res.GetHuyen(dc.Huyen);
                dc.ttxa = _res.GetXa(dc.Xa);
            }
            return kq;
        }
        public DiaChiModel GetDiaChiByID(int id)
        {
            var dc = _res.Getdcbyid(id);
            dc.tttinh = _res.GetTinh(dc.Tinh);
            dc.tthuyen = _res.GetHuyen(dc.Huyen);
            dc.ttxa = _res.GetXa(dc.Xa);
            return dc;
        }
        public List<KhachHangModel> Getfulldetails(int index, int size, out long total)
        {
            var kh = _res.GetKh( index,  size, out  total);
            foreach (var item in kh)
            {
                item.dsdiachi = _res.GeDiachi(item.MaKhachHang);
                foreach(var dc in item.dsdiachi)
                {
                    dc.tttinh = _res.GetTinh(dc.Tinh);
                    dc.tthuyen = _res.GetHuyen(dc.Huyen);
                    dc.ttxa = _res.GetXa(dc.Xa);
                }
                item.tk = _res.GetTaiKhoan(item.MaKhachHang);
            }
            return kh;
        }
        public DiaChiModel ThemDiaChi(DiaChiModel dc)
        {
            return _res.themdiachi(dc);
        }
        public int xoaDiaChi(int madiachi)
        {
            return _res.xoaDiachi(madiachi);
        }
        public int ThietLapDiaChi(int madiachi)
        {
            return _res.ThietLapDiaChi(madiachi);
        }
    }
}
