namespace API_QuanLyKho.Model
{
    public class ChucVuModel
    {
        public ChucVuModel(string MaChucVu, string TenChucVu)
        {
            this.MaChucVu = MaChucVu;
            this.TenChucVu = TenChucVu;
        }
        public string MaChucVu { get; set; }
        public string TenChucVu { set; get; }
    }
}
