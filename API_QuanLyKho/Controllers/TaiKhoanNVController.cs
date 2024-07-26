using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanNVController : ControllerBase
    {
        private readonly ITaiKhoanNVService taiKhoanNVService;
        public TaiKhoanNVController(ITaiKhoanNVService taiKhoanNVService)
        {
            this.taiKhoanNVService = taiKhoanNVService;
        }
        [Route(WebEndpoint.TaiKhoanNV.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TaiKhoanNVModel> lst = taiKhoanNVService.getAllTaiKhoanNV();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.NOT_FOUND_TaiKhoan); }
            return Ok(lst);
        }
        [Route(WebEndpoint.TaiKhoanNV.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string matk = RouteData.Values["taikhoan"].ToString();
            if (String.IsNullOrEmpty(matk)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            TaiKhoanNVModel model = taiKhoanNVService.getTaiKhoanNVById(matk);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.NOT_FOUND_TaiKhoan); }
            return Ok(model);
        }
        [Route(WebEndpoint.TaiKhoanNV.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddTK(TaiKhoanNVModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = taiKhoanNVService.AddTaiKhoanNV(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.EXISTED_TaiKhoan); }
            return Ok(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.UPDATE_TaiKhoan_SUCCESS);

        }
        [Route(WebEndpoint.TaiKhoanNV.REMOVE_BY_TaiKhoan)]
        [HttpDelete]
        public IActionResult RemoveTK()
        {
            string matk = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(matk))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = taiKhoanNVService.Removetk(matk);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.NOT_FOUND_TaiKhoan); }
            return Ok(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.DELETE_TaiKhoan_SUCCESS);
        }
        [Route(WebEndpoint.TaiKhoanNV.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateTaiKhoan(TaiKhoanNVModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = taiKhoanNVService.Updatetk(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.UPDATE_TaiKhoan_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsTaiKhoanNV.NOT_FOUND_TaiKhoan);
        }
    }
}
