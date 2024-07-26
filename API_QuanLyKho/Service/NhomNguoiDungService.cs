using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface INhomNguoiDungService
    {
        public List<NhomNguoiDungModel> getAllNhomNguoiDung();
        public NhomNguoiDungModel getNhomNguoiDungById(string manhom);
        public int AddNhomNguoiDung(NhomNguoiDungModel model);
        public int Removenh(string manhom);
        public int Updatenh(NhomNguoiDungModel model);
        public List<string> GetMaNhom();
    }
    public class NhomNguoiDungService : INhomNguoiDungService
    {
        private readonly INhomNguoiDungRepository nhRepository;
        public NhomNguoiDungService(INhomNguoiDungRepository nhRepository) { this.nhRepository = nhRepository; }
        public List<NhomNguoiDungModel> getAllNhomNguoiDung()
        {
            List<NhomNguoiDungModel> lst = new List<NhomNguoiDungModel>();
            lst = nhRepository.getAllNhomNguoiDung();
            return lst;
        }
        public List<string> GetMaNhom()
        {
            List<string> lst = new List<string>();
            lst = nhRepository.GetMaNhom();
            return lst;
        }
        public NhomNguoiDungModel getNhomNguoiDungById(string manhom)
        {
            if (String.IsNullOrEmpty(manhom))
            {
                return null;
            }
            return nhRepository.getNhomNguoiDungById(manhom);
        }
        public int AddNhomNguoiDung(NhomNguoiDungModel model)
        {
            if (model == null) return 0;
            return nhRepository.AddNhomNguoiDung(model);
        }
        public int Removenh(string manhom)
        {
            if (String.IsNullOrEmpty(manhom)) return 0;
            return nhRepository.RemoveNhomNguoiDung(manhom);
        }
        public int Updatenh(NhomNguoiDungModel model)
        {
            if (model == null) return 0;
            return nhRepository.UpdateNhomNguoiDung(model);
        }
    }
}
