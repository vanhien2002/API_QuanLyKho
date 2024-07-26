using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuNhapHangController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IPhieuNhapHangService PhieuNhapHangService;
        public PhieuNhapHangController(IPhieuNhapHangService PhieuNhapHangService)
        {
            this.PhieuNhapHangService = PhieuNhapHangService;
        }
        [Route(WebEndpoint.PhieuNhapHang.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<PhieuNhapHangModel> lst = PhieuNhapHangService.getAllPhieuNhapHang();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.NOT_FOUND_PhieuNhapHang); }
            return Ok(lst);
        }
        [Route(WebEndpoint.PhieuNhapHang.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string maph = RouteData.Values["maphieunhaphang"].ToString();
            if (String.IsNullOrEmpty(maph)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            PhieuNhapHangModel model = PhieuNhapHangService.getPhieuNhapHangById(maph);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.NOT_FOUND_PhieuNhapHang); }
            return Ok(model);
        }
        [Route(WebEndpoint.PhieuNhapHang.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddPhieuNhapHang(PhieuNhapHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = PhieuNhapHangService.AddPhieuNhapHang(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.EXISTED_PhieuNhapHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.UPDATE_PhieuNhapHang_SUCCESS);

        }
        [Route(WebEndpoint.PhieuNhapHang.REMOVE_BY_PHIEUNHAPHANG)]
        [HttpDelete]
        public IActionResult RemovePhieuNhapHang()
        {
            string maph = RouteData.Values["maphieunhaphang"].ToString();
            if (String.IsNullOrEmpty(maph))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = PhieuNhapHangService.RemovePhieuNhapHang(maph);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.NOT_FOUND_PhieuNhapHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.DELETE_PhieuNhapHang_SUCCESS);
        }
        [Route(WebEndpoint.PhieuNhapHang.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdatePhieuXuatHang(PhieuNhapHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = PhieuNhapHangService.UpdatePhieuNhapHang(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.UPDATE_PhieuNhapHang_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.NOT_FOUND_PhieuNhapHang);
        }
        [Route(WebEndpoint.PhieuNhapHang.GET_PhieuNhapSoNgay)]
        [HttpGet]
        public IActionResult GetPhieuNhapTheoSoNgay()
        {
            string songay = RouteData.Values["songay"].ToString();
            if (String.IsNullOrEmpty(songay)) { return BadRequest( ApplicationContants.ReponseMessageConstantsPhieuNhapHang.NOT_FOUND_PhieuNhapHang); }
            List<PhieuNhapHangModel> lst = PhieuNhapHangService.getAllPhieuNhapHangSoNgay(int.Parse(songay));
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuNhapHang.NOT_FOUND_PhieuNhapHang); }
            return Ok(lst);
        }
    }
}
