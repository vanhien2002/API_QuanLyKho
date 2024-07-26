using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;
using static API_QuanLyKho.Hepper.WebEndpoint;

namespace API_QuanLyKho.Repository
{
    public interface IThongKeRepository
    {
        public List<TK_NhapHangModel> getDoanhThuNhapHang(DateTime ngayBD, DateTime ngayKT);
        public List<TK_XuatHangModel> getDoanhThuXuatHang(DateTime ngayBD, DateTime ngayKT);
    }
    public class ThongKeRepository:IThongKeRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<TK_NhapHangModel> getDoanhThuNhapHang(DateTime ngayBD, DateTime ngayKT)
        {
            List<TK_NhapHangModel> listResult = new List<TK_NhapHangModel>();
            string query = "SELECT PHIEU_NHAP_HANG.MAPHIEU_NH, PHIEU_NHAP_HANG.NGAY_NH, LOAISP.MALOAI, SAN_PHAM.MA_SP, SAN_PHAM.TEN_SP, CHITIET_NH.SOLUONG, CHITIET_NH.THANHTIEN FROM SAN_PHAM, LOAISP, CHITIET_NH, PHIEU_NHAP_HANG WHERE SAN_PHAM.MALOAI = LOAISP.MALOAI AND CHITIET_NH.MA_SP=SAN_PHAM.MA_SP AND PHIEU_NHAP_HANG.MAPHIEU_NH= CHITIET_NH.MAPHIEU_NH AND CONVERT(DATE, PHIEU_NHAP_HANG.NGAY_NH, 103) BETWEEN '"+ngayBD+"' AND '"+ngayKT+"';";
            DataTable tbl = con.getDataTable(query);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                TK_NhapHangModel tk = new TK_NhapHangModel();
                tk.MAPHIEU_NH = tbl.Rows[i][0].ToString();
                tk.NGAY_NH =DateTime.Parse( tbl.Rows[i][1].ToString());
                tk.MALOAI = tbl.Rows[i][2].ToString();
                tk.MA_SP = tbl.Rows[i][3].ToString();
                tk.TEN_SP = tbl.Rows[i][4].ToString();
                tk.SOLUONG =int.Parse( tbl.Rows[i][5].ToString());
                tk.THANHTIEN =double.Parse( tbl.Rows[i][6].ToString());
                listResult.Add(tk);
            }
            return listResult;
        }
        public List<TK_XuatHangModel> getDoanhThuXuatHang(DateTime ngayBD, DateTime ngayKT)
        {
            List<TK_XuatHangModel> result = new List<TK_XuatHangModel>();
            string ngaybd = ngayBD.ToString("yyyy/MM/dd");
            string ngaykt = ngayKT.ToString("yyyy/MM/dd");
            string query = "SELECT PHIEU_XUAT_HANG.MAPH_XH, PHIEU_XUAT_HANG.NGAY_XH, LOAISP.MALOAI, SAN_PHAM.MA_SP, SAN_PHAM.TEN_SP, CHITIET_XH.SOLUONG, CHITIET_XH.THANHTIEN FROM SAN_PHAM, LOAISP, CHITIET_XH, PHIEU_XUAT_HANG WHERE SAN_PHAM.MALOAI = LOAISP.MALOAI AND CHITIET_XH.MA_SP = SAN_PHAM.MA_SP AND PHIEU_XUAT_HANG.MAPH_XH = CHITIET_XH.MAPH_XH  AND CONVERT(DATE, PHIEU_XUAT_HANG.NGAY_XH) BETWEEN '"+ngaybd+"' AND '"+ngaykt+"'";
            DataTable tbl = con.getDataTable(query);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                TK_XuatHangModel tk = new TK_XuatHangModel();
                tk.MAPH_XH = tbl.Rows[i][0].ToString();
                tk.NGAY_XH = DateTime.Parse(tbl.Rows[i][1].ToString());
                tk.MALOAI = tbl.Rows[i][2].ToString();
                tk.MA_SP = tbl.Rows[i][3].ToString();
                tk.TEN_SP = tbl.Rows[i][4].ToString();
                tk.SOLUONG = int.Parse(tbl.Rows[i][5].ToString());
                tk.THANHTIEN = double.Parse(tbl.Rows[i][6].ToString());
                result.Add(tk);
            }
            return result;
        }
    }
}