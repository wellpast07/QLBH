using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NhanVienDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private NhanVienDAO() { }

        //Nhân Viên
        public bool ThemNhanVien(string maNV, string tenNV, string diaChi, string SDT, string email)
        {
            string query = string.Format("insert dbo.NhanVien (MaNV,TenNV,DiaChi,SDT,Email) values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", maNV, tenNV, SDT, diaChi , email);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaNhanVien(string maNV, string tenNV, string diaChi, string SDT, string email)
        {
            string query = string.Format("Update dbo.NhanVien set TenNV = N'{0}', DiaChi = N'{1}',SDT = N'{2}',Email = N'{3}'  where MaNV = N'{4}'", tenNV, diaChi, SDT,email,maNV);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaNhanVien(string maNV)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete dbo.NhanVien where MaNV = N'" + maNV + "'");
            return result > 0;
        }
    }

   
}
