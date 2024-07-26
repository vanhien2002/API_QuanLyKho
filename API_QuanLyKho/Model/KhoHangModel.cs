namespace API_QuanLyKho.Model
{
        public class KhoHangModel
        {
            public KhoHangModel(string MA_KHO, string TEN_KHO,string DIACHI,string GHICHU)
            {
                this.MA_KHO = MA_KHO;
                this.TEN_KHO = TEN_KHO;
                this.DIACHI = DIACHI;
                this.GHICHU = GHICHU;
        }
            public string MA_KHO { get; set; }
            public string TEN_KHO { get; set; }
            public string DIACHI { get; set; }
            public string GHICHU { get; set; }
    }
    
}
