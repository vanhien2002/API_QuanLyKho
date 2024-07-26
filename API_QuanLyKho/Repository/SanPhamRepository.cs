using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;
using System.Net;
using System.Text;

namespace API_QuanLyKho.Repository
{
    public interface ISanPhamRepository
    {
        public List<SanPhamModel> getAllSanPham();
        public SanPhamModel getSanPhamById(string masp);
        public List<SanPhamModel> getSanPhamByNCC(string maNCC);
        public List<SanPhamModel> getSanPhamByKho(string maKho);
        public int AddSanPham(SanPhamModel model);
        public int RemoveSanPham(string masp);
        public int UpdateSanPham(SanPhamModel model);
        public List<ThongKeSpModel> ThongKeSLNhap(DateTime ngaybd, DateTime ngaykt);
        public List<ThongKeSpModel> ThongKeSlBan(DateTime ngaybd, DateTime ngaykt);
        public List<ThongKeSpModel> ThongKeTonKho(DateTime ngaybd, DateTime ngaykt);
        public List<SanPhamModel> ThongKeDate(DateTime ngaybd, DateTime ngaykt);
        public List<string> GetMaSP();
    }
    public class SanPhamRepository : ISanPhamRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<SanPhamModel> getAllSanPham()
        {
            string query = "SELECT * FROM SAN_PHAM";
            DataTable tbl = con.getDataTable(query);
            List<SanPhamModel> lst = new List<SanPhamModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                SanPhamModel Lsp = new SanPhamModel(
                tbl.Rows[i][0].ToString(), // MA_SP
                tbl.Rows[i][1].ToString(), // MA_NCC
                tbl.Rows[i][2].ToString(), // TEN_SP
                Convert.ToDateTime(tbl.Rows[i][3]), // NGAYSX (chuyển đổi thành kiểu DateTime)
                Convert.ToDateTime(tbl.Rows[i][4]), // HSD (chuyển đổi thành kiểu DateTime)
                Convert.ToInt32(tbl.Rows[i][5]), // SOLUONG (chuyển đổi thành kiểu int)
                tbl.Rows[i][6].ToString(), // MA_LOAI
                Convert.ToInt32(tbl.Rows[i][7]), // GIA (chuyển đổi thành kiểu int)
                tbl.Rows[i][8].ToString(), // GHICHU_SP
                tbl.Rows[i][9].ToString(), // MAKHO
                tbl.Rows[i][10] == DBNull.Value ? null : (byte[])tbl.Rows[i][10] // ANH (kiểm tra giá trị null)
                                                );
                lst.Add(Lsp);
            }
            return lst;
        }
        public SanPhamModel getSanPhamById(string masp)
        {
            string query = "SELECT * FROM SAN_PHAM where MA_SP ='" + masp + "'";
            DataTable tbl = con.getDataTable(query);
                SanPhamModel Lsp = new SanPhamModel(
                tbl.Rows[0][0].ToString(), // MA_SP
                tbl.Rows[0][1].ToString(), // MA_NCC
                tbl.Rows[0][2].ToString(), // TEN_SP
                Convert.ToDateTime(tbl.Rows[0][3]), // NGAYSX (chuyển đổi thành kiểu DateTime)
                Convert.ToDateTime(tbl.Rows[0][4]), // HSD (chuyển đổi thành kiểu DateTime)
                Convert.ToInt32(tbl.Rows[0][5]), // SOLUONG (chuyển đổi thành kiểu int)
                tbl.Rows[0][6].ToString(), // MA_LOAI
                Convert.ToInt32(tbl.Rows[0][7]), // GIA (chuyển đổi thành kiểu int)
                tbl.Rows[0][8].ToString(), // GHICHU_SP
                tbl.Rows[0][9].ToString(), // MAKHO
                tbl.Rows[0][10] == DBNull.Value ? null : (byte[])tbl.Rows[0][10] // ANH (chuyển đổi thành kiểu byte[])
                                                 );
            return Lsp;
        }
        public List<SanPhamModel> getSanPhamByNCC(string maNCC)
        {
            string query = "SELECT * FROM SAN_PHAM WHERE MA_NCC = '"+maNCC+"'";
            DataTable tbl = con.getDataTable(query);
            List<SanPhamModel> lst = new List<SanPhamModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                SanPhamModel Lsp = new SanPhamModel(
                tbl.Rows[i][0].ToString(), // MA_SP
                tbl.Rows[i][1].ToString(), // MA_NCC
                tbl.Rows[i][2].ToString(), // TEN_SP
                Convert.ToDateTime(tbl.Rows[i][3]), // NGAYSX (chuyển đổi thành kiểu DateTime)
                Convert.ToDateTime(tbl.Rows[i][4]), // HSD (chuyển đổi thành kiểu DateTime)
                Convert.ToInt32(tbl.Rows[i][5]), // SOLUONG (chuyển đổi thành kiểu int)
                tbl.Rows[i][6].ToString(), // MA_LOAI
                Convert.ToInt32(tbl.Rows[i][7]), // GIA (chuyển đổi thành kiểu int)
                tbl.Rows[i][8].ToString(), // GHICHU_SP
                tbl.Rows[i][9].ToString(), // MAKHO
                tbl.Rows[i][10] == DBNull.Value ? null : (byte[])tbl.Rows[i][10] // ANH (kiểm tra giá trị null)
                                                );
                lst.Add(Lsp);
            }
            return lst;
        }
        public List<SanPhamModel> getSanPhamByKho(string maKho)
        {
            string query = "SELECT * FROM SAN_PHAM WHERE MAKHO = '"+maKho+"'";
            DataTable tbl = con.getDataTable(query);
            List<SanPhamModel> lst = new List<SanPhamModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                SanPhamModel Lsp = new SanPhamModel(
                tbl.Rows[i][0].ToString(), // MA_SP
                tbl.Rows[i][1].ToString(), // MA_NCC
                tbl.Rows[i][2].ToString(), // TEN_SP
                Convert.ToDateTime(tbl.Rows[i][3]), // NGAYSX (chuyển đổi thành kiểu DateTime)
                Convert.ToDateTime(tbl.Rows[i][4]), // HSD (chuyển đổi thành kiểu DateTime)
                Convert.ToInt32(tbl.Rows[i][5]), // SOLUONG (chuyển đổi thành kiểu int)
                tbl.Rows[i][6].ToString(), // MA_LOAI
                Convert.ToInt32(tbl.Rows[i][7]), // GIA (chuyển đổi thành kiểu int)
                tbl.Rows[i][8].ToString(), // GHICHU_SP
                tbl.Rows[i][9].ToString(), // MAKHO
                tbl.Rows[i][10] == DBNull.Value ? null : (byte[])tbl.Rows[i][10] // ANH (kiểm tra giá trị null)
                                                );
                lst.Add(Lsp);
            }
            return lst;
        }
        public string bamByte(byte[] x)
        {
            byte[] bytePic = x;
            string ParamImageStr = "0x" + BitConverter.ToString(bytePic, 0).Replace("-", string.Empty); //New Line
            return ParamImageStr;
        }
        public int AddSanPham(SanPhamModel model)
        {
            try
            {
                string query = "insert into SAN_PHAM (MA_SP, MA_NCC, TEN_SP, NGAYSX, HSD, SOLUONG_SP, MALOAI, GIA, GHICHU_SP, MAKHO, ANH) " +
                "values ('" + model.MA_SP + "', '" + model.MA_NCC + "', N'" + model.TEN_SP + "', '" + model.NGAYSX.ToString("yyyy-MM-dd") + "', '" + model.HSD.ToString("yyyy-MM-dd") + "', " + model.SOLUONG + ", '" + model.MA_LOAI + "', " + model.GIA + ", N'" + model.GHICHU_SP + "', '" + model.MAKHO + "',convert(VARBINARY(max), '" + bamByte(model.ANH) + "', 1))";

                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveSanPham(string masp)
        {
            try
            {
                string query = "delete from SAN_PHAM where MA_SP ='" + masp + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateSanPham(SanPhamModel model)
        {
            try
            {
                RemoveSanPham(model.MA_SP);
                AddSanPham(model);
                return 1;
            }
            catch { return 0; }
        }
        public List<string> GetMaSP()
        {
            string query = "SELECT DISTINCT MA_SP FROM SAN_PHAM";
            DataTable tbl = con.getDataTable(query);
            List<string> lst = new List<string>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string maSP = tbl.Rows[i][0].ToString(); // Lấy mã sản phẩm
                lst.Add(maSP);
            }
            return lst;

        }

        public List<ThongKeSpModel> ThongKeSLNhap(DateTime ngaybd, DateTime ngaykt)
        {
            try
            {
                string query = $@"SELECT SP.MA_SP, SP.MA_NCC, SP.TEN_SP, SP.NGAYSX, SP.HSD, SP.SOLUONG_SP, SP.MALOAI, SP.GIA, SP.GHICHU_SP, SP.MAKHO, SP.ANH, SUM(NH.SOLUONG) AS SoLuongNhap
                 FROM SAN_PHAM SP
                 INNER JOIN CHITIET_NH NH ON SP.MA_SP = NH.MA_SP
                 INNER JOIN PHIEU_NHAP_HANG PNH ON NH.MAPHIEU_NH = PNH.MAPHIEU_NH
                 WHERE PNH.NGAY_NH BETWEEN '{ngaybd.ToString("yyyy-MM-dd")}' AND '{ngaykt.ToString("yyyy-MM-dd")}'
                 GROUP BY SP.MA_SP, SP.MA_NCC, SP.TEN_SP, SP.NGAYSX, SP.HSD, SP.SOLUONG_SP, SP.MALOAI, SP.GIA, SP.GHICHU_SP, SP.MAKHO, SP.ANH
                 ORDER BY SoLuongNhap DESC;";
                DataTable tbl = con.getDataTable(query);
                List<ThongKeSpModel> lst = new List<ThongKeSpModel>();
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    SanPhamModel Lsp = new SanPhamModel(
                        tbl.Rows[i][0].ToString(), // MA_SP
                        tbl.Rows[i][1].ToString(), // MA_NCC
                        tbl.Rows[i][2].ToString(), // TEN_SP
                        Convert.ToDateTime(tbl.Rows[i][3]), // NGAYSX
                        Convert.ToDateTime(tbl.Rows[i][4]), // HSD
                        Convert.ToInt32(tbl.Rows[i][5]), // SOLUONG
                        tbl.Rows[i][6].ToString(), // MA_LOAI
                        Convert.ToInt32(tbl.Rows[i][7]), // GIA
                        tbl.Rows[i][8].ToString(), // GHICHU_SP
                        tbl.Rows[i][9].ToString(), // MAKHO,
                        tbl.Rows[i][10] == DBNull.Value ? null : (byte[])tbl.Rows[i][10] // ANH

                    );
                    int SoLuongNhap = Convert.ToInt32(tbl.Rows[i][11]);
                    lst.Add(new ThongKeSpModel { SanPham = Lsp, SoLuong = SoLuongNhap });
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }
        public List<ThongKeSpModel> ThongKeSlBan(DateTime ngaybd, DateTime ngaykt)
        {
            try
            {
                string query = $@"SELECT SP.MA_SP, SP.MA_NCC, SP.TEN_SP, SP.NGAYSX, SP.HSD, SP.SOLUONG_SP, SP.MALOAI, SP.GIA, SP.GHICHU_SP, SP.MAKHO, SP.ANH, SUM(XH.SOLUONG) AS SoLuongBan
                 FROM SAN_PHAM SP
                 INNER JOIN CHITIET_XH XH ON SP.MA_SP = XH.MA_SP
                 INNER JOIN PHIEU_XUAT_HANG PXH ON XH.MAPH_XH = PXH.MAPH_XH
                 WHERE PXH.NGAY_XH >= '{ngaybd.ToString("yyyy-MM-dd")}' AND PXH.NGAY_XH <= '{ngaykt.ToString("yyyy-MM-dd")}'
                 GROUP BY SP.MA_SP, SP.MA_NCC, SP.TEN_SP, SP.NGAYSX, SP.HSD, SP.SOLUONG_SP, SP.MALOAI, SP.GIA, SP.GHICHU_SP, SP.MAKHO, SP.ANH
                 ORDER BY SoLuongBan DESC;";
                DataTable tbl = con.getDataTable(query);
                List<ThongKeSpModel> lst = new List<ThongKeSpModel>();
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    SanPhamModel Lsp = new SanPhamModel(
                        tbl.Rows[i][0].ToString(), // MA_SP
                        tbl.Rows[i][1].ToString(), // MA_NCC
                        tbl.Rows[i][2].ToString(), // TEN_SP
                        Convert.ToDateTime(tbl.Rows[i][3]), // NGAYSX
                        Convert.ToDateTime(tbl.Rows[i][4]), // HSD
                        Convert.ToInt32(tbl.Rows[i][5]), // SOLUONG
                        tbl.Rows[i][6].ToString(), // MA_LOAI
                        Convert.ToInt32(tbl.Rows[i][7]), // GIA
                        tbl.Rows[i][8].ToString(), // GHICHU_SP
                        tbl.Rows[i][9].ToString(), // MAKHO,
                        tbl.Rows[i][10] == DBNull.Value ? null : (byte[])tbl.Rows[i][10] // ANH

                    );
                    int SoLuongXuat = Convert.ToInt32(tbl.Rows[i][11]);
                    lst.Add(new ThongKeSpModel { SanPham = Lsp, SoLuong = SoLuongXuat });
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }
        public List<ThongKeSpModel> ThongKeTonKho(DateTime ngaybd, DateTime ngaykt)
        {
            try
            {
                string query = $@"SELECT SP.MA_SP, SP.MA_NCC, SP.TEN_SP, SP.NGAYSX, SP.HSD, SP.SOLUONG_SP, SP.MALOAI, SP.GIA, SP.GHICHU_SP, SP.MAKHO, SP.ANH,
                (SP.SOLUONG_SP - ISNULL(TongXuat.SoLuongBan, 0) + ISNULL(TongNhap.SoLuongNhap, 0)) AS SoLuongTonKho
                FROM SAN_PHAM SP
                LEFT JOIN
                (SELECT XH.MA_SP, SUM(XH.SOLUONG) AS SoLuongBan
                FROM CHITIET_XH XH
                INNER JOIN PHIEU_XUAT_HANG PXH ON XH.MAPH_XH = PXH.MAPH_XH
                WHERE PXH.NGAY_XH >= '{ngaybd.ToString("yyyy-MM-dd")}' AND PXH.NGAY_XH <= '{ngaykt.ToString("yyyy-MM-dd")}'
                GROUP BY XH.MA_SP) AS TongXuat ON SP.MA_SP = TongXuat.MA_SP
                LEFT JOIN
                (SELECT NH.MA_SP, SUM(NH.SOLUONG) AS SoLuongNhap
                FROM CHITIET_NH NH
                INNER JOIN PHIEU_NHAP_HANG PNH ON NH.MAPHIEU_NH = PNH.MAPHIEU_NH
                WHERE PNH.NGAY_NH >= '{ngaybd.ToString("yyyy-MM-dd")}' AND PNH.NGAY_NH <= '{ngaykt.ToString("yyyy-MM-dd")}'
                GROUP BY NH.MA_SP) AS TongNhap ON SP.MA_SP = TongNhap.MA_SP
                ORDER BY SoLuongTonKho DESC;";

                DataTable tbl = con.getDataTable(query);
                List<ThongKeSpModel> lst = new List<ThongKeSpModel>();

                foreach (DataRow row in tbl.Rows)
                {
                    SanPhamModel Lsp = new SanPhamModel(
                        row[0].ToString(), // MA_SP
                        row[1].ToString(), // MA_NCC
                        row[2].ToString(), // TEN_SP
                        Convert.ToDateTime(row[3]), // NGAYSX
                        Convert.ToDateTime(row[4]), // HSD
                        Convert.ToInt32(row[5]), // SOLUONG_SP
                        row[6].ToString(), // MA_LOAI
                        Convert.ToInt32(row[7]), // GIA
                        row[8].ToString(), // GHICHU_SP
                        row[9].ToString(), // MAKHO
                        row[10] == DBNull.Value ? null : (byte[])row[10] // ANH
                    );

                    int SoLuongTonKho = Convert.ToInt32(row[11]);
                    lst.Add(new ThongKeSpModel { SanPham = Lsp, SoLuong = SoLuongTonKho });
                }

                return lst;
            }
            catch
            {
                return null;
            }
        }
        public List<SanPhamModel> ThongKeDate(DateTime ngaybd, DateTime ngaykt)
        {
            try
            {
                string query = $@"SELECT SP.MA_SP, SP.MA_NCC, SP.TEN_SP, SP.NGAYSX, SP.HSD, SP.SOLUONG_SP, SP.MALOAI, SP.GIA, SP.GHICHU_SP, SP.MAKHO, SP.ANH
                        FROM SAN_PHAM SP
                        WHERE SP.HSD BETWEEN '{ngaybd.ToString("yyyy-MM-dd")}' AND '{ngaykt.ToString("yyyy-MM-dd")}'";

                DataTable tbl = con.getDataTable(query);
                List<SanPhamModel> lst = new List<SanPhamModel>();

                foreach (DataRow row in tbl.Rows)
                {
                    SanPhamModel Lsp = new SanPhamModel(
                        row[0].ToString(), // MA_SP
                        row[1].ToString(), // MA_NCC
                        row[2].ToString(), // TEN_SP
                        Convert.ToDateTime(row[3]), // NGAYSX (chuyển đổi thành kiểu DateTime)
                        Convert.ToDateTime(row[4]), // HSD (chuyển đổi thành kiểu DateTime)
                        Convert.ToInt32(row[5]), // SOLUONG (chuyển đổi thành kiểu int)
                        row[6].ToString(), // MA_LOAI
                        Convert.ToInt32(row[7]), // GIA (chuyển đổi thành kiểu int)
                        row[8].ToString(), // GHICHU_SP
                        row[9].ToString(), // MAKHO
                        row[10] == DBNull.Value ? null : (byte[])row[10] // ANH (kiểm tra giá trị null)
                    );

                    lst.Add(Lsp);
                }

                return lst;
            }
            catch
            {
                return null;
            }
        }
    }
}
        
