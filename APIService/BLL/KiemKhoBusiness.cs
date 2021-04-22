using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class KiemKhoBusiness:IKiemKhoBusiness
    {
        private IKiemKhoRepository _res;

        public KiemKhoBusiness(IKiemKhoRepository res)
        {
            _res = res;
        }
        public List<KiemKhoModel> GetKiemKhos(string linkshop,int index, int size, out long total)
        {
            var kq = _res.GetKiemKhos(linkshop,index,size, out total);
            foreach(var item in kq)
            {
                item.chitiet = _res.GetChiTietKiemKhos(item.MaKiemKho);
            }
            return kq;
        }
        public KiemKhoModel GetByID(string makiemkho)
        {
            var kq = _res.GetKiemKhoById(makiemkho);          
                kq.chitiet = _res.GetChiTietKiemKhos(kq.MaKiemKho);
            
            return kq;
        }
    }
}
