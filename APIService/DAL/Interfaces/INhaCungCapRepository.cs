using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface INhaCungCapRepository
    {
        NhaCungCapModel GetByLink(string link);
        int GetValue(string link);
        List<NhaCungCapModel> SearchNCC(int page_index, int page_size, out long total, string tenncc);
    }
}
