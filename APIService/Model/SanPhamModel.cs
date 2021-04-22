using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SanPhamModel
    {
        public string MaSanPham {get;set;}
      public string MaLoai2 {get;set;}
      public string TenSanPham {get;set;}
      public string MoTa {get;set;}
      public string GhiChu {get;set;}
      public string Link {get;set;}
      public string Removed {get;set;}
      public string Displayed {get;set;}
      
        public string Anh { get; set; }
        public string ThongTin { get; set; }
        public KhoModel kho { get; set; }
        public List<GiaBanModel> dsgiaban { get; set; }
        public LoaiModel danhmuc { get; set; }
        public LoaiCon1Model loaicon1 { get; set; }
        public LoaiCon2Model loaicon2 { get; set; }
        public GiaBanModel giahientai { get; set; }
        public long? Total { get; set; }
        public List<SPThuocTinhModel> dsthuoctinh { get; set; }
        public List<ChiTietLuaChonModel> dsluachon { get; set; }
        public int doanhthu { get; set; }
        public int donvi { get; set; }
    }
} 
