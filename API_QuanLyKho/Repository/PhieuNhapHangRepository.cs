using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;
using System.Security;

namespace API_QuanLyKho.Repository
{
    public interface IPhieuNhapHangRepository
    {
        public List<PhieuNhapHangModel> getAllPhieuNhapHang();
        public PhieuNhapHangModel getPhieuNhapHangById(string maPNH);
        public int AddPhieuNhapHang(PhieuNhapHangModel modelPNH);
        public int RemovePhieuNhapHang(string maPNH);
        public int UpdatePhieuNhapHang(PhieuNhapHangModel modelPNH);
        public List<PhieuNhapHangModel> getAllPhieuNhapHangSoNgay(int soNgay);
    }
    public class PhieuNhapHangRepository:IPhieuNhapHangRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<PhieuNhapHangModel> getAllPhieuNhapHang()
        {
            string query = "SELECT * FROM PHIEU_NHAP_HANG";
            DataTable tbl = con.getDataTable(query);
            List<PhieuNhapHangModel> lst = new List<PhieuNhapHangModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                PhieuNhapHangModel pnh = new PhieuNhapHangModel(
                    tbl.Rows[i][0].ToString(), //maPhieuNH
                      tbl.Rows[i][1].ToString(), //ngayNH
                      int.Parse(tbl.Rows[i][2].ToString()), //tongTienNH
                      tbl.Rows[i][3].ToString() //maNV
                                                );
                lst.Add(pnh);
            }
            return lst;
        }
        public PhieuNhapHangModel getPhieuNhapHangById(string maPNH)
        {
            string query = "SELECT * FROM PHIEU_NHAP_HANG where MAPHIEU_NH ='" + maPNH + "'";
            DataTable tbl = con.getDataTable(query);
            PhieuNhapHangModel pnh = new PhieuNhapHangModel(
                    tbl.Rows[0][0].ToString(), //maPhieuNH
                      tbl.Rows[0][1].ToString(), //ngayNH
                      int.Parse(tbl.Rows[0][2].ToString()), //tongTienNH
                      tbl.Rows[0][3].ToString() //maNV
                                                 );
            return pnh;
        }
        public int AddPhieuNhapHang(PhieuNhapHangModel model)
        {
            try
            {
                string query = "insert into PHIEU_NHAP_HANG(MAPHIEU_NH, NGAY_NH, TONGTIEN_NH, MANV) values ('" + model.MaPhieuNhap + "', '" + model.NgayNhap + "', " + model.TongTien + ", '" + model.MaNhanVien + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemovePhieuNhapHang(string maPNH)
        {
            try
            {
                string query = "delete from PHIEU_NHAP_HANG where MAPHIEU_NH ='" + maPNH + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdatePhieuNhapHang(PhieuNhapHangModel model)
        {
            try
            {
                RemovePhieuNhapHang(model.MaPhieuNhap);
                AddPhieuNhapHang(model);
                return 1;
            }
            catch { return 0; }
        }
        public List<PhieuNhapHangModel> getAllPhieuNhapHangSoNgay(int soNgay)
        {
            string query = "SELECT * FROM PHIEU_NHAP_HANG WHERE NGAY_NH >= DATEADD(day, -"+soNgay+", GETDATE()) AND NGAY_NH <= GETDATE();";
            DataTable tbl = con.getDataTable(query);
            List<PhieuNhapHangModel> lst = new List<PhieuNhapHangModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                PhieuNhapHangModel pnh = new PhieuNhapHangModel(
                    tbl.Rows[i][0].ToString(), //maPhieuNH
                      tbl.Rows[i][1].ToString(), //ngayNH
                      int.Parse(tbl.Rows[i][2].ToString()), //tongTienNH
                      tbl.Rows[i][3].ToString() //maNV
                                                );
                lst.Add(pnh);
            }
            return lst;
        }
    }
}
