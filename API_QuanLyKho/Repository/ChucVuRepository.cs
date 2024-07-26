using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface IChucVuRepository
    {
        public List<ChucVuModel> getAllChucVu();
        public ChucVuModel getChucVuById(string maCV);
        public int AddChucVu(ChucVuModel modelCV);
        public int RemoveChucVu(string maCV);
        public int UpdateChucVu(ChucVuModel modelCV);
    }
    public class ChucVuRepository:IChucVuRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<ChucVuModel> getAllChucVu()
        {
            string query = "SELECT * FROM CHUC_VU";
            DataTable tbl = con.getDataTable(query);
            List<ChucVuModel> lst = new List<ChucVuModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                ChucVuModel cv = new ChucVuModel(
                    tbl.Rows[i][0].ToString(), //maChuVu
                      tbl.Rows[i][1].ToString()//tenChucVu
                                                );
                lst.Add(cv);
            }
            return lst;
        }
        public ChucVuModel getChucVuById(string maCV)
        {
            string query = "SELECT * FROM CHUC_VU where MACHUCVU ='" + maCV + "'";
            DataTable tbl = con.getDataTable(query);

            ChucVuModel cv = new ChucVuModel(
                      tbl.Rows[0][0].ToString(), //maChuVu
                      tbl.Rows[0][1].ToString()//tenChucVu
                                                 );
            return cv;
        }
        public int AddChucVu(ChucVuModel model)
        {
            try
            {
                string query = "insert into CHUC_VU(MACHUCVU, TENCHUCVU) values ('" + model.MaChucVu + "',N'" + model.TenChucVu + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveChucVu(string maCV)
        {
            try
            {
                string query = "delete from CHUC_VU where MACHUCVU ='" + maCV + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateChucVu(ChucVuModel model)
        {
            try
            {
                RemoveChucVu(model.MaChucVu);
                AddChucVu(model);
                return 1;
            }
            catch { return 0; }
        }
    }
}
