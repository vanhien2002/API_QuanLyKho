namespace API_QuanLyKho.Model
{

    public class SanPhamModel
    {
        public SanPhamModel(string MA_SP, string MA_NCC,string TEN_SP, DateTime NGAYSX, DateTime HSD,int SOLUONG,string MA_LOAI,int GIA,string GHICHU_SP,string MAKHO, byte[]ANH)
        {
            this.MA_SP = MA_SP;
            this.MA_NCC = MA_NCC;
            this.TEN_SP = TEN_SP;
            this.NGAYSX = NGAYSX;
            this.HSD = HSD;
            this.SOLUONG = SOLUONG;
            this.MA_LOAI = MA_LOAI;
            this.GIA = GIA;
            this.GHICHU_SP = GHICHU_SP;
            this.MAKHO = MAKHO;
            this.ANH = ANH;
        }
        public string MA_SP { get; set; }
        public string MA_NCC { get; set; }
        public string TEN_SP { get; set; }
        public DateTime NGAYSX { get; set; }
        public DateTime HSD { get; set; }
        public int SOLUONG { get; set; }
        public string MA_LOAI { get; set; }
        public int GIA { get; set; }
        public string GHICHU_SP { get; set; }
        public string MAKHO { get; set; }
        public byte[] ANH { get; set; }
    }
}
