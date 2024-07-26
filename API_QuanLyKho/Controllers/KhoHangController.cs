using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoHangController : ControllerBase
    {
        private readonly IKhoHangService khoHangService;
        public KhoHangController(IKhoHangService khoHangService)
        {
            this.khoHangService = khoHangService;
        }
        [Route(WebEndpoint.KhoHang.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<KhoHangModel> lst = khoHangService.getAllKhoHang();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhoHang.NOT_FOUND_KhoHang); }
            return Ok(lst);
        }
        [Route(WebEndpoint.KhoHang.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string makho = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(makho)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            KhoHangModel model = khoHangService.getKhoHangById(makho);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhoHang.NOT_FOUND_KhoHang); }
            return Ok(model);
        }
        [Route(WebEndpoint.KhoHang.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddKHOHANG(KhoHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = khoHangService.AddKhoHang(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhoHang.EXISTED_KhoHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsKhoHang.UPDATE_KhoHang_SUCCESS);

        }
        [Route(WebEndpoint.KhoHang.REMOVE_BY_MAKHO)]
        [HttpDelete]
        public IActionResult RemoveKHOHANG()
        {
            string makho = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(makho))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = khoHangService.RemovekhoHang(makho);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhoHang.NOT_FOUND_KhoHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsKhoHang.DELETE_KhoHang_SUCCESS);
        }
        [Route(WebEndpoint.KhoHang.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateKHOHANG(KhoHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = khoHangService.UpdatekhoHang(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsKhoHang.UPDATE_KhoHang_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsKhoHang.NOT_FOUND_KhoHang);
        }
    }
}
