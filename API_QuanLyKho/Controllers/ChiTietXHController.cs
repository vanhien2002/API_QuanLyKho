using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietXHController : ControllerBase
    {
        private readonly IChiTietXHService chiTietXHService;
        public ChiTietXHController(IChiTietXHService chiTietXHService)
        {
            this.chiTietXHService = chiTietXHService;
        }
        [Route(WebEndpoint.ChiTietXH.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ChiTietXHModel> lst = chiTietXHService.getAll();
            if (lst != null)
            {
                return Ok(lst);
            }           
            return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietPhieuXuat.NOT_FOUND_ChiTietPhieuXuat);
        }
        [HttpGet]
        [Route(WebEndpoint.ChiTietXH.GET_BY_ID)]
        public IActionResult getById()
        {
            //get values id trong url
            string maphxh = RouteData.Values["maphxh"]?.ToString();
            if (String.IsNullOrEmpty(maphxh)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            List<ChiTietXHModel> lst = chiTietXHService.getByChiTietPhieuXuatId(maphxh);
            if (lst == null)
            {
                return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietPhieuXuat.NOT_FOUND_ChiTietPhieuXuat);
            }
            return Ok(lst);
        }
        [HttpGet]
        [Route(WebEndpoint.ChiTietXH.GET_ITEM_BY_ID)]
        public IActionResult getItemById()
        {
            string masp = RouteData.Values["masp"]?.ToString();
            string maphxh = RouteData.Values["maphxh"]?.ToString();
            if (String.IsNullOrEmpty(maphxh)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            if (String.IsNullOrEmpty(masp)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            ChiTietXHModel item = chiTietXHService.getChiTietPhieuXuatItem(maphxh, masp);
            if (item == null)
            {
                return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietPhieuXuat.NOT_FOUND_ChiTietPhieuXuat);
            }
            return Ok(item);
        }
        [HttpPost]
        [Route(WebEndpoint.ChiTietXH.ADD_ITEM)]
        public IActionResult Add(ChiTietXHModel item)
        {
            if(item == null)
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = chiTietXHService.addItem(item);
            if(kq == 1)
            {
                return Ok(ApplicationContants.ResponseCodeConstants.SUCCESS);
            }

            return BadRequest(ApplicationContants.ResponseCodeConstants.EXISTED) ;
        }
        [HttpDelete]
        [Route(WebEndpoint.ChiTietXH.REMOVE_ITEM)]
        public IActionResult RemoveByMaPhieu()
        {
            string maphxh = RouteData.Values["maphxh"].ToString();
            if (String.IsNullOrEmpty(maphxh)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = chiTietXHService.remove(maphxh);
            if(kq == 0)
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }            
            return Ok(ApplicationContants.ReponseMessageConstantsChiTietPhieuXuat.DELETE_ChiTietPhieuXuat_SUCCESS);
        }
        [HttpPut]
        [Route(WebEndpoint.ChiTietXH.UPDATE_ITEM)]
        public IActionResult Update(ChiTietXHModel model)
        {
            if(model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = chiTietXHService.update(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }

            return Ok(ApplicationContants.ReponseMessageConstantsChiTietPhieuXuat.UPDATE_ChiTietPhieuXuat_SUCCESS) ;
        }

    }
}
