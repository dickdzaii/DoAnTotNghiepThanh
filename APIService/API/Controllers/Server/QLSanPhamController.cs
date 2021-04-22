using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLSanPhamController : ControllerBase
    {
        private ISanPhamBusiness isp;
        private string _path;
        public QLSanPhamController(ISanPhamBusiness isp, IConfiguration configuration)
        {
            this.isp = isp;
            _path = configuration["AppSettings:PATH"];
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        [Route("all")]
        public IEnumerable<SanPhamModel> Getall(int pageIndex, int pageSize, out long total)
        {
            return isp.all( pageIndex,  pageSize, out  total);
        }
        [Route("tim-kiem/{maloai}/{maloai1}/{maloai2}/{keyword}/{min}/{max}/{pageIndex}/{pageSize}")]
        [HttpGet]
        public ResponseModel TimkiemTheoShop(int maloai, string maloai1, string maloai2,
   string keyword, int min, int max, int pageIndex, int pageSize )
        {
            var response = new ResponseModel();
            long total = 0;
            response.Page = pageIndex;
            response.PageSize = pageSize;
            response.Data = isp.TimkiemTheoShop(maloai,maloai1,maloai2,keyword,min,max,pageIndex,pageSize,out total);
            response.TotalItems = total;
            return response;

        }
        [Route("tim-kiem-theo-danh-muc/{madanhmuc}/{keyword}/{index}/{size}")]
        public ResponseModel timkiemtheodanhmuc(int madanhmuc, string keyword,int index,int size)
        {
       
            var response = new ResponseModel();
            long total = 0;
            response.Page = index;
            response.PageSize = size;
            response.Data = isp.timkiemtheodanhmuc(madanhmuc, keyword, index, size,out  total);
            response.TotalItems = total;
            return response;

        }

        [Route("ban-chay/{mashop}/{thang}")]
        public IEnumerable<SanPhamModel> GetBanChay(string mashop, int thang)
        {
            return isp.getspbanchay(mashop,thang);
        }
        [Route("detail/{link}")]
        public SanPhamModel Chitietsanpham(string link)
        {
            
            return isp.Chitietsanpham(link); ;
        }
        [Route("all-by-shop/{link}/{pageIndex}/{pageSize}")]
        public ResponseModel getspbyshop(string link,int pageIndex, int pageSize)
        {
            long total;
            var response = new ResponseModel();
            response.Page = pageIndex;
            response.PageSize = pageSize;
            response.Data= isp.getspbyshop(link,pageIndex,pageSize,out total);
            response.TotalItems = total;
            return response;
        }
        [Route("all-with-details/{pageIndex}/{pageSize}")]
        public List<SanPhamModel> getfulldetails(int pageIndex, int pageSize)
        {
            long total =0;
            var kq= isp.getspwithfulldetail( pageIndex,  pageSize, out  total);
            foreach (var item in kq) item.Total = total;
            return kq;
        }

        [Route("all-pagedlist")]
        public ResponseModel Phantrang([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                long total = 0;
                var data = isp.phantrang(page, pageSize, out total);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        [Route("all-in-loai-2/{pageIndex}/{pageSize}/{link}")]
        public IEnumerable<SanPhamModel> SanPhamtheoloaicon2(int pageIndex,int pageSize,string link)
        {
            long total = 0;
            var kq= isp.SanphamtheoLoaiCon2(pageIndex,pageSize,link,out total);
            foreach(var item in kq)
            {
                item.Total = total;
            }
            return kq;
        }
        [Route("{min}/{max}")]
        public IEnumerable<SanPhamModel> SanPhamtheoKhoangGia(int min, int max) {
            return isp.SPtheoKhoangGia(min, max);
        }
        [Route("tuong-tu/{id}")]
        public IEnumerable<SanPhamModel> TuongTu(string id)
        {
            return isp.SPtuongtu(id);
        }
        [Route("all-in-loai-1/{pageIndex}/{pageSize}/{link}")]
        public ResponseModel GetByloai1(int pageIndex,int pageSize, string link)
        {
            var response = new ResponseModel();
            long total = 0;
            response.Page = pageIndex;
            response.PageSize = pageSize;
            response.Data =isp.spbyloai1(pageIndex,pageSize,link,out total);
            response.TotalItems = total;
            return response;
        }
        [Route("all-in-loai/{pageIndex}/{pageSize}/{link}")]
        public ResponseModel GetByloai(int pageIndex,int pageSize, string link)
        {
            var response = new ResponseModel();
            long total = 0;
            response.Page = pageIndex;
            response.PageSize = pageSize;
            response.Data = isp.spbyloai(pageIndex, pageSize, link, out total);
            response.TotalItems = total;
            return response;
        }
        [Route("get-by-shop/{index}/{size}/{link}")]
        public IEnumerable<SanPhamModel> getspbyshop(int? index, int? size, string link)
        {
            long total=9;
            index = (index < 1 || index == null) ? 1 : index;
            size = (index < 1 || index == null) ? 10 : size;
            return isp.Getspbyshop(index.Value, size.Value, link, out total);
        }
        [Route("them")]
        [HttpPost]
        public SanPhamModel create(SanPhamModel spmoi)
        {
          
            var newpro = isp.Create(spmoi);

            return newpro;

        }
        [Route("add-price")]
        [HttpPost]
        public GiaBanModel Themgia([FromBody] GiaBanModel giaBan)
        {
            var kq=isp.ThemGiaBan(giaBan);
            return kq;
        }
        [Route("update")]
        [HttpPut]
        public void sua(string masp)
        {

        }
        [Route("xoa/{id}")]
        [HttpGet]
        public int delete(string id)
        {
            return isp.delete(id);
        }
    }
}
