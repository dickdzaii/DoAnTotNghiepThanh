using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLNhapHangController : ControllerBase
    {
        private IHoaDonNhapBusiness ihdn;

        public QLNhapHangController(IHoaDonNhapBusiness ihdn)
        {
            this.ihdn = ihdn;
        }
        [Route("all-by-shop/{mashop}/{page_index}/{page_size}")]
        public ResponseModel GetHDNbyShop(string mashop, int page_index, int page_size)
        {
            long total = 0;
            var kq = new ResponseModel();
            kq.Data = ihdn.GetHDNbyShop( mashop,  page_index,  page_size, out  total);
            kq.TotalItems = total;
            kq.Page = page_index;
            kq.PageSize = page_size;
            return kq;
        }
        [Route("by-id/{mahdn}")]
        public HoaDonNhapModel getbyid(string mahdn)
        {
            return ihdn.GetHDNbyID(mahdn);
        }
        [Route("ct/{mahdn}")]
        public List<ChiTietHoaDonNhapModel> getbyhdn(string mahdn)
        {
            return ihdn.getbyhdn(mahdn);
        }
        [Route("them")]
        [HttpPost]
        public HoaDonNhapModel them([FromBody] HoaDonNhapModel hdn)
        {
            var kq = ihdn.Them(hdn);
            
            return kq;
        }
        [Route("get-all-ncc")]
        
        public List<NhaCungCapModel> GetAllNCC()
        {
            return ihdn.GetAllNCC();
        }

    }
}
