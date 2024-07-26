namespace API_QuanLyKho.Model
{
    public class NhanVienModel
    {
        public NhanVienModel(string MaNhanVien, string TenNhanVien, string Email, string NgaySinh, string GioiTinh, string SDT,
            string DiaChi, int Luong, string BoPhan, string MaChucVu) 
        {
            this.MaNhanVien = MaNhanVien;
            this.TenNhanVien = TenNhanVien;
            this.Email = Email;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.SDT = SDT;
            this.DiaChi = DiaChi;
            this.Luong = Luong;
            this.BoPhan = BoPhan;
            this.MaChucVu = MaChucVu;
        }
        public string MaNhanVien {  get; set; }
        public string TenNhanVien { get; set; }
        public string Email { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT {  get; set; }
        public string DiaChi { get; set; }
        public int Luong { get; set; }
        public string BoPhan { get; set; }
        public string MaChucVu {  get; set; }
    }
}
