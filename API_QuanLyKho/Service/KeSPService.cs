using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IKeSPService
    {
        public List<KeSPModel> getAllKeSP();
        public KeSPModel getKeSPById(string make);
        public int AddKeSP(KeSPModel model);
        public int Removeke(string make);
        public int Updateke(KeSPModel model);
        List<KeSPModel> getKeSPByMaKhu(string makhu);
    }
    public class KeSPService : IKeSPService
    {
        private readonly IKeSPRepository keRepository;
        public KeSPService(IKeSPRepository keRepository) { this.keRepository = keRepository; }
        public List<KeSPModel> getAllKeSP()
        {
            List<KeSPModel> lst = new List<KeSPModel>();
            lst = keRepository.getAllKeSP();
            return lst;
        }
        public KeSPModel getKeSPById(string make)
        {
            if (String.IsNullOrEmpty(make))
            {
                return null;
            }
            return keRepository.getKeSPById(make);
        }
        public int AddKeSP(KeSPModel model)
        {
            if (model == null) return 0;
            return keRepository.AddKeSP(model);
        }
        public int Removeke(string make)
        {
            if (String.IsNullOrEmpty(make)) return 0;
            return keRepository.RemoveKeSP(make);
        }
        public int Updateke(KeSPModel model)
        {
            if (model == null) return 0;
            return keRepository.UpdateKeSP(model);
        }
        public List<KeSPModel> getKeSPByMaKhu(string makhu)
        {
            if (String.IsNullOrEmpty(makhu))
            {
                return null;
            }
            List<KeSPModel> results = keRepository.getKeSPByMaKhu(makhu);
            return results;
        }
    }
}
