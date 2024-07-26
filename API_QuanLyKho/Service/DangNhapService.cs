using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IDangNhapService
    {
        public List<DangNhapModel> getAllDangNhap();
        public DangNhapModel getDangNhapById(string taikhoandn);
        public DangNhapModel getDangNhaptkandmk(string taikhoandn, string matkhau);
        public int AddDangNhap(DangNhapModel model);
        public int Removedn(string taikhoandn);
        public int Updatedn(DangNhapModel model);
        public List<string> GetTaiKhoan();
    }
    public class DangNhapService : IDangNhapService
    {
        private readonly IDangNhapRepository dnRepository;
        public DangNhapService(IDangNhapRepository dnRepository) { this.dnRepository = dnRepository; }
        public List<DangNhapModel> getAllDangNhap()
        {
            List<DangNhapModel> lst = new List<DangNhapModel>();
            lst = dnRepository.getAllDangNhap();
            return lst;
        }
        public DangNhapModel getDangNhapById(string taikhoandn)
        {
            if (String.IsNullOrEmpty(taikhoandn))
            {
                return null;
            }
            return dnRepository.getDangNhapById(taikhoandn);
        }
        public List<string> GetTaiKhoan()
        {
            List<string> lst = new List<string>();
            lst = dnRepository.GetTaiKhoan();
            return lst;
        }
        public DangNhapModel getDangNhaptkandmk(string taikhoandn, string matkhau)
        {
            if (String.IsNullOrEmpty(taikhoandn) || String.IsNullOrEmpty(matkhau))
            {
                return null;
            }
            return dnRepository.getDangNhaptkandmk(taikhoandn, matkhau);
        }
        public int AddDangNhap(DangNhapModel model)
        {
            if (model == null) return 0;
            return dnRepository.AddDangNhap(model);
        }
        public int Removedn(string taikhoandn)
        {
            if (String.IsNullOrEmpty(taikhoandn)) return 0;
            return dnRepository.RemoveDangNhap(taikhoandn);
        }
        public int Updatedn(DangNhapModel model)
        {
            if (model == null) return 0;
            return dnRepository.UpdateDangNhap(model);
        }
    }
}
