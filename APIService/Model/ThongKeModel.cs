using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class ThongKeModel
    {
        public int totalAmount { get; set; }
        public int totalReAmount { get; set; }
        public int totalValue { get; set; }
        public int totalReValue { get; set; }
        public int totalOrders { get; set; }
        public int totalOrdersReturns { get; set; }
        public int totalIR { get; set; }
        public List<SanPhamModel> spbanchay { get; set; }
        public List<SanPhamModel> sphethang { get; set; }
        public List<LoaiModel> incomebycates { get;set; }
        public List<DonHangModel>dsdh { get; set; }
        public List<HoaDonNhapModel>dshdn { get; set; }
    }
}
