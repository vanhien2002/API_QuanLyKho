using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface IManHinhRepository
    {
        public List<ManHinhModel> getAllManHinh();
        public ManHinhModel getManHinhById(string mamanhinh);
        public int AddManHinh(ManHinhModel model);
        public int RemoveManHinh(string mamanhinh);
        public int UpdateManHinh(ManHinhModel model);
        public List<string> GetMaManHinh();
        public List<ManHinhModel> GetManHinhs(string taikhoan);
    }
    public class ManHinhRepository : IManHinhRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<ManHinhModel> getAllManHinh()
        {
            string query = "SELECT * FROM DM_MANHINH";
            DataTable tbl = con.getDataTable(query);
            List<ManHinhModel> lst = new List<ManHinhModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                ManHinhModel kh = new ManHinhModel(
                    tbl.Rows[i][0].ToString(), //mamanhinh
                      tbl.Rows[i][1].ToString()//tenmanhinh
                                                );
                lst.Add(kh);
            }
            return lst;
        }
        public List<string> GetMaManHinh()
        {
            string query = "SELECT DISTINCT MAMANHINH FROM DM_MANHINH";
            DataTable tbl = con.getDataTable(query);
            List<string> lst = new List<string>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string mamanhinh = tbl.Rows[i][0].ToString();
                lst.Add(mamanhinh);
            }
            return lst;
        }
        public List<ManHinhModel> GetManHinhs(string taikhoan)
        {
            if (String.IsNullOrEmpty(taikhoan))
            {
                return null;
            }

            List<ManHinhModel> manHinhs = new List<ManHinhModel>();

            string query = "SELECT DISTINCT DM_MANHINH.MAMANHINH, DM_MANHINH.TENMANHINH " +
                           "FROM QL_PHANQUYEN " +
                           "JOIN DM_MANHINH ON QL_PHANQUYEN.MAMANHINH = DM_MANHINH.MAMANHINH " +
                           "WHERE QL_PHANQUYEN.MANHOMNGUOIDUNG IN " +
                           "(SELECT MANHOMNGUOIDUNG FROM TAIKHOAN_NV WHERE TAIKHOAN ='" + taikhoan + "')";

            DataTable tbl = con.getDataTable(query);

            foreach (DataRow row in tbl.Rows)
            {
                ManHinhModel manHinh = new ManHinhModel(
                    row[0].ToString(), // Mã màn hình
                    row[1].ToString()  // Tên màn hình
                );

                manHinhs.Add(manHinh);
            }

            return manHinhs;
        }
        public ManHinhModel getManHinhById(string mamanhinh)
        {
            string query = "SELECT * FROM DM_MANHINH where MAMANHINH ='" + mamanhinh + "'";
            DataTable tbl = con.getDataTable(query);

            ManHinhModel kh = new ManHinhModel(
                      tbl.Rows[0][0].ToString(), //mamanhinh
                      tbl.Rows[0][1].ToString()//tenmanhinh
                                                 );
            return kh;
        }
        public int AddManHinh(ManHinhModel model)
        {
            try
            {
                string query = "insert into DM_MANHINH(MAMANHINH,TENMANHINH) values ('" + model.MA_MAN_HINH + "','" + model.TEN_MAN_HINH + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemoveManHinh(string mamanhinh)
        {
            try
            {
                string query = "delete from DM_MANHINH where MAMANHINH ='" + mamanhinh + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdateManHinh(ManHinhModel model)
        {
            try
            {
                string query = "UPDATE DM_MANHINH SET TENMANHINH = N'" + model.TEN_MAN_HINH + "' WHERE MAMANHINH = '" + model.MA_MAN_HINH + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
