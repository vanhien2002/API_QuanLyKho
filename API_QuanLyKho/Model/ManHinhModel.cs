namespace API_QuanLyKho.Model
{
    public class ManHinhModel
    {
        public ManHinhModel(string MA_MAN_HINH, string TEN_MAN_HINH)
        {
            this.MA_MAN_HINH = MA_MAN_HINH;
            this.TEN_MAN_HINH = TEN_MAN_HINH;
        }
        public string MA_MAN_HINH { get; set; }
        public string TEN_MAN_HINH { get; set; }
    }
}

