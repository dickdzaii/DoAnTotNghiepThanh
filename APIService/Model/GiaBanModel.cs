using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class GiaBanModel
    {
        public string MaGB {get;set;}
      public string MaSanPham {get;set;}
      public string MaShop {get;set;}
      public int Gia {get;set;}
      public DateTime? NgayBD {get;set;}
      public DateTime? NgayKT {get;set;}
        public int revenue { get; set; }
    }
}
