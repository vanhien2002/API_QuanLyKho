namespace API_QuanLyKho.Model
{
    public class TaiKhoanNVModel
    {
        public TaiKhoanNVModel(string TAI_KHOAN, string MA_NV, string MA_NHOM_NGUOI_DUNG, string GHI_CHU)
        {
            this.TAI_KHOAN = TAI_KHOAN;
            this.MA_NV = MA_NV;
            this.MA_NHOM_NGUOI_DUNG = MA_NHOM_NGUOI_DUNG;
            this.GHI_CHU = GHI_CHU;
        }
        public string TAI_KHOAN { get; set; }
        public string MA_NV { get; set; }
        public string MA_NHOM_NGUOI_DUNG { get; set; }
        public string GHI_CHU { get; set; }
    }
}
