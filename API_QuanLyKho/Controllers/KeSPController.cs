using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeSPController : ControllerBase
    {
        private readonly IKeSPService keSPService;
        public KeSPController(IKeSPService keSPService)
        {
            this.keSPService = keSPService;
        }
        [Route(WebEndpoint.KeSP.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<KeSPModel> lst = keSPService.getAllKeSP();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKeSP.NOT_FOUND_KeSP); }
            return Ok(lst);
        }
        [Route(WebEndpoint.KeSP.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string make = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(make)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            KeSPModel model = keSPService.getKeSPById(make);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsKeSP.NOT_FOUND_KeSP); }
            return Ok(model);
        }
        [Route(WebEndpoint.KeSP.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddKE(KeSPModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = keSPService.AddKeSP(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKeSP.EXISTED_KeSP); }
            return Ok(ApplicationContants.ReponseMessageConstantsKeSP.UPDATE_KeSP_SUCCESS);

        }
        [Route(WebEndpoint.KeSP.REMOVE_BY_MAKE)]
        [HttpDelete]
        public IActionResult RemoveKE()
        {
            string make = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(make))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = keSPService.Removeke(make);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsKeSP.NOT_FOUND_KeSP); }
            return Ok(ApplicationContants.ReponseMessageConstantsKeSP.DELETE_KeSP_SUCCESS);
        }
        [Route(WebEndpoint.KeSP.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdatePhieuXuatHang(KeSPModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = keSPService.Updateke(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsKeSP.UPDATE_KeSP_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsKeSP.NOT_FOUND_KeSP);

        }
        [Route(WebEndpoint.KeSP.GET_BY_MAKHU)]
        [HttpGet]
        public IActionResult GetMakhu()
        {
            string makhu = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(makhu))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            List<KeSPModel> models = keSPService.getKeSPByMaKhu(makhu);
            if (models == null || models.Count == 0)
            {
                return NotFound(ApplicationContants.ReponseMessageConstantsKeSP.NOT_FOUND_KeSP);
            }
            return Ok(models);
        }
    }
}
