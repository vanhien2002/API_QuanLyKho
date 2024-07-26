using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IKhoHangService
    {
        public List<KhoHangModel> getAllKhoHang();
        public KhoHangModel getKhoHangById(string makho);
        public int AddKhoHang(KhoHangModel model);
        public int RemovekhoHang(string makho);
        public int UpdatekhoHang(KhoHangModel model);
    }
    public class KhoHangService : IKhoHangService
    {
        private readonly IKhoHangRepository khoHangRepository;
        public KhoHangService(IKhoHangRepository khoHangRepository) { this.khoHangRepository = khoHangRepository; }
        public List<KhoHangModel> getAllKhoHang()
        {
            List<KhoHangModel> lst = new List<KhoHangModel>();
            lst = khoHangRepository.getAllKhoHang();
            return lst;
        }
        public KhoHangModel getKhoHangById(string makho)
        {
            if (String.IsNullOrEmpty(makho))
            {
                return null;
            }
            return khoHangRepository.getKhoHangById(makho);
        }
        public int AddKhoHang(KhoHangModel model)
        {
            if (model == null) return 0;
            return khoHangRepository.AddKhoHang(model);
        }
        public int RemovekhoHang(string makho)
        {
            if (String.IsNullOrEmpty(makho)) return 0;
            return khoHangRepository.RemoveKhoHang(makho);
        }
        public int UpdatekhoHang(KhoHangModel model)
        {
            if (model == null) return 0;
            return khoHangRepository.UpdateKhoHang(model);
        }
    }
}
