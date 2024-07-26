using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private readonly IAIService AIService;
        public AIController(IAIService AIService)
        {
            this.AIService = AIService;
        }
        [Route(WebEndpoint.AI.GET_ALL)]
        [HttpGet]
        public IActionResult GetAllAI()
        {
            List<AIModel> lst = AIService.getAllDataAI();
            if (lst == null) { return BadRequest(ApplicationContants.ReponseMessageConstantsChiTietNhapHang.NOT_FOUND_ChiTietNhapHang); }
            return Ok(lst);
        }
    }
}
