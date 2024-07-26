using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IPhieuNhapHangService
    {
        public List<PhieuNhapHangModel> getAllPhieuNhapHang();
        public PhieuNhapHangModel getPhieuNhapHangById(string maCTNH);
        public int AddPhieuNhapHang(PhieuNhapHangModel modelCTNH);
        public int RemovePhieuNhapHang(string maCTNH);
        public int UpdatePhieuNhapHang(PhieuNhapHangModel modelCTNH);
        public List<PhieuNhapHangModel> getAllPhieuNhapHangSoNgay(int soNgay);
    }
    public class PhieuNhapHangService:IPhieuNhapHangService
    {
        private readonly IPhieuNhapHangRepository PhieuNhapHangRepository;
        public PhieuNhapHangService(IPhieuNhapHangRepository PhieuNhapHangRepository) { this.PhieuNhapHangRepository = PhieuNhapHangRepository; }
        public List<PhieuNhapHangModel> getAllPhieuNhapHang()
        {
            List<PhieuNhapHangModel> lst = new List<PhieuNhapHangModel>();
            lst = PhieuNhapHangRepository.getAllPhieuNhapHang();
            return lst;
        }
        public PhieuNhapHangModel getPhieuNhapHangById(string maPNH)
        {
            if (String.IsNullOrEmpty(maPNH))
            {
                return null;
            }
            return PhieuNhapHangRepository.getPhieuNhapHangById(maPNH);
        }
        public int AddPhieuNhapHang(PhieuNhapHangModel model)
        {
            if (model == null) return 0;
            return PhieuNhapHangRepository.AddPhieuNhapHang(model);
        }
        public int RemovePhieuNhapHang(string maPNH)
        {
            if (String.IsNullOrEmpty(maPNH)) return 0;
            return PhieuNhapHangRepository.RemovePhieuNhapHang(maPNH);
        }
        public int UpdatePhieuNhapHang(PhieuNhapHangModel model)
        {
            if (model == null) return 0;
            return PhieuNhapHangRepository.UpdatePhieuNhapHang(model);
        }

        public List<PhieuNhapHangModel> getAllPhieuNhapHangSoNgay(int soNgay)
        {
            if (soNgay <= 0) { return null; }
            return PhieuNhapHangRepository.getAllPhieuNhapHangSoNgay(soNgay);
        }
    }
}
