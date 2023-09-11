namespace API_QuanLyKho.Repository
{
    public interface IHomeRepository
    {
        public string getAll();
        public void getById(int id) { }
        public void add() { }
        public void remove() { }
        public void update() { }
    }
    public class HomeRepository : IHomeRepository
    {
        public string getAll()
        {
            return "getAll Thành công";
        }
        public void getById(int id) { }
        public void add() { }
        public void remove() { }
        public void update() { }
    }
}
