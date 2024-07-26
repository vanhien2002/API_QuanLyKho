namespace API_QuanLyKho.Model
{
    public class AIModel
    {
        public AIModel(string MaSLTonKho, string MaSLXuatHang, string MaMucGia, string QuyetDinh)
        {
            this.MaSLTonKho = MaSLTonKho;
            this.MaSLXuatHang = MaSLXuatHang;
            this.MaMucGia = MaMucGia;
            this.QuyetDinh = QuyetDinh;
        }
        public  string MaSLTonKho { get; set; }
        public string MaSLXuatHang { get; set; }
        public string MaMucGia { get; set; }
        public string QuyetDinh { get; set; }
    }
}
