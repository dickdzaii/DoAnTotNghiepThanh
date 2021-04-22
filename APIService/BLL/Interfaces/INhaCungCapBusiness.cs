using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface INhaCungCapBusiness
    {
        NhaCungCapModel GetNCCbyLink(string link);
        List<NhaCungCapModel> SearchNCC(int pageIndex, int pageSize, out long total, string tenNCC);
    }
}
