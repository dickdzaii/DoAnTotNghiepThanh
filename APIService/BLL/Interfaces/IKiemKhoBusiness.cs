using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IKiemKhoBusiness
    {
        KiemKhoModel GetByID(string makiemkho);
        List<KiemKhoModel> GetKiemKhos(string linkshop, int index, int size, out long total);
    }
}
