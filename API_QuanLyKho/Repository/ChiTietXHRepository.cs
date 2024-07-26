using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace API_QuanLyKho.Repository
{
    public interface IChiTietXHRepository
    {
        public List<ChiTietXHModel> getAll();
        public List<ChiTietXHModel> getByChiTietPhieuXuatId(string MAPX);
        public ChiTietXHModel getChiTietPhieuXuatItem(string MAPX, string MASP);
        public int addItem(ChiTietXHModel model);
        public int remove(string maphieuxuat, string masp);
        public int remove(string maphieuxuat);
        public int update(ChiTietXHModel model);
    }
    public class ChiTietXHRepository : IChiTietXHRepository
    {
        //MyLibConnectDB con = new MyLibConnectDB(@"DESKTOP-02U2UQD\SQLEXPRESS", "QUANLYKHOHANG", "sa", "123");
        MyLibConnectDB con = new MyLibConnectDB();
        public List<ChiTietXHModel> getAll()
        {
            List<ChiTietXHModel> lst = new List<ChiTietXHModel>();
            string query = "select * from CHITIET_XH";
            DataTable tbl = con.getDataTable(query);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                ChiTietXHModel item = new ChiTietXHModel(
                    tbl.Rows[i][0].ToString(),
                    tbl.Rows[i][1].ToString(),
                    tbl.Rows[i][2].ToString(),
                    tbl.Rows[i][3].ToString(),
                    tbl.Rows[i][4].ToString());
                lst.Add(item);
            }
            return lst;
        }
        public List<ChiTietXHModel> getByChiTietPhieuXuatId(string MAPX) {
            string query = "select * from CHITIET_XH where MAPH_XH = '" + MAPX + "'";
            List<ChiTietXHModel> lst = new List<ChiTietXHModel>();
            DataTable tbl = con.getDataTable(query);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                ChiTietXHModel item = new ChiTietXHModel(
                    tbl.Rows[i][0].ToString(),
                    tbl.Rows[i][1].ToString(),
                    tbl.Rows[i][2].ToString(),
                    tbl.Rows[i][3].ToString(),
                    tbl.Rows[i][4].ToString());
                lst.Add(item);
            }
            return lst;
        }
        public ChiTietXHModel getChiTietPhieuXuatItem(string MAPX, string MASP)
        {
            string query = "select * from CHITIET_XH where MAPH_XH = '"+ MAPX + "' and MA_SP='"+ MASP + "'";         
            DataTable tbl = con.getDataTable(query);
            ChiTietXHModel item=null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                 item = new ChiTietXHModel(
                    tbl.Rows[i][0].ToString(),
                    tbl.Rows[i][1].ToString(),
                    tbl.Rows[i][2].ToString(),
                    tbl.Rows[i][3].ToString(),
                    tbl.Rows[i][4].ToString());
                if(item != null)
                {
                    return item;
                }
            }
            return item;
        }
        public int addItem(ChiTietXHModel model)
        {
            try {
                string query = "insert into CHITIET_XH(MAPH_XH,MA_SP,SOLUONG,GIA) values ('" + model.MAPH_XH + "','" + model.MA_SP + "'," + model.SOLUONG + "," + model.GIA + ")";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int remove(string maphieuxuat, string masp) {
            try
            {
                string query = "delete from CHITIET_XH where MAPH_XH ='" + maphieuxuat + "' and MA_SP ='" + masp + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int update(ChiTietXHModel model) {
            try
            {
                remove(model.MAPH_XH, model.MA_SP);
                addItem(model);
                return 1;
            }
            catch { return 0; }

        }
        public int remove(string maphieuxuat)
        {
            try
            {
                string query = "delete from CHITIET_XH where MAPH_XH ='" + maphieuxuat + "'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
    }
}
