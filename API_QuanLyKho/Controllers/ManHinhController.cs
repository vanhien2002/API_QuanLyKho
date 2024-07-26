using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManHinhController : ControllerBase
    {
        private readonly IManHinhService manhinhService;
        public ManHinhController(IManHinhService manhinhService)
        {
            this.manhinhService = manhinhService;
        }
        [Route(WebEndpoint.ManHinh.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ManHinhModel> lst = manhinhService.getAllManHinh();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsManHinh.NOT_FOUND_MaManHinh); }
            return Ok(lst);
        }
        [Route(WebEndpoint.ManHinh.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string mand = RouteData.Values["ma-man-hinh"].ToString();
            if (String.IsNullOrEmpty(mand)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            ManHinhModel model = manhinhService.getManHinhById(mand);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsManHinh.NOT_FOUND_MaManHinh); }
            return Ok(model);
        }
        [Route(WebEndpoint.ManHinh.ADD_ITEM)]
        [HttpPost]
        public IActionResult Addnd(ManHinhModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = manhinhService.AddManHinh(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsManHinh.EXISTED_MaManHinh); }
            return Ok(ApplicationContants.ReponseMessageConstantsManHinh.UPDATE_MaManHinh_SUCCESS);

        }
        [Route(WebEndpoint.ManHinh.GetManHinh)]
        [HttpGet]
        public IActionResult GetManHinhs()
        {
            string taikhoan = RouteData.Values["taikhoan"].ToString();
            if (String.IsNullOrEmpty(taikhoan))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }

            List<ManHinhModel> manHinhs = manhinhService.GetManHinhs(taikhoan);

            if (manHinhs == null || manHinhs.Count == 0)
            {
                return BadRequest(ApplicationContants.ReponseMessageConstantsManHinh.NOT_FOUND_MaManHinh);
            }

            return Ok(manHinhs);
        }
        [Route(WebEndpoint.ManHinh.REMOVE_BY_MaManHinh)]
        [HttpDelete]
        public IActionResult Removend()
        {
            string mand = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(mand))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = manhinhService.Removemh(mand);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsManHinh.NOT_FOUND_MaManHinh); }
            return Ok(ApplicationContants.ReponseMessageConstantsManHinh.DELETE_MaManHinh_SUCCESS);
        }
        [Route(WebEndpoint.ManHinh.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateManHinh(ManHinhModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = manhinhService.Updatemh(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsManHinh.UPDATE_MaManHinh_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsManHinh.NOT_FOUND_MaManHinh);
        }
        [Route(WebEndpoint.ManHinh.GetMaManHinh)]
        [HttpGet]
        public IActionResult GetMaManHinh()
        {
            List<string> lst = manhinhService.GetMaManHinh();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsManHinh.NOT_FOUND_MaManHinh); }
            return Ok(lst);

        }
    }
}