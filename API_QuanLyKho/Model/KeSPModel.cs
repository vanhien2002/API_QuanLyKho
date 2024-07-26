namespace API_QuanLyKho.Model
{
    public class KeSPModel
    {
        public KeSPModel(string MA_KE, string TEN_KE, string SOLUONGSP, string MAKHU,string MASP)
        {
            this.MA_KE = MA_KE;
            this.TEN_KE = TEN_KE;
            this.SOLUONGSP = SOLUONGSP;
            this.MAKHU = MAKHU;
            this.MASP = MASP;
        }
        public string MA_KE { get; set; }
        public string TEN_KE { get; set; }
        public string SOLUONGSP { get; set; }
        public string MAKHU { get; set; }
        public string MASP { get; set; }
    }

}
