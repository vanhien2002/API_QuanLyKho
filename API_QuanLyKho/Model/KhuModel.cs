namespace API_QuanLyKho.Model
{
    public class KhuModel
    {
        public KhuModel(string MA_KHU, string TEN_KHU)
        {
            this.MA_KHU = MA_KHU;
            this.TEN_KHU = TEN_KHU;
        }
        public string MA_KHU { get; set; }
        public string TEN_KHU { get; set; }
    }
}
