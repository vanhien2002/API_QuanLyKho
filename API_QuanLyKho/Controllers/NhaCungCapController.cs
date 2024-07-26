using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase 
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly INhaCungCapService NhaCungCapService;
        public NhaCungCapController(INhaCungCapService NhaCungCapService)
        {
            this.NhaCungCapService = NhaCungCapService;
        }
        [Route(WebEndpoint.NhaCungCap.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<NhaCungCapModel> lst = NhaCungCapService.getAllNhaCungCap();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhaCungCap.NOT_FOUND_NhaCungCap); }
            return Ok(lst);
        }
        [Route(WebEndpoint.NhaCungCap.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string maph = RouteData.Values["manhacungcap"].ToString();
            if (String.IsNullOrEmpty(maph)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            NhaCungCapModel model = NhaCungCapService.getNhaCungCapById(maph);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhaCungCap.NOT_FOUND_NhaCungCap); }
            return Ok(model);
        }
        [Route(WebEndpoint.NhaCungCap.GET_BY_SDT)]
        [HttpGet]
        public IActionResult GetSDT()
        {
            string sdt = RouteData.Values["sdtnhacungcap"].ToString();
            if (String.IsNullOrEmpty(sdt)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            NhaCungCapModel model = NhaCungCapService.getNhaCungCapBySDT(sdt);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhaCungCap.NOT_FOUND_NhaCungCap); }
            return Ok(model);
        }
        [Route(WebEndpoint.NhaCungCap.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddPhieuNh(NhaCungCapModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = NhaCungCapService.AddNhaCungCap(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhaCungCap.EXISTED_NhaCungCap); }
            return Ok(ApplicationContants.ReponseMessageConstantsNhaCungCap.UPDATE_NhaCungCap_SUCCESS);

        }
        [Route(WebEndpoint.NhaCungCap.REMOVE_BY_NHACUNGCAP)]
        [HttpDelete]
        public IActionResult RemovePhieuNh()
        {
            string maph = RouteData.Values["manhacungcap"].ToString();
            if (String.IsNullOrEmpty(maph))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = NhaCungCapService.RemoveNhaCungCap(maph);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsNhaCungCap.NOT_FOUND_NhaCungCap); }
            return Ok(ApplicationContants.ReponseMessageConstantsNhaCungCap.DELETE_NhaCungCap_SUCCESS);
        }
        [Route(WebEndpoint.NhaCungCap.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdatePhieuXuatHang(NhaCungCapModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = NhaCungCapService.UpdateNhaCungCap(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsNhaCungCap.UPDATE_NhaCungCap_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsNhaCungCap.NOT_FOUND_NhaCungCap);
        }
    }
}
