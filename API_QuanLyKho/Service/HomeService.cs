using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IHomeService
    {
        public string getAll();
        public void getById(int id) { }
        public void add() { }
        public void remove() { }
        public void update() { }
    }
    public class HomeService:IHomeService
    {
        IHomeRepository repository;
        public HomeService( IHomeRepository homeRepository)
        {
            repository = homeRepository;
        }
        public string getAll()
        {
            return repository.getAll();
        }
        public void getById(int id) { }
        public void add() { }
        public void remove() { }
        public void update() { }

    }
}
