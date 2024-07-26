namespace API_QuanLyKho.Model
{
    public class DangNhapModel
    {
        public DangNhapModel(string TAI_KHOAN, string MAT_KHAU)
        {
            this.TAI_KHOAN = TAI_KHOAN;
            this.MAT_KHAU = MAT_KHAU;

        }
        public string TAI_KHOAN { get; set; }
        public string MAT_KHAU { get; set; }
    }
}
