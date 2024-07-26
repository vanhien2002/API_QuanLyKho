using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuController : ControllerBase
    {
        private readonly IKhuService khuService;
        public KhuController(IKhuService khuService)
        {
            this.khuService = khuService;
        }
        [Route(WebEndpoint.Khu.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<KhuModel> lst = khuService.getAllKhu();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhu.NOT_FOUND_Khu); }
            return Ok(lst);
        }
        [Route(WebEndpoint.Khu.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string makhu = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(makhu)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            KhuModel model = khuService.getKhuById(makhu);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhu.NOT_FOUND_Khu); }
            return Ok(model);
        }
        [Route(WebEndpoint.Khu.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddKhu(KhuModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = khuService.AddKhu(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhu.EXISTED_Khu); }
            return Ok(ApplicationContants.ReponseMessageConstantsKhu.UPDATE_Khu_SUCCESS);

        }
        [Route(WebEndpoint.Khu.REMOVE_BY_MAKHU)]
        [HttpDelete]
        public IActionResult RemoveKhu()
        {
            string makhu = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(makhu))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = khuService.RemoveKhu(makhu);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKhu.NOT_FOUND_Khu); }
            return Ok(ApplicationContants.ReponseMessageConstantsKhu.DELETE_Khu_SUCCESS);
        }
        [Route(WebEndpoint.Khu.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateKhu(KhuModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = khuService.UpdateKhu(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsKhu.UPDATE_Khu_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsKhu.NOT_FOUND_Khu);
        }
        [Route(WebEndpoint.Khu.GetmaKhu)]
        [HttpGet]
        public IActionResult GetMaKhu()
        {
            List<string> lst = khuService.GetMaKhu();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsSanPham.NOT_FOUND_SanPham); }
            return Ok(lst);
        }
    }
}

