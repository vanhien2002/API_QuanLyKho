using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietNHController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IChiTietNHService chiTietNHService;
        public ChiTietNHController(IChiTietNHService chiTietNHService)
        {
            this.chiTietNHService = chiTietNHService;
        }
        [Route(WebEndpoint.ChiTietNH.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ChiTietNHModel> lst = chiTietNHService.getAllChiTietNH();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.NOT_FOUND_ChiTietNhapHang); }
            return Ok(lst);
        }
        [Route(WebEndpoint.ChiTietNH.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string maph = RouteData.Values["maphieunh"].ToString();
            if (String.IsNullOrEmpty(maph)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            List<ChiTietNHModel> lst = chiTietNHService.getChiTietNHById(maph);
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.NOT_FOUND_ChiTietNhapHang); }
            return Ok(lst);
        }
        [Route(WebEndpoint.ChiTietNH.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddPhieuNhapHang(ChiTietNHModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = chiTietNHService.AddChiTietNH(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.EXISTED_ChiTietNhapHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.UPDATE_ChiTietNhapHang_SUCCESS);

        }
        [Route(WebEndpoint.ChiTietNH.REMOVE_BY_CTMAPHIEUNH)]
        [HttpDelete]
        public IActionResult RemovePhieuNhapHang()
        {
            string maph = RouteData.Values["maphieunh"].ToString();
            if (String.IsNullOrEmpty(maph))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = chiTietNHService.RemoveChiTietNH(maph);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.NOT_FOUND_ChiTietNhapHang); }
            return Ok(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.DELETE_ChiTietNhapHang_SUCCESS);
        }
        [Route(WebEndpoint.ChiTietNH.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdatePhieuXuatHang(ChiTietNHModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = chiTietNHService.UpdateChiTietNH(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.UPDATE_ChiTietNhapHang_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.NOT_FOUND_ChiTietNhapHang);
        }
    }
}
