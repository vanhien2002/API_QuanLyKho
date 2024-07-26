using System.Security;

namespace API_QuanLyKho.Model
{
    public class TK_XuatHangModel
    {
        public string MAPH_XH        { get; set; }
        public DateTime NGAY_XH { get; set; }
        public string MALOAI { get; set; }
        public string MA_SP { get; set; }
        public string TEN_SP { get; set; }
        public int SOLUONG { get; set; }
        public double THANHTIEN { get; set; }
    }
}
