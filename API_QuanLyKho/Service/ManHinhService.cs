using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IManHinhService
    {
        public List<ManHinhModel> getAllManHinh();
        public ManHinhModel getManHinhById(string mamanhinh);
        public int AddManHinh(ManHinhModel model);
        public int Removemh(string mamanhinh);
        public int Updatemh(ManHinhModel model);
        public List<string> GetMaManHinh();
        public List<ManHinhModel> GetManHinhs(string taikhoan);
    }
    public class ManHinhService : IManHinhService
    {
        private readonly IManHinhRepository mhRepository;
        public ManHinhService(IManHinhRepository mhRepository) { this.mhRepository = mhRepository; }
        public List<ManHinhModel> getAllManHinh()
        {
            List<ManHinhModel> lst = new List<ManHinhModel>();
            lst = mhRepository.getAllManHinh();
            return lst;
        }
        public ManHinhModel getManHinhById(string mamanhinh)
        {
            if (String.IsNullOrEmpty(mamanhinh))
            {
                return null;
            }
            return mhRepository.getManHinhById(mamanhinh);
        }
        public List<string> GetMaManHinh()
        {
            List<string> lst = new List<string>();
            lst = mhRepository.GetMaManHinh();
            return lst;
        }
        public List<ManHinhModel> GetManHinhs(string taikhoan)
        {
            return mhRepository.GetManHinhs(taikhoan);
        }
        public int AddManHinh(ManHinhModel model)
        {
            if (model == null) return 0;
            return mhRepository.AddManHinh(model);
        }
        public int Removemh(string mamanhinh)
        {
            if (String.IsNullOrEmpty(mamanhinh)) return 0;
            return mhRepository.RemoveManHinh(mamanhinh);
        }
        public int Updatemh(ManHinhModel model)
        {
            if (model == null) return 0;
            return mhRepository.UpdateManHinh(model);
        }
    }
}
