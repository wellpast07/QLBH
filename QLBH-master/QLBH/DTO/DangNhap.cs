using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class DangNhap
    {
        public DangNhap(string taiKhoan,string tenDangNhap,int maLTK,string matKhau = null)
        {
            this.TaiKhoan = taiKhoan;
            this.TenDangNhap = tenDangNhap;
            this.MaLTK = maLTK;
            this.MatKhau = matKhau;
        }
        public DangNhap(DataRow row)
        {
            this.TaiKhoan = row["TenDN"].ToString();
            this.TenDangNhap = row["TenDN"].ToString();
            this.MaLTK = (int)row["MaLTK"];
            this.MatKhau = row["MatKhau"].ToString();
        }
        private string matKhau;
        private int maLTK;
        private string tenDangNhap;
        private string taiKhoan;

        public string TaiKhoan
        {
            get
            {
                return taiKhoan;
            }

            set
            {
                taiKhoan = value;
            }
        }

        public string TenDangNhap
        {
            get
            {
                return tenDangNhap;
            }

            set
            {
                tenDangNhap = value;
            }
        }

        public int MaLTK
        {
            get
            {
                return maLTK;
            }

            set
            {
                maLTK = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }
    }
}
