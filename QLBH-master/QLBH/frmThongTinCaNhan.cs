using QLBH.DAO;
using QLBH.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmThongTinCaNhan : Form
    {
        private DangNhap taikhoanDangNhap;

        public DangNhap TaikhoanDangNhap
        {
            get
            {
                return taikhoanDangNhap;
            }

            set
            {
                taikhoanDangNhap = value;
                KieuTaiKhoan(taikhoanDangNhap);
            }
        }

        public frmThongTinCaNhan(DangNhap acc)
        {
            InitializeComponent();
            this.TaikhoanDangNhap = acc;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void SuaThongTinCaNhan()
        {
            string taiKhoan = txtTaiKhoan.Text;
            string tenDN = txtTenHienThi.Text;
            string matKhau = txtMatKhau.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string matKhauNhapLai = txtNhapLai.Text;
            
            if(!matKhauMoi.Equals(matKhauNhapLai))
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu mới");
            }
            else
            {
                if(DangNhapDAO.Instance.SuaThongTinCaNhan(taiKhoan,tenDN,matKhau,matKhauMoi))
                {
                    MessageBox.Show("Cập nhập thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhập thất bại");
                }
            }
        }
        void KieuTaiKhoan(DangNhap acc)
        {
            txtTaiKhoan.Text = taikhoanDangNhap.TaiKhoan;
            txtTenHienThi.Text = taikhoanDangNhap.TenDangNhap;

        }
        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            SuaThongTinCaNhan();
        }
    }
}
