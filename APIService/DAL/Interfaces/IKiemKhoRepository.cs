using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IKiemKhoRepository
    {
        List<ChiTietKiemKhoModel> GetChiTietKiemKhos(string makiemkho);
        KiemKhoModel GetKiemKhoById(string makiemkho);
        List<KiemKhoModel> GetKiemKhos(string linkshop, int index, int size, out long total);
    }
}
