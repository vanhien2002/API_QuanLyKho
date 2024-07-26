using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;
using static API_QuanLyKho.Repository.AIRepository;

namespace API_QuanLyKho.Repository
{
    public interface IAIRepository
    {
        public List<AIModel> getAllDataAI();
    }
    public class AIRepository : IAIRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<AIModel> getAllDataAI()
        {
            string query = "SELECT * FROM AI_LEARN";
            DataTable tbl = con.getDataTable(query);
            List<AIModel> lst = new List<AIModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                AIModel ai = new AIModel(
                    tbl.Rows[i][0].ToString(), //maPhieuNhap
                      tbl.Rows[i][1].ToString(),//maSanPham
                      tbl.Rows[i][2].ToString(),//soLuong 
                      tbl.Rows[i][3].ToString() //thanhTien
                                                );
                lst.Add(ai);
            }
            return lst;
        }
    }
}
