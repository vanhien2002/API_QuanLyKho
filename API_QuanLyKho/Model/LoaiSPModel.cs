namespace API_QuanLyKho.Model
{
    public class LoaiSPModel
    {
        public LoaiSPModel(string MA_LOAI, string TEN_LOAI)
        {
            this.MA_LOAI = MA_LOAI;
            this.TEN_LOAI = TEN_LOAI;
        }
        public string MA_LOAI { get; set; }
        public string TEN_LOAI { get; set; }
    }
    
}
