using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface IChiTietNHRepository
    {
        public List<ChiTietNHModel> getAllChiTietNH();
        public List<ChiTietNHModel> getChiTietNHById(string maCTNH);
        public int AddChiTietNH(ChiTietNHModel modelCTNH);
        public int RemoveChiTietNH(string maCTNH);
        public int UpdateChiTietNH(ChiTietNHModel modelCTNH);
    }
    public class ChiTietNHRepository: IChiTietNHRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<ChiTietNHModel> getAllChiTietNH()
        {
            string query = "SELECT * FROM CHITIET_NH";
            DataTable tbl = con.getDataTable(query);
            List<ChiTietNHModel> lst = new List<ChiTietNHModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                ChiTietNHModel ctnh = new ChiTietNHModel(
                    tbl.Rows[i][0].ToString(), //maPhieuNhap
                      tbl.Rows[i][1].ToString(),//maSanPham
                      int.Parse(tbl.Rows[i][2].ToString()),//soLuong 
                      int.Parse(tbl.Rows[i][3].ToString()), //thanhTien
                      int.Parse(tbl.Rows[i][4].ToString()) //gia
                                                );
                lst.Add(ctnh);
            }
            return lst;
        }
        public List<ChiTietNHModel> getChiTietNHById(string maCTNH)
        {
            string query = "SELECT * FROM CHITIET_NH where MAPHIEU_NH ='" + maCTNH + "'";
            DataTable tbl = con.getDataTable(query);
            List<ChiTietNHModel> lst = new List<ChiTietNHModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                ChiTietNHModel ctnh = new ChiTietNHModel(
                    tbl.Rows[i][0].ToString(), //maPhieuNhap
                      tbl.Rows[i][1].ToString(),//maSanPham
                      int.Parse(tbl.Rows[i][2].ToString()),//soLuong 
                      int.Parse(tbl.Rows[i][3].ToString()), //thanhTien
                      int.Parse(tbl.Rows[i][4].ToString()) //gia
                                                );
                lst.Add(ctnh);
            }
            return lst;
        }
        public int AddChiTietNH(ChiTietNHModel model)
        {
            try
            {
                string query = "insert into CHITIET_NH(MAPHIEU_NH, MA_SP, SOLUONG,THANHTIEN,GIA) values ('" + model.MaPhieuNH + "','" + model.MaSP + "'," + model.SoLuong + "," + model.ThanhTien + "," + model.Gia + ")";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveChiTietNH(string maCTNH)
        {
            try
            {
                string query = "delete from CHITIET_NH where MAPHIEU_NH ='" + maCTNH + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateChiTietNH(ChiTietNHModel model)
        {
            try
            {
                RemoveChiTietNH(model.MaPhieuNH);
                AddChiTietNH(model);
                return 1;
            }
            catch { return 0; }
        }
    }
}
