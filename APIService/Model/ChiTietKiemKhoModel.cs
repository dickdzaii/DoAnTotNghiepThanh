using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ChiTietKiemKhoModel
    {
        public string MaCT { get; set; }
        public string MaKiemKho { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Anh { get; set; }
        public string Link { get; set; }
        public int SoLuongDB { get; set; }
        public int SoLuongTT { get; set; }
        public string NguyenNhanTD { get; set; }
        public int DonGia { get; set; }
    }
}
