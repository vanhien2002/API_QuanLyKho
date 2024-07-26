using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuXuatHangController : ControllerBase
    {
        private readonly IPhieuXuatHangService phieuXuatHangService;
        public PhieuXuatHangController(IPhieuXuatHangService phieuXuatHangService)
        {
            this.phieuXuatHangService = phieuXuatHangService;
        }
        [Route(WebEndpoint.PhieuXuatHang.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<PhieuXuatHangModel> lst = phieuXuatHangService.getAllPhieuXuatHang();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.NOT_FOUND_PhieuXuatHang); }
            return Ok(lst);
        }

        [Route(WebEndpoint.PhieuXuatHang.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string maph = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(maph)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            PhieuXuatHangModel model = phieuXuatHangService.getPhieuXuatHangById(maph);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.NOT_FOUND_PhieuXuatHang); }
            return Ok(model);
        }
        [HttpPost]
        [Route(WebEndpoint.PhieuXuatHang.ADD_ITEM)]
        public IActionResult AddPhieuXuatHang(PhieuXuatHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = phieuXuatHangService.AddPhieuXuatHang(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.EXISTED_PhieuXuatHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.UPDATE_PhieuXuatHang_SUCCESS);
        }
        [Route(WebEndpoint.PhieuXuatHang.REMOVE_BY_MAPHIEUXH)]
        [HttpDelete]
        public IActionResult RemovePhieuXuatHang()
        {
            string maph = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(maph))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = phieuXuatHangService.RemovePhieuXuatHang(maph);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.NOT_FOUND_PhieuXuatHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsChiTietPhieuXuat.DELETE_ChiTietPhieuXuat_SUCCESS);
        }
        [Route(WebEndpoint.PhieuXuatHang.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdatePhieuXuatHang(PhieuXuatHangModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = phieuXuatHangService.UpdatePhieuXuatHang(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.UPDATE_PhieuXuatHang_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.NOT_FOUND_PhieuXuatHang);
        }
        [Route(WebEndpoint.PhieuXuatHang.GET_ThongKeSoNgay)]
        [HttpGet]
        public IActionResult GetThongKeSoNgay()
        {
            string songay = RouteData.Values["songay"].ToString();
            if (int.Parse(songay) < 1) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            if (String.IsNullOrEmpty(songay)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            List<PhieuXuatHangModel> model = phieuXuatHangService.getPhieuThongKeSoNgay(int.Parse(songay));
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsPhieuXuatHang.NOT_FOUND_PhieuXuatHang); }
            return Ok(model);
        }
    }
}
