using API_QuanLyKho.Hepper;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
        [Route(WebEndpoint.Home.GETHOME)]
        [HttpGet]
        public IActionResult index()
        {
            string home = homeService.getAll();
            return Ok(ReponseMessageConstantsHome.UPDATE_HOME_SUCCESS);
        }
        [HttpGet]
        [Route(WebEndpoint.Home.GETBYID)]
        public IActionResult getById() {     
            //get values id trong url
            string values = RouteData.Values["id"]?.ToString();
            return Ok(); }
        [HttpPost]
        [Route(WebEndpoint.Home.UPDATE)]
        public IActionResult add() { return Ok(); }
        [HttpDelete]
        [Route(WebEndpoint.Home.REMOVE)]
        public IActionResult remove() { return Ok(); }
        [HttpPut]
        [Route(WebEndpoint.Home.UPDATE)]
        public IActionResult update() { return Ok(); }
    }
}
