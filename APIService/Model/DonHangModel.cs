using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Model
{
    public class DonHangModel
    {
        public string MaDH { get; set; }
        public string MaKH { get; set; }
        public int? MaDiaChi { get; set; }
        public string MaShop { get; set; }
        public string NgayDat { get; set; }
        public int ThanhToan { get; set; }
        public int TrangThai { get; set; }
        public int TongDonVi { get; set; }
        public int Tonggiatri { get; set; }
        public List<ChiTietDonHangModel> chitiet { get; set; }
        public KhachHangModel thongtinkh { get; set; }
        public DiaChiModel diachinhanhang { get; set; }
        public string TenKH { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public int? Tinh { get; set; }
        public int ?Huyen { get; set; }
        public int ?Xa { get; set; }
        public string DCChitiet { get; set; }
    }
}
