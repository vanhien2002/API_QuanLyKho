using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface INhanVienService
    {
        public List<NhanVienModel> getAllNhanVien();
        public NhanVienModel getNhanVienById(string maNV);
        public NhanVienModel getNhanVienBySdt(string sdt);
        public int AddNhanVien(NhanVienModel modelCTNH);
        public int RemoveNhanVien(string maCTNH);
        public int UpdateNhanVien(NhanVienModel modelCTNH);
        public List<string> GetMaNhanVien();
    }
    public class NhanVienService:INhanVienService
    {
        private readonly INhanVienRepository NhanVienRepository;
        public NhanVienService(INhanVienRepository NhanVienRepository) { this.NhanVienRepository = NhanVienRepository; }
        public List<NhanVienModel> getAllNhanVien()
        {
            List<NhanVienModel> lst = new List<NhanVienModel>();
            lst = NhanVienRepository.getAllNhanVien();
            return lst;
        }
        public NhanVienModel getNhanVienById(string maNV)
        {
            if (String.IsNullOrEmpty(maNV))
            {
                return null;
            }
            return NhanVienRepository.getNhanVienById(maNV);
        }
        public NhanVienModel getNhanVienBySdt(string sdt)
        {
            if (String.IsNullOrEmpty(sdt))
            {
                return null;
            }
            return NhanVienRepository.getNhanVienBySdt(sdt);
        }
        public int AddNhanVien(NhanVienModel model)
        {
            if (model == null) return 0;
            return NhanVienRepository.AddNhanVien(model);
        }
        public int RemoveNhanVien(string maNV)
        {
            if (String.IsNullOrEmpty(maNV)) return 0;
            return NhanVienRepository.RemoveNhanVien(maNV);
        }
        public int UpdateNhanVien(NhanVienModel model)
        {
            if (model == null) return 0;
            return NhanVienRepository.UpdateNhanVien(model, model.MaNhanVien);
        }
        public List<string> GetMaNhanVien()
        {
            List<string> lst = new List<string>();
            lst = NhanVienRepository.GetMaNhanVien();
            return lst;
        }
    }
}
