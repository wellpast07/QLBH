using QLBH.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;

        public static DangNhapDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DangNhapDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private DangNhapDAO() { }

        // Đăng Nhập
        public bool DangNhap(string taikhoan,string matkhau)
        {
         string query = "dbo.USP_DangNhap @TaiKhoan , @MatKhau";

            DataTable resules = DataProvider.Instance.ExcuteQuery(query,new object[]{ taikhoan,matkhau });

            return resules.Rows.Count > 0;
        }
        
        public DangNhap DangNhapTheoTaiKhoan(string taikhoan)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from TaiKhoan where TenDN = '" + taikhoan + "'");
            foreach(DataRow item in data.Rows )
            {
                return new DangNhap(item);
            }
            return null;
        }

        public bool SuaThongTinCaNhan(string taiKhoan,string tenDN,string matKhau,string matKhauMoi)
        {
            string query = "USP_UpdateAccounts @userName , @displayName , @password , @newPassword";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {taiKhoan,tenDN,matKhau,matKhauMoi});
            return result > 0;
        }
        

       //Tai Khoản
        public bool ThemTaiKhoan(string TaiKhoan,string tenDN,string MaLTK,string MatKhau ="1")
        {
            string query = string.Format("insert dbo.TaiKhoan (TaiKhoan,TenDN,MatKhau,MaLTK) values (N'{0}',N'{1}',N'{2}',N'{3}')",TaiKhoan,tenDN,MaLTK,MatKhau);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaTaiKhoan(string TaiKhoan, string tenHienThi, string LoaiTK)
        {
            string query = string.Format("Update dbo.TaiKhoan set TenDN = N'{0}', MaLTK = N'{1}'  where TaiKhoan = N'{2}'", tenHienThi, LoaiTK, TaiKhoan);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaTaiKhoan(string TaiKhoan)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete dbo.TaiKhoan where TaiKhoan = N'" + TaiKhoan + "'");
            return result > 0;
        }
    }
}
 