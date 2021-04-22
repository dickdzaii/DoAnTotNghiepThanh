using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class KhachHangModel
    {
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Anh { get; set; }
        public string GhiChu { get; set; }
        public string Link { get; set; }
        public int? Removed { get; set; }
        public int? Displayed { get; set; }
        public TaiKhoanModel tk {get; set; }
            public List<DiaChiModel> dsdiachi { get; set; }
    }
}
