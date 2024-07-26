using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using API_QuanLyKho.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;

namespace API_QuanLyKho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        IGioHangSevice service;
        public GioHangController(IGioHangSevice service) { this.service = service; }
        [Route(WebEndpoint.GioHang.GET_GioHangByMaKH)]
        [HttpGet]
        public IActionResult GetGioHangByMaKH()
        {
            string makH = RouteData.Values["makh"].ToString();
            if (String.IsNullOrEmpty(makH)) { return BadRequest("Mã khách hàng không được null"); }
            List<GioHangModel> result = service.getByMaKH(makH);
            if (result == null) { return BadRequest("Không tìm thấy"); }
            return Ok(result);
        }
        [HttpDelete]
        [Route(WebEndpoint.GioHang.Delete_Gio_Hang)]
        public IActionResult XoaGioHangByKH()
        {
            string makH = RouteData.Values["makh"].ToString();
            string maSP = RouteData.Values["maSP"].ToString();
            if (String.IsNullOrEmpty(makH) || String.IsNullOrEmpty(maSP)) { return BadRequest("Tham số đầu vào bị sai"); }
            int kq = service.xoaGioHang(makH, maSP);
            if (kq == 1) { return Ok(); }
            return BadRequest("Xóa thất bại");
            return Ok();
        }
        [HttpPut]
        [Route(WebEndpoint.GioHang.Cap_Nhat_Gio_Hang)]
        public IActionResult CapNhatGioHang(GioHangModel gh)
        {
            if (gh == null) { return BadRequest("Giỏ hàng bị null"); }
            int kq = service.CapNhatGioHang(gh);
            if(kq == 1) { return Ok(); }
            return BadRequest("Cập nhật giỏ hàng thất bại");
        }
        [HttpPost]
        [Route(WebEndpoint.GioHang.Add_Gio_Hang)]
        public IActionResult themGioHang(GioHangModel giohang)
        {
            if(giohang == null)
            {
                return BadRequest("Giỏ hàng không được phép null");
            }
            int kq = service.ThemGioHang(giohang);
            if(kq == 1) { return Ok("Thêm giỏ hàng thành công"); }
            return BadRequest("Thêm giỏ hàng thất bại");
        }
    }
}
