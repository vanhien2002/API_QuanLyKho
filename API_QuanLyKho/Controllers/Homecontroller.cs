using API_QuanLyKho.Hepper;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Homecontroller : ControllerBase
    {
        private readonly IHomeService homeService;      
        public Homecontroller(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        [Route(WebEndpoint.Home.GetHome)]
        [HttpGet]
        public IActionResult index()
        {
            string home = homeService.getAll();
            return Ok(ReponseMessageConstantsHome.UPDATE_HOME_SUCCESS);
        }
    }
}
