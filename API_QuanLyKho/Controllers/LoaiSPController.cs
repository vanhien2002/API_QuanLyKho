using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        private readonly ILoaiSPService loaiSPService;
        public LoaiSPController(ILoaiSPService loaiSPService)
        {
            this.loaiSPService = loaiSPService;
        }
        [Route(WebEndpoint.LoaiSP.GET_ALL)]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<LoaiSPModel> lst = loaiSPService.getAllLoaiSP();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsLoaiSP.NOT_FOUND_LoaiSP); }
            return Ok(lst);
        }
        [Route(WebEndpoint.LoaiSP.GET_BY_ID)]
        [HttpGet]
        public IActionResult GetID()
        {
            string maloai = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(maloai)) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            LoaiSPModel model = loaiSPService.getLoaiSPById(maloai);
            if (model == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsLoaiSP.NOT_FOUND_LoaiSP); }
            return Ok(model);
        }
        [Route(WebEndpoint.LoaiSP.ADD_ITEM)]
        [HttpPost]
        public IActionResult AddLoaiSP(LoaiSPModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = loaiSPService.AddLoaiSP(model);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsLoaiSP.EXISTED_LoaiSP); }
            return Ok(ApplicationContants.ReponseMessageConstantsLoaiSP.UPDATE_LoaiSP_SUCCESS);

        }
        [Route(WebEndpoint.LoaiSP.REMOVE_BY_MALOAISP)]
        [HttpDelete]
        public IActionResult RemoveLoaiSP()
        {
            string maloai = RouteData.Values["id"].ToString();
            if (String.IsNullOrEmpty(maloai))
            {
                return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED);
            }
            int kq = loaiSPService.RemoveLoaiSP(maloai);
            if (kq == 0) { return BadRequest(ApplicationContants.ReponseMessageConstantsLoaiSP.NOT_FOUND_LoaiSP); }
            return Ok(ApplicationContants.ReponseMessageConstantsLoaiSP.DELETE_LoaiSP_SUCCESS);
        }
        [Route(WebEndpoint.LoaiSP.UPDATE_ITEM)]
        [HttpPut]
        public IActionResult UpdateLoaiSP(LoaiSPModel model)
        {
            if (model == null) { return BadRequest(ApplicationContants.ResponseCodeConstants.FAILED); }
            int kq = loaiSPService.UpdateLoaiSP(model);
            if (kq == 1) { return Ok(ApplicationContants.ReponseMessageConstantsLoaiSP.UPDATE_LoaiSP_SUCCESS); }
            return BadRequest(ApplicationContants.ReponseMessageConstantsLoaiSP.NOT_FOUND_LoaiSP);
        }
        

    }
}

