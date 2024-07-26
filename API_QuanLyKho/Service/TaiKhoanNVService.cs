using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface ITaiKhoanNVService
    {
        public List<TaiKhoanNVModel> getAllTaiKhoanNV();
        public TaiKhoanNVModel getTaiKhoanNVById(string matk);
        public int AddTaiKhoanNV(TaiKhoanNVModel model);
        public int Removetk(string matk);
        public int Updatetk(TaiKhoanNVModel model);
    }
    public class TaiKhoanNVService : ITaiKhoanNVService
    {
        private readonly ITaiKhoanNVRepository tkRepository;
        public TaiKhoanNVService(ITaiKhoanNVRepository tkRepository) { this.tkRepository = tkRepository; }
        public List<TaiKhoanNVModel> getAllTaiKhoanNV()
        {
            List<TaiKhoanNVModel> lst = new List<TaiKhoanNVModel>();
            lst = tkRepository.getAllTaiKhoanNV();
            return lst;
        }
        public TaiKhoanNVModel getTaiKhoanNVById(string matk)
        {
            if (String.IsNullOrEmpty(matk))
            {
                return null;
            }
            return tkRepository.getTaiKhoanNVById(matk);
        }
        public int AddTaiKhoanNV(TaiKhoanNVModel model)
        {
            if (model == null) return 0;
            return tkRepository.AddTaiKhoanNV(model);
        }
        public int Removetk(string matk)
        {
            if (String.IsNullOrEmpty(matk)) return 0;
            return tkRepository.RemoveTaiKhoanNV(matk);
        }
        public int Updatetk(TaiKhoanNVModel model)
        {
            if (model == null) return 0;
            return tkRepository.UpdateTaiKhoanNV(model);
        }
    }
}
