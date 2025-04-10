using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyKhachSan
{
    public partial class Main : Form
    {
        private bool ismenuQuyen;
        private List<Form> childForms; // Danh sách lưu giữ các form con

        public Main(bool ismenuQuyen, string username)
        {
            InitializeComponent();
            this.ismenuQuyen = ismenuQuyen;
            this.childForms = new List<Form>(); // Tạo danh sách các form con

            if (!ismenuQuyen)
            {
                menuQuyen.Enabled = false;
            }

            menuUser.Text = username;
        }

        private void menuMain_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            picMem.Visible = false;
        }

        private void CloseAllChildForms()
        {
            foreach (var form in childForms)
            {
                form.Close();
            }
            childForms.Clear(); // Xóa danh sách các form con
        }

        private void ShowChildForm(Form form)
        {
            childForms.Add(form); // Thêm form con vào danh sách
            form.ShowDialog(); // Hiển thị form
        }

        private void menuOption_MouseEnter(object sender, EventArgs e)
        {
            menuOption.Text = " Tùy chọn";
        }

        private void menuOption_MouseLeave(object sender, EventArgs e)
        {
            menuOption.Text = string.Empty;
        }

        private void menuMembers_Click(object sender, EventArgs e)
        {
            picMem.Visible = true;
        }

        private void menuMembers_MouseEnter(object sender, EventArgs e)
        {
            menuMembers.ShowShortcutKeys = true;
        }

        private void menuMembers_MouseLeave(object sender, EventArgs e)
        {
            menuMembers.ShowShortcutKeys = false;
        }

        private void menuDSQuyen_Click_1(object sender, EventArgs e)
        {
            ShowChildForm(new Quyen());
        }

        private void menuDSTaiKhoan_Click_1(object sender, EventArgs e)
        {
            ShowChildForm(new TaiKhoan());
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CloseAllChildForms(); // Đóng tất cả các form con trước khi đăng xuất
                DangNhap frmDangNhap = new DangNhap();
                this.Hide();
                frmDangNhap.ShowDialog();
                this.Close();
            }
        }

        private void menuDsLoaiPhong_Click(object sender, EventArgs e)
        {
            ShowChildForm(new LoaiPhong());
        }

        private void menuDsPhong_Click_1(object sender, EventArgs e)
        {
            Phong frmPhong = new Phong();
            frmPhong.grbNhapTT.Enabled = true;
            frmPhong.btnDatPhong.Enabled = false;
            ShowChildForm(frmPhong);
        }

        private void menuDsDatPhong_Click_1(object sender, EventArgs e)
        {
            ShowChildForm(new DatPhong());
        }

        private void menuDsNhanPhong_Click_1(object sender, EventArgs e)
        {
            ShowChildForm(new NhanPhong());
        }

        private void menuDsTraPhong_Click_1(object sender, EventArgs e)
        {
            ShowChildForm(new TraPhong());
        }

        private void menuDatPhong_Click_1(object sender, EventArgs e)
        {
            ShowChildForm(new KhachHang());
        }

        private void menuDsKH_Click(object sender, EventArgs e)
        {
            ShowChildForm(new KhachHang());
        }

        private void menuDSLoaiDV_Click(object sender, EventArgs e)
        {
            ShowChildForm(new LoaiDV());
        }

        private void menuInvoice_Click(object sender, EventArgs e)
        {
            ShowChildForm(new HoaDon());
        }

        private void menuDSDichVu_Click(object sender, EventArgs e)
        {
            ShowChildForm(new DichVu());
        }

        private void menuDoanhThu_Click(object sender, EventArgs e)
        {
            ThanhToan frmThanhToan = new ThanhToan();
            frmThanhToan.Text = "Doanh thu";
            frmThanhToan.grbNhapTT.Visible = false;
            frmThanhToan.grbTinhDT.Visible = true;
            ShowChildForm(frmThanhToan);
        }
    }
}
