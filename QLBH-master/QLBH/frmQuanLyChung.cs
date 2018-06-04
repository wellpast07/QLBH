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
    #region event
    public partial class frmQuanLyChung : Form
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
                KieuTaiKhoan(taikhoanDangNhap.MaLTK);
            }
        }

        public frmQuanLyChung(DangNhap acc)
        {
            InitializeComponent();
            this.TaikhoanDangNhap = acc;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void amindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            this.Show();
            f.ShowDialog();
            this.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan f = new frmThongTinCaNhan(taikhoanDangNhap);
            this.Show();
            f.ShowDialog();
            this.Show();
        }
        #endregion
        #region method

        void KieuTaiKhoan(int kieuTaiKhoan)
        {
            if(amindToolStripMenuItem.Enabled = kieuTaiKhoan == 1);
            thôngTinCáNhânToolStripMenuItem.Text += " (" + taikhoanDangNhap.TenDangNhap + ")";
        }

        #endregion

        private void phiếuNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhap frm = new frmNhap();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhacungcap f = new frmNhacungcap();
            f.Activate();
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkhachhang f = new frmkhachhang();
            f.Activate();
            f.Show();
        }

        private void phiếuXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuat f = new frmXuat();
            f.Activate();
            f.Show();
        }
    }
}
