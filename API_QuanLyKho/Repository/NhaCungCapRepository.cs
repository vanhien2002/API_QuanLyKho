using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface INhaCungCapRepository
    {
        public List<NhaCungCapModel> getAllNhaCungCap();
        public NhaCungCapModel getNhaCungCapById(string maNCC);
        public NhaCungCapModel getNhaCungCapBySDT(string SDT);
        public int AddNhaCungCap(NhaCungCapModel modelNCC);
        public int RemoveNhaCungCap(string maNCC);
        public int UpdateNhaCungCap(NhaCungCapModel modelNCC);
    }
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<NhaCungCapModel> getAllNhaCungCap()
        {
            string query = "SELECT * FROM NHA_CUNG_CAP";
            DataTable tbl = con.getDataTable(query);
            List<NhaCungCapModel> lst = new List<NhaCungCapModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                NhaCungCapModel ncc = new NhaCungCapModel(
                    tbl.Rows[i][0].ToString(), //maNhaCungCap
                      tbl.Rows[i][1].ToString(), //tenNhaCungCap
                      tbl.Rows[i][2].ToString(), //diaChiNhaCungCap
                      tbl.Rows[i][3].ToString() //sdtNhaCungCap
                                                );
                lst.Add(ncc);
            }
            return lst;
        }
        public NhaCungCapModel getNhaCungCapById(string maNCC)
        {
            string query = "SELECT * FROM NHA_CUNG_CAP where MA_NCC ='" + maNCC + "'";
            DataTable tbl = con.getDataTable(query);

            NhaCungCapModel ncc = new NhaCungCapModel(
                     tbl.Rows[0][0].ToString(), //maNhaCungCap
                      tbl.Rows[0][1].ToString(), //tenNhaCungCap
                      tbl.Rows[0][2].ToString(), //diaChiNhaCungCap
                      tbl.Rows[0][3].ToString() //sdtNhaCungCap
                                                 );
            return ncc;
        }
        public NhaCungCapModel getNhaCungCapBySDT(string SDT)
        {
            string query = "SELECT * FROM NHA_CUNG_CAP where SDT = '" + SDT + "'";
            DataTable tbl = con.getDataTable(query);

            NhaCungCapModel ncc = new NhaCungCapModel(
                     tbl.Rows[0][0].ToString(), //maNhaCungCap
                      tbl.Rows[0][1].ToString(), //tenNhaCungCap
                      tbl.Rows[0][2].ToString(), //diaChiNhaCungCap
                      tbl.Rows[0][3].ToString() //sdtNhaCungCap
                                                 );
            return ncc;
        }
        public int AddNhaCungCap(NhaCungCapModel model)
        {
            try
            {
                string query = "insert into NHA_CUNG_CAP(MA_NCC, TEN_NCC, DIACHI_NCC, SDT) values ('" + model.Ma_NCC + "',N'" + model.Ten_NCC + "',N'" + model.DiaChi_NCC + "', '" + model.SDT + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveNhaCungCap(string maNCC)
        {
            try
            {
                string query = "delete from NHA_CUNG_CAP where MA_NCC ='" + maNCC + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateNhaCungCap(NhaCungCapModel model)
        {
            try
            {
                string query = "UPDATE NHA_CUNG_CAP SET TEN_NCC = N'" + model.Ten_NCC + "', DIACHI_NCC = N'" + model.DiaChi_NCC + "', SDT = '" + model.SDT + "' WHERE MA_NCC = '" + model.Ma_NCC + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
    }
}
