using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class LoaiCon2Model
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MaLoaiCha { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
        public string Link { get; set; }
        public int? Removed { get; set; }
        public int? Displayed { get; set; }
        public List<SanPhamModel> sptheoloai { get; set; }
    }
}
