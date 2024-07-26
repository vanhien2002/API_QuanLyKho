using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanQuyenController : ControllerBase
    {
        private  readonly IPhanQuyenService phanQuyenService;
        public PhanQuyenController(IPhanQuyenService phanQuyenService)
        {
            this.phanQuyenService = phanQuyenService;
        }
        [Route(WebEndpoint.PhanQuyen.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<PhanQuyenModel> lst = phanQuyenService.getAllPhanQuyen();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhanQuyen.NOT_FOUND_MaNhomNguoiDung); }
            return Ok(lst);
        }
        [Route(WebEndpoint.PhanQuyen.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string mapq = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(mapq)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            PhanQuyenModel model = phanQuyenService.getPhanQuyenById(mapq);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhanQuyen.NOT_FOUND_MaNhomNguoiDung); }
            return Ok(model);
        }

        [Route(WebEndpoint.PhanQuyen.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddTK(PhanQuyenModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = phanQuyenService.AddPhanQuyen(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhanQuyen.EXISTED_MaNhomNguoiDung); }
            return Ok(ApplicationContants.ReponseMessageConstantsPhanQuyen.UPDATE_MaNhomNguoiDung_SUCCESS);

        }
        [Route(WebEndpoint.PhanQuyen.REMOVE_BY_MaNhomNguoiDung)]
        [HttpDelete]
        public IActionResult RemoveTK()
        {
            string mapq = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(mapq))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = phanQuyenService.Removepq(mapq);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhanQuyen.NOT_FOUND_MaNhomNguoiDung); }
            return Ok(ApplicationContants.ReponseMessageConstantsPhanQuyen.DELETE_MaNhomNguoiDung_SUCCESS);
        }
        [Route(WebEndpoint.PhanQuyen.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdatePhanQuyen(PhanQuyenModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = phanQuyenService.Updatepq(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsPhanQuyen.UPDATE_MaNhomNguoiDung_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsPhanQuyen.NOT_FOUND_MaNhomNguoiDung);
        }
    }
}
