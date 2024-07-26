using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : ControllerBase
    {
        IThongKeService service;
        public ThongKeController(IThongKeService service)
        {
            this.service = service;
        }
        [Route(WebEndpoint.ThongKe.GET_DoanhThuNhapHangTheoNgay)]
        [HttpGet]
        public IActionResult ThongKeDoanhThu()
        {
            string v1 = RouteData.Values["ngaybd"].ToString();
            var value1 = HttpUtility.UrlDecode(v1);
            string v2 = RouteData.Values["ngaykt"].ToString();
            var value2 = HttpUtility.UrlDecode(v2);
            DateTime ngayBD =DateTime.Parse(value1);
            DateTime ngayKT =DateTime.Parse(value2);
            List<TK_NhapHangModel> lst = service.getDoanhThuNhapHang(ngayBD, ngayKT);
            return Ok(lst);
        }
        [Route(WebEndpoint.ThongKe.GET_DoanhThuXuatHangTheoNgay)]
        [HttpGet]
        public IActionResult ThongKeDoanhThuXuatHang()
        {
            string v1 = RouteData.Values["ngaybd"].ToString();
            string value1 = HttpUtility.UrlDecode(v1).ToString();
            string v2 = RouteData.Values["ngaykt"].ToString();
            string value2 = HttpUtility.UrlDecode(v2).ToString();
            DateTime ngayBD = DateTime.Parse(value1);
            DateTime ngayKT = DateTime.Parse(value2);
            List<TK_XuatHangModel> lst = service.getDoanhThuXuatHang(ngayBD, ngayKT);
            if (lst == null) { return BadRequest("Fail"); }
            return Ok(lst);
        }
    }
}
