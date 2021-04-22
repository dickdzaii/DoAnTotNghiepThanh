using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DiaChiModel
    {
        public int MaDiaChi {get;set;}
      public string MaKhachHang {get;set;}
      public int Xa {get;set;}
      public int Huyen {get;set;}
      public int Tinh {get;set;}
      public string ChiTiet {get;set;}
      public string SoDienThoai {get;set;}
      public int Removed {get;set;}
      public int Displayed {get;set;}
        public int main { get; set; }
        public Provinces tttinh { get; set; }
        public Districts tthuyen { get; set; }
        public Wards ttxa { get; set; }
    }
}
