using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL.Interfaces;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLKiemKhoController : ControllerBase
    {
        private IKiemKhoBusiness _res;

        public QLKiemKhoController(IKiemKhoBusiness res)
        {
            _res = res;
        }
        [Route("all-by-shop/{link}/{index}/{size}")]
        [HttpGet]
        public ResponseModel GetKiemKhos(string link, int index, int size)
        {
            var response = new ResponseModel();
            long total = 0;
            response.Page = index;
            response.PageSize = size;
            response.Data = _res.GetKiemKhos(link, index, size, out total);
            response.TotalItems = total;
            return response;
        }
        [Route("detail/{makiemkho}")]
        [HttpGet]
        public KiemKhoModel GetByID(string makiemkho)
        {
            return _res.GetByID(makiemkho);
        }
    }
}
