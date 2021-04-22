using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ChiTietLuaChonModel
    {
        public string MaCT{get;set;}
      public string MaLuaChon{get;set;}
      public string MaSanPham{get;set;}
      public string GiaTri{get;set;}
        public LuaChonModel detail { get; set; }
    }
}
