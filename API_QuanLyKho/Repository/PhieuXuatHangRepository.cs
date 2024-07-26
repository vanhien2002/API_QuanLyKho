using API_QuanLyKho.Hepper;
using API_QuanLyKho.Model;
using AutoMapper.Configuration.Conventions;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace API_QuanLyKho.Repository
{
    public interface IPhieuXuatHangRepository
    {
        public List<PhieuXuatHangModel> getAllPhieuXuatHang();
        public PhieuXuatHangModel getPhieuXuatHangById(string maPhieu);
        public int AddPhieuXuatHang(PhieuXuatHangModel model);
        public int RemovePhieuXuatHang(string maphieuxuat);
        public int UpdatePhieuXuatHang(PhieuXuatHangModel model);
        public List<PhieuXuatHangModel> getPhieuThongKeSoNgay(int soNgay);
    }
    public class PhieuXuatHangRepository:IPhieuXuatHangRepository
    {
        MyLibConnectDB con = new MyLibConnectDB();
        public List<PhieuXuatHangModel> getPhieuThongKeSoNgay(int soNgay)
        {
            string query = "SELECT * FROM PHIEU_XUAT_HANG WHERE NGAY_XH >= DATEADD(day, -" + soNgay+", GETDATE()) AND NGAY_XH <= GETDATE();";
            List<PhieuXuatHangModel> lst = new List< PhieuXuatHangModel>();
            DataTable tbl = con.getDataTable(query);
            string json = JsonConvert.SerializeObject(tbl);
            List<PhieuXuatHangModel> listPhieuXuat = JsonConvert.DeserializeObject<List<PhieuXuatHangModel>>(json);
            return listPhieuXuat;
        }
        public List<PhieuXuatHangModel> getAllPhieuXuatHang()
        {            
            string query = "select * from PHIEU_XUAT_HANG";
            DataTable tbl = con.getDataTable(query);
            string json = JsonConvert.SerializeObject(tbl);
            List<PhieuXuatHangModel> listPhieuXuat = JsonConvert.DeserializeObject<List<PhieuXuatHangModel>>(json);
            return listPhieuXuat;
        }
        public PhieuXuatHangModel getPhieuXuatHangById(string maPhieu)
        {
            string query = "select * from PHIEU_XUAT_HANG where MAPH_XH = '" + maPhieu + "'";
            DataTable tbl = con.getDataTable(query);
            string json = JsonConvert.SerializeObject(tbl);
            List<PhieuXuatHangModel> listPhieuXuat = JsonConvert.DeserializeObject<List<PhieuXuatHangModel>>(json);
            if (listPhieuXuat.Count >= 0)
            {
                PhieuXuatHangModel px = listPhieuXuat.FirstOrDefault();
                return px;
            }
            return null;          
        }
        public int AddPhieuXuatHang(PhieuXuatHangModel model)
        {
            try
            {
                string query = "set dateformat dmy insert into PHIEU_XUAT_HANG(MAPH_XH,NGAY_XH,MAKH,MANV,TRANGTHAI) values ('" + model.MAPH_XH + "','" + model.NGAY_XH + "','" + model.MAKH + "','" + model.MANV + "',"+model.TRANGTHAI+")";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }    
        public int RemovePhieuXuatHang(string maphieuxuat)
        {
            try
            {
                string query = "delete from PHIEU_XUAT_HANG where MAPH_XH = '"+maphieuxuat+"'";
                con.updateToDatabase(query);
                return 1;
            }
            catch { return 0; }
        }
        public int UpdatePhieuXuatHang(PhieuXuatHangModel model)
        {
            try
            {
                string quyery = "set dateformat dmy UPDATE PHIEU_XUAT_HANG SET ngaY_XH = '" + model.NGAY_XH+"', makh = '"+model.MAKH+"', tongtieN_XH = '"+model.TONGTIEN_XH+"', manv = '"+model.MANV+"', trangthai = "+model.TRANGTHAI+" WHERE mapH_XH = '"+model.MAPH_XH+"'";
                con.updateToDatabase(quyery);
                return 1;
            }
            catch { return 0; }
        }
    }
}
