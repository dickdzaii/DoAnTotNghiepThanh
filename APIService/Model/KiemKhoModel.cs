using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class KiemKhoModel
    {
        public string MaKiemKho{get;set;}
      public string MaShop{get;set;}
      public string ngaykiemkho{get;set;}
        public List<ChiTietKiemKhoModel> chitiet { get; set; }
    }
}
