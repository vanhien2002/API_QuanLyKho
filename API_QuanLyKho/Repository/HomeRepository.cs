namespace API_QuanLyKho.Repository
{
    public interface IHomeRepository
    {
        public string getAll();
    }
    public class HomeRepository:IHomeRepository
    {
        public string getAll()
        {
            return "getAll Thành công";
        }
    }
}
