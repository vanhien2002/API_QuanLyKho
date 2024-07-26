using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface INhaCungCapService
    {
        public List<NhaCungCapModel> getAllNhaCungCap();
        public NhaCungCapModel getNhaCungCapById(string maCTNH);
        public NhaCungCapModel getNhaCungCapBySDT(string SDT);
        public int AddNhaCungCap(NhaCungCapModel modelCTNH);
        public int RemoveNhaCungCap(string maCTNH);
        public int UpdateNhaCungCap(NhaCungCapModel modelCTNH);
    }
    public class NhaCungCapService:INhaCungCapService
    {
        private readonly INhaCungCapRepository NhaCungCapRepository;
        public NhaCungCapService(INhaCungCapRepository NhaCungCapRepository) { this.NhaCungCapRepository = NhaCungCapRepository; }
        public List<NhaCungCapModel> getAllNhaCungCap()
        {
            List<NhaCungCapModel> lst = new List<NhaCungCapModel>();
            lst = NhaCungCapRepository.getAllNhaCungCap();
            return lst;
        }
        public NhaCungCapModel getNhaCungCapById(string maNCC)
        {
            if (String.IsNullOrEmpty(maNCC))
            {
                return null;
            }
            return NhaCungCapRepository.getNhaCungCapById(maNCC);
        }
        public NhaCungCapModel getNhaCungCapBySDT(string SDT)
        {
            if (String.IsNullOrEmpty(SDT))
            {
                return null;
            }
            return NhaCungCapRepository.getNhaCungCapBySDT(SDT);
        }
        public int AddNhaCungCap(NhaCungCapModel model)
        {
            if (model == null) return 0;
            return NhaCungCapRepository.AddNhaCungCap(model);
        }
        public int RemoveNhaCungCap(string maNCC)
        {
            if (String.IsNullOrEmpty(maNCC)) return 0;
            return NhaCungCapRepository.RemoveNhaCungCap(maNCC);
        }
        public int UpdateNhaCungCap(NhaCungCapModel model)
        {
            if (model == null) return 0;
            return NhaCungCapRepository.UpdateNhaCungCap(model);
        }
    }
}
