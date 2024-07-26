using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;
using AutoMapper.Configuration.Conventions;

namespace API_QuanLyKho.Service
{
    public interface IChiTietXHService
    {
        public List<ChiTietXHModel> getAll();
        public List<ChiTietXHModel> getByChiTietPhieuXuatId(string MAPX);
        public ChiTietXHModel getChiTietPhieuXuatItem(string MAPX, string MASP);
        public int addItem(ChiTietXHModel model);
        public int remove(string maphieuxuat, string masp);
        public int remove(string maphieuxuat);
        public int update(ChiTietXHModel model);
    }
    public class ChiTietXHService:IChiTietXHService
    {
        IChiTietXHRepository repository;
        public ChiTietXHService(IChiTietXHRepository cHITIET_XHRepository)
        {
            repository = cHITIET_XHRepository;
        }
        public List<ChiTietXHModel> getAll()
        {
            List<ChiTietXHModel> lst = repository.getAll();
            return lst;
        }
        public List<ChiTietXHModel> getByChiTietPhieuXuatId(string MAPX)
        { 
            if (string.IsNullOrEmpty(MAPX)) {
                return null;
            }
            else
            {
                List<ChiTietXHModel> lst = repository.getByChiTietPhieuXuatId(MAPX);
                if (lst != null) { return lst; }
            }
            return null;
        }
        public ChiTietXHModel getChiTietPhieuXuatItem(string MAPX, string MASP)
        {
            if(String.IsNullOrEmpty(MASP) || String.IsNullOrEmpty(MASP)) { return null; }
            ChiTietXHModel item = repository.getChiTietPhieuXuatItem(MAPX, MASP);
            if(item != null) { return item; }
            return null;
        }
        public int addItem(ChiTietXHModel model)
        {
            if (model == null)
            {
                return 0;
            }
            ChiTietXHModel item = repository.getChiTietPhieuXuatItem(model.MAPH_XH, model.MA_SP);
            if(item != null)
            {
                return 0;
            }
            int kq = repository.addItem(model);
            return kq;
        }
        public int remove(string maphieuxuat, string masp)
        {
            if (String.IsNullOrEmpty(maphieuxuat) || String.IsNullOrEmpty(masp)) { return 0; }

            int kq = repository.remove(maphieuxuat, masp);
            return kq;
        }
        public int remove(string maphieuxuat)
        {
            if (String.IsNullOrEmpty(maphieuxuat)) { return 0; }
            int kq = repository.remove(maphieuxuat);
            return kq;
        }
        public int update(ChiTietXHModel model)
        {
            if(model == null) { return 0; }
            return repository.update(model);
        }
    }
}
