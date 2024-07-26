namespace API_QuanLyKho.Model
{
    public class PhieuXuatHangModel
    {
        public PhieuXuatHangModel(string MAPH_XH, string NGAY_XH, string MAKH, string TONGTIEN_XH, string MANV, int TrangThai) {
            this.MAPH_XH = MAPH_XH;
            this.NGAY_XH = NGAY_XH;
            this.MAKH = MAKH;
            this.TONGTIEN_XH = TONGTIEN_XH;
            this.MANV = MANV;
            this.TRANGTHAI = TrangThai;
        }
        public string MAPH_XH { get; set; }
        public string NGAY_XH { get; set; }
        public string MAKH { get; set; }
        public string TONGTIEN_XH { get; set; }
        public string MANV { get; set; }    
        public int TRANGTHAI { get; set; }
    }
}
