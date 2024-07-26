using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;


namespace API_QuanLyKho.Repository
{
    public interface IKhuRepository
    {
        public List<KhuModel> getAllKhu();
        public KhuModel getKhuById(string makhu);
        public int AddKhu(KhuModel model);
        public int RemoveKhu(string makhu);
        public int UpdateKhu(KhuModel model);
        public List<string> GetMaKhu();
    }
    public class KhuRepository : IKhuRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<KhuModel> getAllKhu()
        {
            string query = "SELECT * FROM KHU";
            DataTable tbl = con.getDataTable(query);
            List<KhuModel> lst = new List<KhuModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                KhuModel Lsp = new KhuModel(
                    tbl.Rows[i][0].ToString(), //makhu
                      tbl.Rows[i][1].ToString()//tenkhu
                                                );
                lst.Add(Lsp);
            }
            return lst;
        }
        public List<string> GetMaKhu()
        {
            string query = "SELECT DISTINCT MAKHU FROM KHU";
            DataTable tbl = con.getDataTable(query);
            List<string> lst = new List<string>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string makhu = tbl.Rows[i][0].ToString(); // Lấy mã KHU
                lst.Add(makhu);
            }
            return lst;
        }
        public KhuModel getKhuById(string makhu)
        {
            string query = "SELECT * FROM KHU where MAKHU ='" + makhu + "'";
            DataTable tbl = con.getDataTable(query);
            KhuModel Lsp = new KhuModel(
                     tbl.Rows[0][0].ToString(), //makhu
                       tbl.Rows[0][1].ToString()//tenkhu
                                                 );
            return Lsp;
        }
        public int AddKhu(KhuModel model)
        {
            try
            {
                string query = "insert into KHU(MAKHU, TENKHU) values ('" + model.MA_KHU + "',N'" + model.TEN_KHU + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveKhu(string makhu)
        {
            try
            {
                string query = "delete from KHU where MAKHU ='" + makhu + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateKhu(KhuModel model)
        {
            try
            {
                string query = "UPDATE KHU SET TENKHU = N'" + model.TEN_KHU + "' WHERE MAKHU = '" + model.MA_KHU + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
