namespace API_QuanLyKho.Model
{
    public class KhachHangModel
    {
        public  KhachHangModel(string MAKH, string TEN_KH, string DIACHI_KH, string GIOITINH_KH, string SDT_KH, string EMAIL_KH, string FAX )
        {
            this.MAKH = MAKH;
            this.TEN_KH = TEN_KH;
            this.DIACHI_KH = DIACHI_KH;
            this.GIOITINH_KH = GIOITINH_KH;
            this.SDT_KH = SDT_KH;
            this.EMAIL_KH = EMAIL_KH;
            this.FAX = FAX;
        }
        public string MAKH { get; set; }
        public string TEN_KH { get; set; }
        public string DIACHI_KH { get; set; }
        public string GIOITINH_KH { get; set; }
        public string SDT_KH { get; set; }
        public string EMAIL_KH { get; set; }
        public string FAX { get; set; }
    }
}
