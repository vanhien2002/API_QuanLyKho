using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface INhanVienRepository
    {
        public List<NhanVienModel> getAllNhanVien();
        public NhanVienModel getNhanVienById(string maNV);
        public NhanVienModel getNhanVienBySdt(string sdt);
        public int AddNhanVien(NhanVienModel modelNV);
        public int RemoveNhanVien(string maNV);
        public int UpdateNhanVien(NhanVienModel modelNV, string maNV);
        public List<string> GetMaNhanVien();
    }
    public class NhanVienRepository:INhanVienRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<NhanVienModel> getAllNhanVien()
        {
            string query = "SELECT * FROM NHAN_VIEN";
            DataTable tbl = con.getDataTable(query);
            List<NhanVienModel> lst = new List<NhanVienModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                NhanVienModel nv = new NhanVienModel(
                    tbl.Rows[i][0].ToString(), //maNhanVien
                      tbl.Rows[i][1].ToString(), //tenNhanVien
                      tbl.Rows[i][2].ToString(), //mailNhanVien
                      tbl.Rows[i][3].ToString(), //ngaySinh
                      tbl.Rows[i][4].ToString(), //gioiTinh
                      tbl.Rows[i][5].ToString(), //sdt
                      tbl.Rows[i][6].ToString(), //diaChi
                      int.Parse(tbl.Rows[i][7].ToString()), //luong
                      tbl.Rows[i][8].ToString(), //boPhan
                      tbl.Rows[i][9].ToString() //chucVu
                                                );
                lst.Add(nv);
            }
            return lst;
        }
        public NhanVienModel getNhanVienById(string maNV)
        {
            try
            {
                string query = "SELECT * FROM NHAN_VIEN where MANV ='" + maNV + "'";
                DataTable tbl = con.getDataTable(query);
                NhanVienModel nv = new NhanVienModel(
                        tbl.Rows[0][0].ToString(), //maNhanVien
                          tbl.Rows[0][1].ToString(), //tenNhanVien
                          tbl.Rows[0][2].ToString(), //mailNhanVien
                          tbl.Rows[0][3].ToString(), //ngaySinh
                          tbl.Rows[0][4].ToString(), //gioiTinh
                          tbl.Rows[0][5].ToString(), //sdt
                          tbl.Rows[0][6].ToString(), //diaChi
                          int.Parse(tbl.Rows[0][7].ToString()), //luong
                          tbl.Rows[0][8].ToString(), //boPhan
                          tbl.Rows[0][9].ToString() //chucVu
                                                     );
                return nv;
            }
            catch
            {
                return null;
            }
        }
        public NhanVienModel getNhanVienBySdt(string sdt)
        {
            string query = "SELECT * FROM NHAN_VIEN where SDT_NV ='" + sdt + "'";
            DataTable tbl = con.getDataTable(query);
            NhanVienModel nv = new NhanVienModel(
                    tbl.Rows[0][0].ToString(), //maNhanVien
                      tbl.Rows[0][1].ToString(), //tenNhanVien
                      tbl.Rows[0][2].ToString(), //mailNhanVien
                      tbl.Rows[0][3].ToString(), //ngaySinh
                      tbl.Rows[0][4].ToString(), //gioiTinh
                      tbl.Rows[0][5].ToString(), //sdt
                      tbl.Rows[0][6].ToString(), //diaChi
                      int.Parse(tbl.Rows[0][7].ToString()), //luong
                      tbl.Rows[0][8].ToString(), //boPhan
                      tbl.Rows[0][9].ToString() //chucVu
                                                 );
            return nv;
        }
        public int AddNhanVien(NhanVienModel model)
        {
            try
            {
                string query = "insert into NHAN_VIEN(MANV, TEN_NV, EMAIL_NV, NGSINH_NV, GIOITINH_NV, SDT_NV, DIACHI_NV, LUONG_NV, BOPHAN_NV, MACHUCVU) values ('"+model.MaNhanVien+"', N'"+model.TenNhanVien+"', '"+model.Email+"', '"+model.NgaySinh+"', N'"+model.GioiTinh+"', '"+model.SDT+"', N'"+ model.DiaChi+"', "+model.Luong+", N'"+model.BoPhan+"', '"+model.MaChucVu+"')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveNhanVien(string maNV)
        {
            try
            {
                string query = "delete from NHAN_VIEN where MANV ='" + maNV + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateNhanVien(NhanVienModel model, string maNV)
        {
            try
            {
                string query = "update NHAN_VIEN set TEN_NV = N'"+model.TenNhanVien+"', EMAIL_NV = '"+model.Email+"', NGSINH_NV = '"+model.NgaySinh+"', GIOITINH_NV = N'"+model.GioiTinh+"', SDT_NV = '"+model.SDT+"', DIACHI_NV = N'"+model.DiaChi+"', LUONG_NV = "+model.Luong+", BOPHAN_NV = N'"+model.BoPhan+"', MACHUCVU = '"+model.MaChucVu+"'where MANV = '"+ maNV + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public List<string> GetMaNhanVien()
        {
            string query = "SELECT DISTINCT MANV FROM NHAN_VIEN";
            DataTable tbl = con.getDataTable(query);
            List<string> lst = new List<string>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string manv = tbl.Rows[i][0].ToString();
                lst.Add(manv);
            }
            return lst;
        }
    }
}
