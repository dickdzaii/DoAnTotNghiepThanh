using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IThongKeBusiness
    {
        ThongKeModel ThongkeNam(string mashop, int nam);
        ThongKeModel ThongkeThang(string mashop, int thang);
    }
}
