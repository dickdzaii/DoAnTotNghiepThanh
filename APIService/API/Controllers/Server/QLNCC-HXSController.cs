using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLNCC_HXSController : ControllerBase
    {
        private INhaCungCapBusiness incc;

        public QLNCC_HXSController(INhaCungCapBusiness incc)
        {
            this.incc = incc;
        }
        [Route("search/{index}/{size}/{tenncc}")]
        [HttpGet]
        public ResponseModel Search(int index,int size,string tenncc)
        {
         
            var response = new ResponseModel();
            long total = 0;
            response.Data = incc.SearchNCC(index,size,out total,tenncc);
            response.TotalItems = total;
            response.Page = index;
            response.PageSize = size;
            return response;
        }
        [Route("detail/{link}")]
        [HttpGet]
        public NhaCungCapModel GetDetail(string link)
        {
            return incc.GetNCCbyLink(link);
        }
    }
}
