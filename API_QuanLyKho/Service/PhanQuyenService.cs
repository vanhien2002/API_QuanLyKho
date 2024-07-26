using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IPhanQuyenService
    {
        public List<PhanQuyenModel> getAllPhanQuyen();
        public PhanQuyenModel getPhanQuyenById(string manhomnguoidung);
        public int AddPhanQuyen(PhanQuyenModel model);
        public int Removepq(string manhomnguoidung);
        public int Updatepq(PhanQuyenModel model);
    }
    public class PhanQuyenService : IPhanQuyenService
    {
        private readonly IPhanQuyenRepository pqRepository;
        public PhanQuyenService(IPhanQuyenRepository pqRepository) { this.pqRepository = pqRepository; }
        public List<PhanQuyenModel> getAllPhanQuyen()
        {
            List<PhanQuyenModel> lst = new List<PhanQuyenModel>();
            lst = pqRepository.getAllPhanQuyen();
            return lst;
        }
        public PhanQuyenModel getPhanQuyenById(string manhomnguoidung)
        {
            if (String.IsNullOrEmpty(manhomnguoidung))
            {
                return null;
            }
            return pqRepository.getPhanQuyenById(manhomnguoidung);
        }
        public int AddPhanQuyen(PhanQuyenModel model)
        {
            if (model == null) return 0;
            return pqRepository.AddPhanQuyen(model);
        }
        public int Removepq(string manhomnguoidung)
        {
            if (String.IsNullOrEmpty(manhomnguoidung)) return 0;
            return pqRepository.RemovePhanQuyen(manhomnguoidung);
        }
        public int Updatepq(PhanQuyenModel model)
        {
            if (model == null) return 0;
            return pqRepository.UpdatePhanQuyen(model);
        }
    }
}
