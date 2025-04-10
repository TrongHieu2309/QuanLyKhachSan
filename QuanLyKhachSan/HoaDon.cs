using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class HoaDon : Form
    {
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        private Color originalColor;

        public HoaDon()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string qr = "SELECT * FROM HoaDon";
            dataGVHoaDon.DataSource = KetNoi.Execute(qr);
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0 ) dataGVHoaDon.Enabled = true;
            else dataGVHoaDon.Enabled = false;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            btnInHoaDon.Enabled = false;

            originalColor = picRefesh.BackColor;
        }

        private void dataGVHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInHoaDon.Enabled = true;

            int index = dataGVHoaDon.CurrentRow.Index;
            txtMaHD.Text = dataGVHoaDon.Rows[index].Cells[0].Value.ToString();
            txtMaKH.Text = dataGVHoaDon.Rows[index].Cells[1].Value.ToString();
            txtTenKH.Text = dataGVHoaDon.Rows[index].Cells[2].Value.ToString();
            txtLoaiPhong.Text = dataGVHoaDon.Rows[index].Cells[3].Value.ToString();
            txtSoPhong.Text = dataGVHoaDon.Rows[index].Cells[4].Value.ToString();
            txtSoLuong.Text = dataGVHoaDon.Rows[index].Cells[5].Value.ToString();
            txtTenDV.Text = dataGVHoaDon.Rows[index].Cells[6].Value.ToString();
            txtGiaDV.Text = dataGVHoaDon.Rows[index].Cells[7].Value.ToString();
            txtGia1Ngay.Text = dataGVHoaDon.Rows[index].Cells[8].Value.ToString();
            dateNgayDen.Text = dataGVHoaDon.Rows[index].Cells[9].Value.ToString();
            dateNgayDi.Text = dataGVHoaDon.Rows[index].Cells[10].Value.ToString();
            txtSdt.Text = dataGVHoaDon.Rows[index].Cells[11].Value.ToString();
            txtTongTien.Text = dataGVHoaDon.Rows[index].Cells[12].Value.ToString();
            txtTraTruoc.Text = dataGVHoaDon.Rows[index].Cells[13].Value.ToString();
            txtConLai.Text = dataGVHoaDon.Rows[index].Cells[14].Value.ToString();
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtLoaiPhong.Text = string.Empty;
            txtSoPhong.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtTenDV.Text= string.Empty;
            txtGiaDV.Text= string.Empty;
            dateNgayDen.Value = DateTime.Now;
            dateNgayDi.Value = DateTime.Now;
            txtSdt.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtTraTruoc.Text = string.Empty;
            txtConLai.Text = string.Empty;

            LoadData();
        }

        private void picRefesh_MouseEnter(object sender, EventArgs e)
        {
            picRefesh.BackColor = SystemColors.WindowFrame;
        }

        private void picRefesh_MouseLeave(object sender, EventArgs e)
        {
            picRefesh.BackColor = originalColor;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            int MaHD = int.Parse(txtMaHD.Text);
            string qr = "SELECT MaHD, TenKH, TenLoaiPhong, TenPhong, SoLuong, TenLoaiDV, GiaLoaiDV, " +
                "Gia1Ngay, NgayDen, NgayDi, Sdt, TongTien, TraTruoc, Conlai FROM HoaDon WHERE MaHD = '" + MaHD + "'";
            DataTable dt = KetNoi.Execute(qr);
            rptInHĐ baocao = new rptInHĐ();
            baocao.SetDataSource(dt);

            InHoaDon frmInHD = new InHoaDon();
            frmInHD.rptHoaDon.ReportSource = baocao;
            frmInHD.ShowDialog();
        }
    }
}
