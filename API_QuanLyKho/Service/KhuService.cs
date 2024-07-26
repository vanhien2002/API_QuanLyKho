using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IKhuService
    {
        public List<KhuModel> getAllKhu();
        public KhuModel getKhuById(string makhu);
        public int AddKhu(KhuModel model);
        public int RemoveKhu(string makhu);
        public int UpdateKhu(KhuModel model);
        public List<string> GetMaKhu();
    }
    public class KhuService : IKhuService
    {
        private readonly IKhuRepository KhuRepository;
        public KhuService(IKhuRepository KhuRepository) { this.KhuRepository = KhuRepository; }
        public List<KhuModel> getAllKhu()
        {
            List<KhuModel> lst = new List<KhuModel>();
            lst = KhuRepository.getAllKhu();
            return lst;
        }
        public KhuModel getKhuById(string makhu)
        {
            if (String.IsNullOrEmpty(makhu))
            {
                return null;
            }
            return KhuRepository.getKhuById(makhu);
        }
        public int AddKhu(KhuModel model)
        {
            if (model == null) return 0;
            return KhuRepository.AddKhu(model);
        }
        public int RemoveKhu(string makhu)
        {
            if (String.IsNullOrEmpty(makhu)) return 0;
            return KhuRepository.RemoveKhu(makhu);
        }
        public int UpdateKhu(KhuModel model)
        {
            if (model == null) return 0;
            return KhuRepository.UpdateKhu(model);
        }
        public List<string> GetMaKhu()
        {
            List<string> lst = new List<string>();
            lst = KhuRepository.GetMaKhu();
            return lst;
        }
    }
}
