namespace API_QuanLyKho.Model
{
    public class ChiTietXHModel
    {
        public ChiTietXHModel(string MAPH_XH, string MA_SP, string SOLUONG, string THANHTIEN, string GIA)
        {
            this.MAPH_XH = MAPH_XH;
            this.MA_SP = MA_SP;
            this.SOLUONG = SOLUONG;
            this.THANHTIEN = THANHTIEN;
            this.GIA=GIA;
        }
        public string MAPH_XH { get; set; }
        public string MA_SP { get; set; }
        public string SOLUONG { get; set; }
        public string THANHTIEN { get; set; }
        public string GIA { get; set; }       
    }
}
