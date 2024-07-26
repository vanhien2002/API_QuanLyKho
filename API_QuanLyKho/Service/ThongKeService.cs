using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IThongKeService
    {
        public List<TK_NhapHangModel> getDoanhThuNhapHang(DateTime ngayBD, DateTime ngayKT);
        public List<TK_XuatHangModel> getDoanhThuXuatHang(DateTime ngayBD, DateTime ngayKT);
    }
    public class ThongKeService:IThongKeService
    {
        IThongKeRepository _repository;
        public ThongKeService(IThongKeRepository repository)
        {
            this._repository = repository;
        }
        public List<TK_NhapHangModel> getDoanhThuNhapHang(DateTime ngayBD, DateTime ngayKT)
        {
            return _repository.getDoanhThuNhapHang(ngayBD, ngayKT);
        }
        public List<TK_XuatHangModel> getDoanhThuXuatHang(DateTime ngayBD, DateTime ngayKT)
        {
            return _repository.getDoanhThuXuatHang(ngayBD, ngayKT);
        }
    }
}
