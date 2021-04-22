using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class LoaiCon1Model
    {
        
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public int MaLoaiCha { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
        public string Link { get; set; }
        public int? removed { get; set; }
        public int? displayed { get; set; }
        public List<LoaiCon2Model> children { get; set; }
    }
}
