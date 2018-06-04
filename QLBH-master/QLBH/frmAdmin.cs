using QLBH.DAO;
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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            Load();
        }

        #region Method
        void Load()
        {
            LoadTaiKhoan();
            LoadNhanVien();
            BidingTaiKhoan();
            BidingNhanVien();
        }
        void LoadTaiKhoan()
        {
            string query = "select * from TaiKhoan";
            dtgvTaiKhoan.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }

        void LoadNhanVien()
        {
            string query = "select * from NhanVien";
            dtgvNhanVien.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }
        void BidingTaiKhoan()
        {
            txtTaiKhoan.DataBindings.Add(new Binding("TEXT", dtgvTaiKhoan.DataSource, "TaiKhoan"));
            txtTenHienThi.DataBindings.Add(new Binding("TEXT", dtgvTaiKhoan.DataSource, "TenDN"));
            nmLoaiTaiKhoan.DataBindings.Add(new Binding("Value", dtgvTaiKhoan.DataSource, "MaLTK"));

        }
        void BidingNhanVien()
        {
            txtMaNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaNV"));
            txtTenNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "TenNV"));
            txtDiaChia.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "DiaChi"));
            txtSDT.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SDT"));
            txtEmail.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "Email"));
        }
        #endregion

        #region Event
        //Tai Khoan
        private void btnThem_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string tenDN = txtTenHienThi.Text;
            string MaLTK = nmLoaiTaiKhoan.Value.ToString();
            if (DangNhapDAO.Instance.ThemTaiKhoan(taiKhoan, tenDN, MaLTK))
            {
                MessageBox.Show("Thêm thành công! ");
            }
            else
            {
                MessageBox.Show("Thêm thất công! ");
            }
            LoadTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            if (DangNhapDAO.Instance.XoaTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Xóa thành công! ");
            }
            else
            {
                MessageBox.Show("Xóa thất công! ");
            }
            LoadTaiKhoan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string tenDN = txtTenHienThi.Text;
            string MaLTK = nmLoaiTaiKhoan.Value.ToString();
            if (DangNhapDAO.Instance.SuaTaiKhoan(taiKhoan, tenDN, MaLTK))
            {
                MessageBox.Show("Sửa thành công! ");
            }
            else
            {
                MessageBox.Show("Sửa thất công! ");
            }
            LoadTaiKhoan();
        }
        #endregion



        //Nhan Vien

        private void ThemNV_Click(object sender, EventArgs e)
        {

            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string diaChi = txtDiaChia.Text;
            string SDT = txtSDT.Text;
            string email = txtEmail.Text;

            if (NhanVienDAO.Instance.ThemNhanVien(maNV, tenNV, diaChi, SDT, email))
            {
                MessageBox.Show("Thêm thành công! ");
            }
            else
            {
                MessageBox.Show("Thêm thất công! ");
            }
            LoadNhanVien();
        }
        private void XoaNV_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;
            if (NhanVienDAO.Instance.XoaNhanVien(MaNV))
            {
                MessageBox.Show("Xóa thành công! ");
            }
            else
            {
                MessageBox.Show("Xóa thất công! ");
            }
            LoadNhanVien();
        }

        private void SuaNV_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string diaChi = txtDiaChia.Text;
            string SDT = txtSDT.Text;
            string email = txtEmail.Text;
            if (NhanVienDAO.Instance.SuaNhanVien(maNV, tenNV, diaChi, SDT, email))
            {
                MessageBox.Show("Sửa thành công! ");
            }
            else
            {
                MessageBox.Show("Sửa thất công! ");
            }
            LoadNhanVien();
        }
    }
}
