using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class LoaiModel
    {
        public int MaLoai { get; set; }

        public string TenLoai { get; set; }

        public string MoTa { get; set; }

        public string GhiChu { get; set; }

        public string link { get; set; }

        public int? removed { get; set; }

        public int? displayed { get; set; }
        public string anh { get; set; }
        public List<LoaiCon1Model> children { get; set; }
        public int income { get; set; }
        public int chiphi { get; set; }

    }
}
