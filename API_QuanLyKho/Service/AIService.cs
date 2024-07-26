using API_QuanLyKho.Model;
using API_QuanLyKho.Repository;
using static API_QuanLyKho.Repository.AIRepository;

namespace API_QuanLyKho.Service
{
    public interface IAIService
    {
        public List<AIModel> getAllDataAI();
    }
    public class AIService : IAIService
    {
        private readonly IAIRepository AIRepository;
        public AIService(IAIRepository AIRepository) { this.AIRepository = AIRepository; }
        public List<AIModel> getAllDataAI()
        {
            List<AIModel> lst = new List<AIModel>();
            lst = AIRepository.getAllDataAI();
            return lst;
        }
    } 
}
