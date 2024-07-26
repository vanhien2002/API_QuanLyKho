using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;


namespace API_QuanLyKho.Repository
{
    public interface ILoaiSPRepository
    {        
        public List<LoaiSPModel> getAllLoaiSP();
        public LoaiSPModel getLoaiSPById(string maloai);
        public int AddLoaiSP(LoaiSPModel model);
        public int RemoveLoaiSP(string maloai);
        public int UpdateLoaiSP(LoaiSPModel model);
    }
    public class LoaiSPRepository : ILoaiSPRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<LoaiSPModel> getAllLoaiSP()
        {
            string query = "SELECT * FROM LOAISP";
            DataTable tbl = con.getDataTable(query);
            List<LoaiSPModel> lst = new List<LoaiSPModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                LoaiSPModel Lsp = new LoaiSPModel(
                    tbl.Rows[i][0].ToString(), //maloai
                      tbl.Rows[i][1].ToString()//tenLsp
                                                );
                lst.Add(Lsp);
            }
            return lst;
        }
        public LoaiSPModel getLoaiSPById(string maloai)
        {
            string query = "SELECT * FROM LOAISP where MALOAI ='" + maloai + "'";
            DataTable tbl = con.getDataTable(query);
            LoaiSPModel Lsp = new LoaiSPModel(
                     tbl.Rows[0][0].ToString(), //maloai
                       tbl.Rows[0][1].ToString()//tenloai
                                                 );
            return Lsp;
        }
        public int AddLoaiSP(LoaiSPModel model)
        {
            try
            {
                string query = "insert into LOAISP(MALOAI, TENLOAI) values ('" + model.MA_LOAI + "',N'" + model.TEN_LOAI + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveLoaiSP(string maloai)
        {
            try
            {
                string query = "delete from LOAISP where MALOAI ='" + maloai + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateLoaiSP(LoaiSPModel model)
        {
            try
            {
                string query = "UPDATE LOAISP SET TENLOAI = N'" + model.TEN_LOAI + "' WHERE MALOAI = '" + model.MA_LOAI + "'";
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
