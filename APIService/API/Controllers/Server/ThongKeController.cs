using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : ControllerBase
    {
        private IThongKeBusiness itk;

        public ThongKeController(IThongKeBusiness itk)
        {
            this.itk = itk;
        }
        [Route("thang/{mashop}/{thang}")]
        public ThongKeModel thongkethang(string mashop,int thang)
        {
            
            return itk.ThongkeThang(mashop, thang);
        }
        [Route("nam/{mashop}/{nam}")]
        public ThongKeModel thongkenam(string mashop, int nam)
        {

            return itk.ThongkeNam(mashop, nam);
        }
    }
}
