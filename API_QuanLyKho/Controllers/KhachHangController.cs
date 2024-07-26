using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService khachHangService;
        public KhachHangController(IKhachHangService khachHangService) {
            this.khachHangService = khachHangService;
        }       
        [Route(WebEndpoint.KhachHang.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<KhachHangModel> lst = khachHangService.getAllKhachHang();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhachHang.NOT_FOUND_KhachHang); }
            return Ok(lst);
        }
        [Route(WebEndpoint.KhachHang.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string maph = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(maph)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            KhachHangModel model = khachHangService.getKhachHangById(maph);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhachHang.NOT_FOUND_KhachHang); }
            return Ok(model);
        }
        [Route(WebEndpoint.KhachHang.GET_BY_SDT)]
        [HttpGet]
        public IActionResult GetKHBySDT()
        {
            string maph = RouteData.Values["sdt"].ToString();
            if (String.IsNullOrEmpty(maph)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            KhachHangModel model = khachHangService.getKhachHangBySDT(maph);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhachHang.NOT_FOUND_KhachHang); }
            return Ok(model);
        }
        [Route(WebEndpoint.KhachHang.GET_BY_SDT_FAX)]
        [HttpGet]
        public IActionResult GetKHBySDT_FAX()
        {
            string sdt = RouteData.Values["sdt"].ToString();
            string fax = RouteData.Values["fax"].ToString();
            if (String.IsNullOrEmpty(sdt) && String.IsNullOrEmpty(fax)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            KhachHangModel model = khachHangService.getTK_KH_BySDT_FAX(sdt, fax);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhachHang.NOT_FOUND_KhachHang); }
            return Ok(model);
        }
        [Route(WebEndpoint.KhachHang.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddKhachHang(KhachHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = khachHangService.AddKhachHang(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhachHang.EXISTED_KhachHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsKhachHang.UPDATE_KhachHang_SUCCESS);

        }
        [Route(WebEndpoint.KhachHang.REMOVE_BY_MAKHACHHANG)]
        [HttpDelete]
        public IActionResult RemoveKhachHang()
        {
            string maph = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(maph))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = khachHangService.RemovekhachHang(maph);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhachHang.NOT_FOUND_KhachHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsKhachHang.DELETE_KhachHang_SUCCESS);
        }      
        [Route(WebEndpoint.KhachHang.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateKhachHang(KhachHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = khachHangService.UpdatekhachHang(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsKhachHang.UPDATE_KhachHang_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsKhachHang.NOT_FOUND_KhachHang);
        }
    }
}
