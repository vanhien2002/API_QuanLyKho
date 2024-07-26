namespace API_QuanLyKho.Model
{

    public class ChiTietNHModel
    {
        public ChiTietNHModel(string MaPhieuNH, string MaSP, int SoLuong, int ThanhTien, int Gia)
        {
            this.MaPhieuNH = MaPhieuNH;
            this.MaSP = MaSP;
            this.SoLuong = SoLuong;
            this.ThanhTien = ThanhTien;
            this.Gia = Gia;
        }
        public string MaPhieuNH {  get; set; }
        public string MaSP {  get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
        public int Gia { get; set; }

    }
}
