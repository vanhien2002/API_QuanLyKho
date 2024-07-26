
using System.Data;
using System.Data;
using System.Data.SqlClient;

namespace API_QuanLyKho.Hepper
{
    public class MyLibConnectDB
    {
        string _strSeverName, _strDatabaseName, _strUserName, _strPassWord, _strConnection;
        DataSet _Dset;

        public DataSet DSet
        {
            get { return _Dset; }
            set { _Dset = value; }
        }
        public string StrConnection
        {
            get { return _strConnection; }
            set { _strConnection = value; }
        }
        SqlConnection _conn;

        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public string StrPassWord
        {
            get { return _strPassWord; }
            set { _strPassWord = value; }
        }

        public string StrUserName
        {
            get { return _strUserName; }
            set { _strUserName = value; }
        }

        public string StrDatabaseName
        {
            get { return _strDatabaseName; }
            set { _strDatabaseName = value; }
        }

        public string StrSeverName
        {
            get { return _strSeverName; }
            set { _strSeverName = value; }
        }
        public MyLibConnectDB()
        {
            //Kết nối sever trường
            //StrSeverName = @"A102PC28";
            //StrDatabaseName = @"QLSinhVien";
            //kết nối sever máy riêng
            //StrSeverName = @"DESKTOP-02U2UQD\SQLEXPRESS";
            StrDatabaseName = @"QUANLYKHOHANG";
            //StrPassWord = "sa";
            //StrUserName = "123";
            //
            //StrConnection = @"Data Source=DESKTOP-02U2UQD\SQLEXPRESS;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=123";
            //            //StrConnection = @"Data Source=" + StrSeverName + ";Initial Catalog=" + StrDatabaseName + ";Integrated Security=True";
            //            StrConnection = @"Data Source=DESKTOP-02U2UQD\SQLEXPRESS;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=123";
            //            //StrConnection = @"Data Source= LAPTOP-OJDSJCBC;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=123";
            //            //StrConnection = @"Data Source= LAPTOP-OJDSJCBC;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=123";
            //StrConnection = @"Data Source= DELL\SQLEXPRESS;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=21062002";
            //StrConnection = @"Data Source=" + StrSeverName + ";Initial Catalog=" + StrDatabaseName + ";Integrated Security=True";
            //StrConnection = @"Data Source= LAPTOP-OJDSJCBC;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=123";
            StrConnection = @"Data Source= DELL\SQLEXPRESS;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=21062002";
            //StrConnection = @"Data Source= DESKTOP-GMTEBGR;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=123";
            //StrConnection = @"Data Source= DESKTOP-02U2UQD\SQLEXPRESS;Initial Catalog=QUANLYKHOHANG;Persist Security Info=True;User ID=sa;Password=123";

            //window
            Conn = new SqlConnection();
            Conn.ConnectionString = StrConnection;
            DSet = new DataSet(StrDatabaseName);            
        }
        public MyLibConnectDB(string SeverName, string databaseName, string user, string pass)
        {
            StrConnection = @"Data Source= "+ SeverName + ";Initial Catalog="+databaseName+";Persist Security Info=True;User ID="+user+";Password="+pass+"";
            //windown
            Conn = new SqlConnection(); 
            Conn.ConnectionString = StrConnection;
            DSet = new DataSet(databaseName);
        }

        public void openConnect()
        {
            //mở kết nối
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
        }
        public void closeConnect()
        {
            //đóng kết nối
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
        public void disposeConnect()
        {
            //hủy đối tượng kết nối
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Dispose(); //giải phóng vùng nhớ đã cấp phát
        }
        public void updateToDatabase(string StrSQL)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = StrSQL;
            cmd.ExecuteReader();//thực thi
            closeConnect();
        }
        public int getCount(string StrSQL)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = StrSQL;
            int rs = (int)cmd.ExecuteScalar();
            closeConnect();
            return rs;
        }
        public SqlDataReader getDataReader(string sql)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public SqlDataAdapter getDataAdepter(string strSQL, string tableName)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, StrConnection);
            ada.Fill(DSet, tableName);
            closeConnect();
            return ada;

        }
        public DataTable getDataTable(string strSQl)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQl, StrConnection);
            ada.Fill(DSet);
            closeConnect();
            return DSet.Tables[0];
        }
        public DataTable getDataTable(string strSQL, string tableName)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, StrConnection);
            ada.Fill(DSet, tableName);
            closeConnect();
            return DSet.Tables[tableName];
        }
        public DataTable getDataTable(string strSQL, string tableName, params string[] keyName)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, StrConnection);
            ada.Fill(DSet, tableName);
            //Tao khoas chinhs cho datatable
            int n = keyName.Length;
            DataColumn[] primaryKey = new DataColumn[n];
            for (int i = 0; i < n; i++)
            {
                primaryKey[i] = DSet.Tables[tableName].Columns[keyName[i]];
            }
            DSet.Tables[tableName].PrimaryKey = primaryKey;
            closeConnect();
            return DSet.Tables[tableName];
        }
    }
}
