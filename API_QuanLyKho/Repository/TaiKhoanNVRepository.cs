using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface ITaiKhoanNVRepository
    {
        public List<TaiKhoanNVModel> getAllTaiKhoanNV();
        public TaiKhoanNVModel getTaiKhoanNVById(string taikhoan);
        public int AddTaiKhoanNV(TaiKhoanNVModel model);
        public int RemoveTaiKhoanNV(string taikhoan);
        public int UpdateTaiKhoanNV(TaiKhoanNVModel model);
    }
    public class TaiKhoanNVRepository : ITaiKhoanNVRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<TaiKhoanNVModel> getAllTaiKhoanNV()
        {
            string query = "SELECT * FROM TAIKHOAN_NV";
            DataTable tbl = con.getDataTable(query);
            List<TaiKhoanNVModel> lst = new List<TaiKhoanNVModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                TaiKhoanNVModel kh = new TaiKhoanNVModel(
                    tbl.Rows[i][0].ToString(), //taikhoan
                      tbl.Rows[i][1].ToString(),//manv
                      tbl.Rows[i][2].ToString(),//manhomngdung
                      tbl.Rows[i][3].ToString() //ghichu
                                                );
                lst.Add(kh);
            }
            return lst;
        }
        public TaiKhoanNVModel getTaiKhoanNVById(string taikhoan)
        {
            string query = "SELECT * FROM TAIKHOAN_NV where TAIKHOAN ='" + taikhoan + "'";
            DataTable tbl = con.getDataTable(query);

            TaiKhoanNVModel kh = new TaiKhoanNVModel(
                      tbl.Rows[0][0].ToString(), //taikhoan
                      tbl.Rows[0][1].ToString(),//manv
                      tbl.Rows[0][2].ToString(),//manhomngdung
                      tbl.Rows[0][3].ToString() //ghichu
                                                 );
            return kh;
        }
        public int AddTaiKhoanNV(TaiKhoanNVModel model)
        {
            try
            {
                string query = "insert into TAIKHOAN_NV(TAIKHOAN,MANV,MANHOMNGUOIDUNG,GHICHU) values ('" + model.TAI_KHOAN + "','" + model.MA_NV + "','" + model.MA_NHOM_NGUOI_DUNG + "',N'" + model.GHI_CHU  + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveTaiKhoanNV(string taikhoan)
        {
            try
            {
                string query = "delete from TAIKHOAN_NV where TAIKHOAN ='" + taikhoan + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateTaiKhoanNV(TaiKhoanNVModel model)
        {
            try
            {
                RemoveTaiKhoanNV(model.TAI_KHOAN);
                AddTaiKhoanNV(model);
                return 1;
            }
            catch { return 0; }
        }
    }
}
