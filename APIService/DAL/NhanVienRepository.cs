using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface NhanVienRepository:INhanVienRepository
    {
        public List<NhanVienModel> GetDonHang()
        {
            return null;
        }
    }
}
