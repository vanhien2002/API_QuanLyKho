using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IGioHangSevice
    {
        public List<GioHangModel> getByMaKH(string maKH);
        public int ThemGioHang(GioHangModel t);
        public int xoaGioHang(string MaKH, string MaSP);
        public int CapNhatGioHang(GioHangModel gh);
    }
    public class GioHangSevice:IGioHangSevice
    {
        IGioHangRepository repository;
        public GioHangSevice(IGioHangRepository repository) { this.repository = repository; }
        public List<GioHangModel> getByMaKH(string maKH)
        {
            return repository.getByMaKH(maKH);
        }
        public int ThemGioHang(GioHangModel t)
        {
            return repository.ThemGioHang(t);
        }
        public int xoaGioHang(string MaKH, string MaSP)
        {
            return repository.xoaGioHang(MaKH, MaSP);
        }
        public int CapNhatGioHang(GioHangModel gh)
        {
           return repository.CapNhatGioHang(gh);
        }
    }
}
