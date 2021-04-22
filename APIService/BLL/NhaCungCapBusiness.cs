using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class NhaCungCapBusiness:INhaCungCapBusiness
    {
        private INhaCungCapRepository _res;
        public NhaCungCapBusiness(INhaCungCapRepository ItemGroupRes)
        {
            _res = ItemGroupRes;

        }
        public List<NhaCungCapModel> SearchNCC(int pageIndex,int pageSize,out long total, string tenNCC)
        {
            var kq= _res.SearchNCC(pageIndex, pageSize, out total, tenNCC);
            foreach(var item in kq)
            {
                item.value = _res.GetValue(item.Link);
            }
            return kq;
        }
        public NhaCungCapModel GetNCCbyLink(string link)
        {
            var kq= _res.GetByLink(link);
            kq.value = _res.GetValue(link);
            return kq;
        }
    }
}
