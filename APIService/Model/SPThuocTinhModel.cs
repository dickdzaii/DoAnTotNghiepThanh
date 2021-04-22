using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SPThuocTinhModel
    {
        public int MaThuocTinh {get;set;}
      public string MaSanPham {get;set;}
      public string GiaTri {get;set;}
        public ThuocTinhModel detail { get; set; }
    }
}
