using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class ShopModel
    {
        public string MaShop {get;set;}
      public string TenShop {get;set;}
      public DateTime NgayDK {get;set;}
      public string MaKH {get;set;}
      public string MoTa {get;set;}
      public string GhiChu {get;set;}
      public string Link {get;set;}
      public int Removed {get;set;}
        
      public int Displayed {get;set;} 
        public List<SanPhamModel> dssp { get; set; }
    }
}
