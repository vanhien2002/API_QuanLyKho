namespace API_QuanLyKho.Model
{
    public class PhieuNhapHangModel
    {
        public PhieuNhapHangModel(string MaPhieuNhap, string NgayNhap, int TongTien, string MaNhanVien) 
        {
            this.MaPhieuNhap = MaPhieuNhap;
            this.NgayNhap = NgayNhap;
            this.TongTien = TongTien;
            this.MaNhanVien = MaNhanVien;
        }
        public string MaPhieuNhap {  get; set; }
        public string NgayNhap {  get; set; }
        public int TongTien {  get; set; }
        public string MaNhanVien {  get; set; }
    }
}
