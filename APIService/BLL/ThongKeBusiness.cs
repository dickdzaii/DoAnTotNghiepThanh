using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ThongKeBusiness:IThongKeBusiness
    {
        private ILoaiRepository l;
        private ISanPhamRepository sp;
        private IThongKeRepository tk;
        private IDonHangRepository dh;
        private IHoaDonNhapRepository hdn;
        private IKhachHangRepository kh;
        

        public ThongKeBusiness(ILoaiRepository l, ISanPhamRepository sp, IThongKeRepository tk,IDonHangRepository dh, IHoaDonNhapRepository hdn, IKhachHangRepository kh)
        {
            this.l = l;
            this.sp = sp;
            this.tk = tk;
            this.dh = dh;
            this.hdn = hdn;
            this.kh = kh;
        }
        public ThongKeModel ThongkeThang(string mashop,int thang)
        {int doanhthutheoloai = 0; int chiphitheoloai = 0;
            var kq = new ThongKeModel();
            kq = tk.TongQuanThang(mashop,thang);
            kq.incomebycates = l.GetDataAll();
            kq.sphethang = tk.Sphethang(mashop);
            kq.spbanchay = tk.Spbanchay(mashop, thang);
            kq.dsdh = tk.donhangtheothang(mashop,thang);
            kq.dshdn = tk.phieunhaptheothang(mashop, thang);
            foreach(var item in kq.spbanchay)
            {
                item.dsgiaban = sp.GetGiaBans(item.MaSanPham);
                item.giahientai = sp.Getgiahientai(item.MaSanPham);
                item.kho = sp.Getkhobysp(item.MaSanPham);
                item.danhmuc = sp.getloaibySanPham(item.MaSanPham);
                item.loaicon1 = sp.getloai1bySanPham(item.MaSanPham);
                item.loaicon2 = sp.getloai2bySanPham(item.MaSanPham);
            }
            foreach (var item in kq.sphethang)
            {
                item.dsgiaban = sp.GetGiaBans(item.MaSanPham);
                item.giahientai = sp.Getgiahientai(item.MaSanPham);
                item.kho = sp.Getkhobysp(item.MaSanPham);
                item.danhmuc = sp.getloaibySanPham(item.MaSanPham);
                item.loaicon1 = sp.getloai1bySanPham(item.MaSanPham);
                item.loaicon2 = sp.getloai2bySanPham(item.MaSanPham);
            }
            foreach(var item in kq.dsdh)
            {
                item.Tonggiatri = 0;
                item.TongDonVi = 0;
                item.chitiet = dh.getctbymadonhang(item.MaDH);
                {
                    for (int i = 0; i < item.chitiet.Count; i++)
                    {
                        item.Tonggiatri += item.chitiet[i].DonGia * item.chitiet[i].SoLuong;
                        item.TongDonVi += item.chitiet[i].SoLuong;
                    }
                }
                if (item.MaKH != null)
                {
                    item.thongtinkh = kh.getbyid(item.MaKH);
                }
                else
                {
                    item.thongtinkh = new KhachHangModel();
                    item.thongtinkh.tk = new TaiKhoanModel();
                    item.thongtinkh.HoTen = item.TenKH;
                    item.thongtinkh.tk.Email = item.Email;
                }
                if (item.MaDiaChi != null)
                {
                    item.diachinhanhang = kh.Getdcbyid(item.MaDiaChi.Value);
                    item.diachinhanhang.tttinh = kh.GetTinh(item.diachinhanhang.Tinh);
                    item.diachinhanhang.tthuyen = kh.GetHuyen(item.diachinhanhang.Huyen);
                    item.diachinhanhang.ttxa = kh.GetXa(item.diachinhanhang.Xa);
                }
                else
                {
                    item.diachinhanhang = new DiaChiModel();
                    item.diachinhanhang.tttinh = kh.GetTinh(item.Tinh.Value);
                    item.diachinhanhang.tttinh = kh.GetTinh(item.Tinh.Value);
                    item.diachinhanhang.ttxa = kh.GetXa(item.Xa.Value);
                    item.diachinhanhang.tthuyen = kh.GetHuyen(item.Huyen.Value);
                    item.diachinhanhang.ChiTiet = item.DCChitiet;
                    item.diachinhanhang.SoDienThoai = item.SoDienThoai;
                }
            }
            foreach(var item in kq.dshdn)
            {
                item.Tongdonvi=0;
                item.Tongchiphi=0;
                item.chitiet = hdn.GetCtHDN(item.MaHDN);
                      for (int i = 0; i < item.chitiet.Count; i++)
                {
                    item.Tongdonvi += item.chitiet[i].Soluong;
                    item.Tongchiphi += item.chitiet[i].Soluong * item.chitiet[i].DonGia;
                }
            }
            foreach (var i in kq.incomebycates)
            {
                
                tk.doanhthutheoloaitheothang(mashop, i.MaLoai, thang, out doanhthutheoloai,out chiphitheoloai);
                i.income = doanhthutheoloai;
                i.chiphi = chiphitheoloai;
            }
            return kq;
        }
        public ThongKeModel ThongkeNam(string mashop, int nam)
        {
            int doanhthutheoloai = 0; int chiphitheoloai = 0;
            var kq = new ThongKeModel();
            kq = tk.TongQuanNam(mashop, nam);
            kq.incomebycates = l.GetDataAll();
            kq.sphethang = tk.Sphethang(mashop);
            kq.spbanchay = tk.Spbanchaytheonam(mashop, nam);
            kq.dsdh = tk.donhangtheonam(mashop, nam);
            kq.dshdn = tk.phieunhaptheonam(mashop, nam);
            foreach (var item in kq.spbanchay)
            {
                item.dsgiaban = sp.GetGiaBans(item.MaSanPham);
                item.giahientai = sp.Getgiahientai(item.MaSanPham);
                item.kho = sp.Getkhobysp(item.MaSanPham);
                item.danhmuc = sp.getloaibySanPham(item.MaSanPham);
                item.loaicon1 = sp.getloai1bySanPham(item.MaSanPham);
                item.loaicon2 = sp.getloai2bySanPham(item.MaSanPham);
            }
            foreach (var item in kq.sphethang)
            {
                item.dsgiaban = sp.GetGiaBans(item.MaSanPham);
                item.giahientai = sp.Getgiahientai(item.MaSanPham);
                item.kho = sp.Getkhobysp(item.MaSanPham);
                item.danhmuc = sp.getloaibySanPham(item.MaSanPham);
                item.loaicon1 = sp.getloai1bySanPham(item.MaSanPham);
                item.loaicon2 = sp.getloai2bySanPham(item.MaSanPham);
            }
            foreach (var item in kq.dsdh)
            {
                item.Tonggiatri = 0;
                item.TongDonVi = 0;
                item.chitiet = dh.getctbymadonhang(item.MaDH);
                {
                    for (int i = 0; i < item.chitiet.Count; i++)
                    {
                        item.Tonggiatri += item.chitiet[i].DonGia * item.chitiet[i].SoLuong;
                        item.TongDonVi += item.chitiet[i].SoLuong;
                    }
                }
                if (item.MaKH != null)
                {
                    item.thongtinkh = kh.getbyid(item.MaKH);
                }
                else
                {
                    item.thongtinkh = new KhachHangModel();
                    item.thongtinkh.tk = new TaiKhoanModel();
                    item.thongtinkh.HoTen = item.TenKH;
                    item.thongtinkh.tk.Email = item.Email;
                }
                if (item.MaDiaChi != null)
                {
                    item.diachinhanhang = kh.Getdcbyid(item.MaDiaChi.Value);
                    item.diachinhanhang.tttinh = kh.GetTinh(item.diachinhanhang.Tinh);
                    item.diachinhanhang.tthuyen = kh.GetHuyen(item.diachinhanhang.Huyen);
                    item.diachinhanhang.ttxa = kh.GetXa(item.diachinhanhang.Xa);
                }
                else
                {
                    item.diachinhanhang = new DiaChiModel();
                    item.diachinhanhang.tttinh = kh.GetTinh(item.Tinh.Value);
                    item.diachinhanhang.tttinh = kh.GetTinh(item.Tinh.Value);
                    item.diachinhanhang.ttxa = kh.GetXa(item.Xa.Value);
                    item.diachinhanhang.tthuyen = kh.GetHuyen(item.Huyen.Value);
                    item.diachinhanhang.ChiTiet = item.DCChitiet;
                    item.diachinhanhang.SoDienThoai = item.SoDienThoai;
                }
            }
            foreach (var item in kq.dshdn)
            {
                item.Tongdonvi = 0;
                item.Tongchiphi = 0;
                item.chitiet = hdn.GetCtHDN(item.MaHDN);
                for (int i = 0; i < item.chitiet.Count; i++)
                {
                    item.Tongdonvi += item.chitiet[i].Soluong;
                    item.Tongchiphi += item.chitiet[i].Soluong * item.chitiet[i].DonGia;
                }
            }
            foreach (var i in kq.incomebycates)
            {

                tk.doanhthutheoloaitheonam(mashop, i.MaLoai, nam, out doanhthutheoloai, out chiphitheoloai);
                i.income = doanhthutheoloai;
                i.chiphi = chiphitheoloai;
            }
            return kq;
        }
    }
}
