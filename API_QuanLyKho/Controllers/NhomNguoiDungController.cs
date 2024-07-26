using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomNguoiDungController : ControllerBase
    {
        private readonly INhomNguoiDungService nhomNguoiDungService;
        public NhomNguoiDungController(INhomNguoiDungService nhomNguoiDungService)
        {
            this.nhomNguoiDungService = nhomNguoiDungService;
        }
        [Route(WebEndpoint.NhomNguoiDung.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<NhomNguoiDungModel> lst = nhomNguoiDungService.getAllNhomNguoiDung();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.NOT_FOUND_MaNhom); }
            return Ok(lst);
        }
        [Route(WebEndpoint.NhomNguoiDung.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string mand = RouteData.Values["manhom"].ToString();
            if (String.IsNullOrEmpty(mand)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            NhomNguoiDungModel model = nhomNguoiDungService.getNhomNguoiDungById(mand);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.NOT_FOUND_MaNhom); }
            return Ok(model);
        }
        [Route(WebEndpoint.NhomNguoiDung.ADD_ITEM)]
        [HttpPost]
        public IActionResult Addnd(NhomNguoiDungModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = nhomNguoiDungService.AddNhomNguoiDung(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.EXISTED_MaNhom); }
            return Ok(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.UPDATE_MaNhom_SUCCESS);

        }
        [Route(WebEndpoint.NhomNguoiDung.REMOVE_BY_MaNhom)]
        [HttpDelete]
        public IActionResult Removend()
        {
            string mand = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(mand))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = nhomNguoiDungService.Removenh(mand);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.NOT_FOUND_MaNhom); }
            return Ok(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.DELETE_MaNhom_SUCCESS);
        }
        [Route(WebEndpoint.NhomNguoiDung.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateNhomNguoiDung(NhomNguoiDungModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = nhomNguoiDungService.Updatenh(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.UPDATE_MaNhom_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.NOT_FOUND_MaNhom);
        }
        [Route(WebEndpoint.NhomNguoiDung.GetMaNhom)]
        [HttpGet]
        public IActionResult GetMaNhom()
        {
            List<string> lst = nhomNguoiDungService.GetMaNhom();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhomNguoiDung.NOT_FOUND_MaNhom); }
            return Ok(lst);
        }
    }
}
