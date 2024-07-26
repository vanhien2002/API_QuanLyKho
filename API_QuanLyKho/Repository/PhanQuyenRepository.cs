using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Data;
using static API_QuanLyKho.Hepper.WebEndpoint;

namespace API_QuanLyKho.Repository
{
    public interface IPhanQuyenRepository
    {
        public List<PhanQuyenModel> getAllPhanQuyen();
        public PhanQuyenModel getPhanQuyenById(string manhomngdung);
        public int AddPhanQuyen(PhanQuyenModel model);
        public int RemovePhanQuyen(string manhomngdung);
        public int UpdatePhanQuyen(PhanQuyenModel model);

    }
    public class PhanQuyenRepository : IPhanQuyenRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<PhanQuyenModel> getAllPhanQuyen()
        {
            string query = "SELECT * FROM QL_PHANQUYEN";
            DataTable tbl = con.getDataTable(query);
            List<PhanQuyenModel> lst = new List<PhanQuyenModel>();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                PhanQuyenModel kh = new PhanQuyenModel(
                    tbl.Rows[i][0].ToString(), //manhomngdung
                      tbl.Rows[i][1].ToString(),//mamh
                     Convert.ToBoolean(tbl.Rows[i][2])//coquyen
                                                );
                lst.Add(kh);
            }
            return lst;
        }
        public PhanQuyenModel getPhanQuyenById(string manhomngdung)
        {
            string query = "SELECT * FROM QL_PHANQUYEN where MANHOMNGUOIDUNG ='" + manhomngdung + "'";
            DataTable tbl = con.getDataTable(query);

            PhanQuyenModel kh = new PhanQuyenModel(
                      tbl.Rows[0][0].ToString(), //manhomngdung
                      tbl.Rows[0][1].ToString(),//mamh
                       Convert.ToBoolean(tbl.Rows[0][2])//quyen
                                                 );
            return kh;
        }


        public int AddPhanQuyen(PhanQuyenModel model)
        {
            try
            {
                string query = "insert into QL_PHANQUYEN(MANHOMNGUOIDUNG,MAMANHINH,COQUYEN) values ('" + model.MA_NHOM_NGUOI_DUNG + "','" + model.MA_MAN_HINH + "','" + model.COQUYEN + "')";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int RemovePhanQuyen(string manhomngdung)
        {
            try
            {
                string query = "delete from QL_PHANQUYEN where MANHOMNGUOIDUNG ='" + manhomngdung + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdatePhanQuyen(PhanQuyenModel model)
        {
            try
            {
                string coQuyenValue = model.COQUYEN ? "1" : "0";
                string query = "UPDATE QL_PHANQUYEN SET COQUYEN = '" + coQuyenValue + "' WHERE MAMANHINH = '" + model.MA_MAN_HINH + "' AND MANHOMNGUOIDUNG = '" + model.MA_NHOM_NGUOI_DUNG + "'";
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
