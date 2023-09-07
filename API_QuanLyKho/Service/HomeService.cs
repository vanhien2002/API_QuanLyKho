using API_QuanLyKho.Repository;

namespace API_QuanLyKho.Service
{
    public interface IHomeService
    {
        public string getAll();
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

    }
}
