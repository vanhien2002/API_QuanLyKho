using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKhoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase 
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IChucVuService ChucVuService;
        public ChucVuController(IChucVuService ChucVuService)
        {
            this.ChucVuService = ChucVuService;
        }
        [Route(WebEndpoint.ChucVu.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ChucVuModel> lst = ChucVuService.getAllChucVu();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsChucVu.NOT_FOUND_ChucVu); }
            return Ok(lst);
        }
        [Route(WebEndpoint.ChucVu.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string maph = RouteData.Values["machucvu"].ToString();
            if (String.IsNullOrEmpty(maph)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            ChucVuModel model = ChucVuService.getChucVuById(maph);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsChucVu.NOT_FOUND_ChucVu); }
            return Ok(model);
        }
        [Route(WebEndpoint.ChucVu.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddChucVu(ChucVuModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = ChucVuService.AddChucVu(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsChucVu.EXISTED_ChucVu); }
            return Ok(ApplicationContants.ReponseMessageConstantsChucVu.UPDATE_ChucVu_SUCCESS);

        }
        [Route(WebEndpoint.ChucVu.REMOVE_BY_CHUCVU)]
        [HttpDelete]
        public IActionResult RemoveChucVu()
        {
            string maph = RouteData.Values["machucvu"].ToString();
            if (String.IsNullOrEmpty(maph))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = ChucVuService.RemoveChucVu(maph);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsChucVu.NOT_FOUND_ChucVu); }
            return Ok(ApplicationContants.ReponseMessageConstantsChucVu.DELETE_ChucVu_SUCCESS);
        }
        [Route(WebEndpoint.ChucVu.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateChucVu(ChucVuModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = ChucVuService.UpdateChucVu(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsChucVu.UPDATE_ChucVu_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsChucVu.NOT_FOUND_ChucVu);
        }
    }
}
