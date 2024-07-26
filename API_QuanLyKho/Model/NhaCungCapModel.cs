namespace API_QuanLyKho.Model
{
    public class NhaCungCapModel
    {
        public NhaCungCapModel( string Ma_NCC, string Ten_NCC, string DiaChi_NCC, string SDT) 
        {
            this.Ma_NCC = Ma_NCC;
            this.Ten_NCC = Ten_NCC;
            this.DiaChi_NCC = DiaChi_NCC;
            this.SDT = SDT;
        }
        public string Ma_NCC {  get; set; }
        public string Ten_NCC { get; set; }
        public string DiaChi_NCC { get; set; }
        public string SDT {  get; set; }

    }
}
