using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface ILoaiSPService
    {
        public List<LoaiSPModel> getAllLoaiSP();
        public LoaiSPModel getLoaiSPById(string malsp);
        public int AddLoaiSP(LoaiSPModel model);
        public int RemoveLoaiSP(string malsp);
        public int UpdateLoaiSP(LoaiSPModel model);
    }
    public class LoaiSPService : ILoaiSPService
    {
        private readonly ILoaiSPRepository LoaiSPRepository;
        public LoaiSPService(ILoaiSPRepository LoaiSPRepository) { this.LoaiSPRepository = LoaiSPRepository; }
        public List<LoaiSPModel> getAllLoaiSP()
        {
            List<LoaiSPModel> lst = new List<LoaiSPModel>();
            lst = LoaiSPRepository.getAllLoaiSP();
            return lst;
        }
        public LoaiSPModel getLoaiSPById(string malsp)
        {
            if (String.IsNullOrEmpty(malsp))
            {
                return null;
            }
            return LoaiSPRepository.getLoaiSPById(malsp);
        }
        public int AddLoaiSP(LoaiSPModel model)
        {
            if (model == null) return 0;
            return LoaiSPRepository.AddLoaiSP(model);
        }
        public int RemoveLoaiSP(string malsp)
        {
            if (String.IsNullOrEmpty(malsp)) return 0;
            return LoaiSPRepository.RemoveLoaiSP(malsp);
        }
        public int UpdateLoaiSP(LoaiSPModel model)
        {
            if (model == null) return 0;
            return LoaiSPRepository.UpdateLoaiSP(model);
        }
    }
}
