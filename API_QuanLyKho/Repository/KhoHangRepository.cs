using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;


namespace API_QuanLyKho.Repository
{
    public interface IKhoHangRepository
    {
        public List<KhoHangModel> getAllKhoHang();
        public KhoHangModel getKhoHangById(string makho);
        public int AddKhoHang(KhoHangModel model);
        public int RemoveKhoHang(string makho);
        public int UpdateKhoHang(KhoHangModel model);
    }
    public class KhoHangRepository : IKhoHangRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<KhoHangModel> getAllKhoHang()
        {
            string query = "SELECT * FROM KHO_HANG";
            DataTable tbl = con.getDataTable(query);
            List<KhoHangModel> lst = new List<KhoHangModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                KhoHangModel Lsp = new KhoHangModel(
                    tbl.Rows[i][0].ToString(), //makho
                      tbl.Rows[i][1].ToString(),//tenkho
                       tbl.Rows[i][2].ToString(),//diachi
                        tbl.Rows[i][3].ToString()//ghichu
                                                );
                lst.Add(Lsp);
            }
            return lst;
        }
        public KhoHangModel getKhoHangById(string makho)
        {
            string query = "SELECT * FROM KHO_HANG where MAKHO ='" + makho + "'";
            DataTable tbl = con.getDataTable(query);
            KhoHangModel Lsp = new KhoHangModel(
                       tbl.Rows[0][0].ToString(), //makho
                      tbl.Rows[0][1].ToString(),//tenkho
                       tbl.Rows[0][2].ToString(),//diachi
                        tbl.Rows[0][3].ToString()//ghichu
                                                 );
            return Lsp;
        }
        public int AddKhoHang(KhoHangModel model)
        {
            try
            {
                string query = "insert into KHO_HANG(MAKHO, TENKHO,DIACHI_KHO,GHICHU_KHO) values ('" + model.MA_KHO + "',N'" + model.TEN_KHO + "',N'" + model.DIACHI + "','" + model.GHICHU + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveKhoHang(string makho)
        {
            try
            {
                string query = "delete from KHO_HANG where MAKHO ='" + makho + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateKhoHang(KhoHangModel model)
        {
            try
            {
                string query = "UPDATE KHO_HANG SET TENKHO = N'" + model.TEN_KHO + "', DIACHI_KHO = N'" + model.DIACHI + "', GHICHU_KHO = '" + model.GHICHU + "' WHERE MAKHO = '" + model.MA_KHO + "'";
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
