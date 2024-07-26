using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface IDangNhapRepository
    {
        public List<DangNhapModel> getAllDangNhap();
        public DangNhapModel getDangNhapById(string taikhoandn);
        public DangNhapModel getDangNhaptkandmk(string taikhoandn, string matkhau);
        public int AddDangNhap(DangNhapModel model);
        public int RemoveDangNhap(string taikhoandn);
        public int UpdateDangNhap(DangNhapModel model);
        public List<string> GetTaiKhoan();
    }
    public class DangNhapRepository : IDangNhapRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<DangNhapModel> getAllDangNhap()
        {
            string query = "SELECT * FROM DANGNHAP";
            DataTable tbl = con.getDataTable(query);
            List<DangNhapModel> lst = new List<DangNhapModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DangNhapModel kh = new DangNhapModel(
                    tbl.Rows[i][0].ToString(), //taikhoandn
                      tbl.Rows[i][1].ToString()//mk
                                                );
                lst.Add(kh);
            }
            return lst;
        }
        public List<string> GetTaiKhoan()
        {
            string query = "SELECT DISTINCT TAIKHOAN FROM DANGNHAP";
            DataTable tbl = con.getDataTable(query);
            List<string> lst = new List<string>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string taikhoan = tbl.Rows[i][0].ToString();
                lst.Add(taikhoan);
            }
            return lst;
        }
        public DangNhapModel getDangNhapById(string taikhoandn)
        {
            string query = "SELECT * FROM DANGNHAP where TAIKHOAN ='" + taikhoandn + "'";
            DataTable tbl = con.getDataTable(query);

            if (tbl.Rows.Count > 0)
            {
                DangNhapModel kh = new DangNhapModel(
                    tbl.Rows[0][0].ToString(), // taikhoandn
                    tbl.Rows[0][1].ToString() // mk
                );
                return kh;
            }
            else
            {
                return null; // Hoặc thực hiện xử lý thích hợp khi không tìm thấy dữ liệu.
            }
        }
        public DangNhapModel getDangNhaptkandmk(string taikhoandn, string matkhau)
        {
            string query = "SELECT * FROM DANGNHAP WHERE TAIKHOAN = '" + taikhoandn + "' AND MATKHAU = '" + matkhau + "'";
            DataTable tbl = con.getDataTable(query);
            if (tbl.Rows.Count > 0)
            {
                DangNhapModel kh = new DangNhapModel(
                      tbl.Rows[0][0].ToString(), //taikhoandn
                      tbl.Rows[0][1].ToString()//mk
                                                 );
                return kh;
            }
            else
            {
                return null;
            }

                
        }
        public int AddDangNhap(DangNhapModel model)
        {
            try
            {
                string query = "insert into DANGNHAP(TAIKHOAN,MATKHAU) values ('" + model.TAI_KHOAN + "','" + model.TAI_KHOAN + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveDangNhap(string taikhoandn)
        {
            try
            {
                string query = "delete from DANGNHAP where TAIKHOAN ='" + taikhoandn + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateDangNhap(DangNhapModel model)
        {
            try
            {
                string query = "UPDATE DANGNHAP SET MATKHAU = N'" + model.MAT_KHAU + "' WHERE TAIKHOAN = '" + model.TAI_KHOAN + "'";
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
