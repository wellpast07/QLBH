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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn thực sự muốn thoát","Thông báo",MessageBoxButtons.OKCancel)!=DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaiKhoan.Text;
            string MatKhau = txtMatKhau.Text;
            if (DangNhap(TaiKhoan,MatKhau))
            {
                DangNhap taikhoanDangNhap = DangNhapDAO.Instance.DangNhapTheoTaiKhoan(TaiKhoan);
                this.Hide();
                frmQuanLyChung f = new frmQuanLyChung(taikhoanDangNhap);
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK);
            }
        }

        bool DangNhap(string taikhoan,string matkhau)
        {
            return DangNhapDAO.Instance.DangNhap(taikhoan, matkhau);
        }
    }
}
