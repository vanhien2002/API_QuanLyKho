using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IChucVuService
    {
        public List<ChucVuModel> getAllChucVu();
        public ChucVuModel getChucVuById(string maCV);
        public int AddChucVu(ChucVuModel modelCV);
        public int RemoveChucVu(string maCV);
        public int UpdateChucVu(ChucVuModel modelCV);
    }
    public class ChucVuService:IChucVuService
    {
        private readonly IChucVuRepository ChucVuRepository;
        public ChucVuService(IChucVuRepository ChucVuRepository) { this.ChucVuRepository = ChucVuRepository; }
        public List<ChucVuModel> getAllChucVu()
        {
            List<ChucVuModel> lst = new List<ChucVuModel>();
            lst = ChucVuRepository.getAllChucVu();
            return lst;
        }
        public ChucVuModel getChucVuById(string maCV)
        {
            if (String.IsNullOrEmpty(maCV))
            {
                return null;
            }
            return ChucVuRepository.getChucVuById(maCV);
        }
        public int AddChucVu(ChucVuModel model)
        {
            if (model == null) return 0;
            return ChucVuRepository.AddChucVu(model);
        }
        public int RemoveChucVu(string maCV)
        {
            if (String.IsNullOrEmpty(maCV)) return 0;
            return ChucVuRepository.RemoveChucVu(maCV);
        }
        public int UpdateChucVu(ChucVuModel model)
        {
            if (model == null) return 0;
            return ChucVuRepository.UpdateChucVu(model);
        }
    }
}
