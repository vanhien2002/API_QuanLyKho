using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;
using System.Text.RegularExpressions;

namespace API_QuanLyKho.Service
{
    public interface ISanPhamService
    {
        public List<SanPhamModel> getAllSanPham();
        public SanPhamModel getSanPhamById(string masp);
        public List<SanPhamModel> getSanPhamByNCC(string maNCC);
        public List<SanPhamModel> getSanPhamByKho(string maKho);
        public int AddSanPham(SanPhamModel model);
        public int RemoveSanPham(string masp);
        public int UpdateSanPham(SanPhamModel model); 
        public List<ThongKeSpModel> ThongKeSLNhap(DateTime ngaybd, DateTime ngaykt);
        public List<ThongKeSpModel> ThongKeBanHang(DateTime ngaybd, DateTime ngaykt);
        public List<ThongKeSpModel> ThongKeTonKho(DateTime ngaybd, DateTime ngaykt);
        public List<SanPhamModel> ThongKeDate(DateTime ngaybd, DateTime ngaykt);
        public List<string> GetMaSP();
    }
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository SanPhamRepository;
        public SanPhamService(ISanPhamRepository SanPhamRepository) { this.SanPhamRepository = SanPhamRepository; }
        public List<SanPhamModel> getAllSanPham()
        {
            List<SanPhamModel> lst = new List<SanPhamModel>();
            lst = SanPhamRepository.getAllSanPham();
            return lst;
        }
        public SanPhamModel getSanPhamById(string masp)
        {
            if (String.IsNullOrEmpty(masp))
            {
                return null;
            }
            return SanPhamRepository.getSanPhamById(masp);
        }
        public List<SanPhamModel> getSanPhamByNCC(string maNCC)
        {
            List<SanPhamModel> lst = new List<SanPhamModel>();
            if (String.IsNullOrEmpty(maNCC))
            {
                return null;
            }
            lst = SanPhamRepository.getSanPhamByNCC(maNCC);
            return lst;
        }
        public List<SanPhamModel> getSanPhamByKho(string maKho)
        {
            List<SanPhamModel> lst = new List<SanPhamModel>();
            if (String.IsNullOrEmpty(maKho))
            {
                return null;
            }
            lst = SanPhamRepository.getSanPhamByKho(maKho);
            return lst;
        }
        public int AddSanPham(SanPhamModel model)
        {
            if (model == null) return 0;
            return SanPhamRepository.AddSanPham(model);
        }
        public int RemoveSanPham(string masp)
        {
            if (String.IsNullOrEmpty(masp)) return 0;
            return SanPhamRepository.RemoveSanPham(masp);
        }
        public int UpdateSanPham(SanPhamModel model)
        {
            if (model == null) return 0;
            return SanPhamRepository.UpdateSanPham(model);
        }
        public List<string> GetMaSP()
        {
            List<string> lst = new List<string>();
            lst = SanPhamRepository.GetMaSP();
            return lst;
        }
        public List<ThongKeSpModel> ThongKeSLNhap(DateTime ngaybd, DateTime ngaykt)
        {
            List<ThongKeSpModel> lst = SanPhamRepository.ThongKeSLNhap(ngaybd, ngaykt);
            return lst;
        }
        public List<ThongKeSpModel> ThongKeBanHang(DateTime ngaybd, DateTime ngaykt)
        {
            List<ThongKeSpModel> lst = SanPhamRepository.ThongKeSlBan(ngaybd, ngaykt);
            return lst;
        }
        public List<ThongKeSpModel> ThongKeTonKho(DateTime ngaybd, DateTime ngaykt)
        {
            List<ThongKeSpModel> lst = SanPhamRepository.ThongKeTonKho(ngaybd, ngaykt);
            return lst;
        }
        public List<SanPhamModel> ThongKeDate(DateTime ngaybd, DateTime ngaykt)
        {
            List<SanPhamModel> lst = SanPhamRepository.ThongKeDate(ngaybd, ngaykt);
            return lst;
        }
    }
}
