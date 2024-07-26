using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IPhieuXuatHangService
    {
        public List<PhieuXuatHangModel> getAllPhieuXuatHang();
        public PhieuXuatHangModel getPhieuXuatHangById(string maPhieu);
        public int AddPhieuXuatHang(PhieuXuatHangModel model);
        public int RemovePhieuXuatHang(string maphieuxuat);
        public int UpdatePhieuXuatHang(PhieuXuatHangModel model);
        public List<PhieuXuatHangModel> getPhieuThongKeSoNgay(int soNgay);
    }
    public class PhieuXuatHangService:IPhieuXuatHangService
    {
        private readonly IPhieuXuatHangRepository repository;     
        public PhieuXuatHangService(IPhieuXuatHangRepository phieuXuatHangRepository)
        {
            this.repository = phieuXuatHangRepository;
        }
        public List<PhieuXuatHangModel> getPhieuThongKeSoNgay(int soNgay)
        {
            List<PhieuXuatHangModel> lst = new List<PhieuXuatHangModel>();
            lst = repository.getPhieuThongKeSoNgay(soNgay);
            return lst;
        }
        public List<PhieuXuatHangModel> getAllPhieuXuatHang()
        {
            List<PhieuXuatHangModel> lst = new List<PhieuXuatHangModel>();
            lst = repository.getAllPhieuXuatHang();
            return lst;
        }
        public PhieuXuatHangModel getPhieuXuatHangById(string maPhieu)
        {
            if (String.IsNullOrEmpty(maPhieu))
            {
                return null;
            }
            return repository.getPhieuXuatHangById(maPhieu);
        }
        public int AddPhieuXuatHang(PhieuXuatHangModel model)
        {
            if (model == null) return 0;
            return repository.AddPhieuXuatHang(model);
        }
        public int RemovePhieuXuatHang(string maphieuxuat)
        {
            if (String.IsNullOrEmpty(maphieuxuat)) return 0;
             return repository.RemovePhieuXuatHang(maphieuxuat);
        }
        public int UpdatePhieuXuatHang(PhieuXuatHangModel model)
        {
            if(model == null) return 0;
            return repository.UpdatePhieuXuatHang(model);
        }
    }
}
