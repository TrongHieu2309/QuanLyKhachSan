using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Temp;

namespace QuanLyKhachSan
{
    public partial class Phong : Form
    {
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        public GroupBox grbNhapTT;
        public Button btnDatPhong;
        private Color originalColor;

        public Phong()
        {
            InitializeComponent();
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadcbLoaiPhong();
            picRefesh.BackColor = originalColor;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void LoadcbLoaiPhong()
        {
            cbLoaiPhong.Items.Clear();
            cbLoaiPhong1.Items.Clear();
            string qr = "SELECT TenLoaiPhong FROM LoaiPhong";
            DataTable dt = KetNoi.Execute(qr);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbLoaiPhong.Items.Add(dt.Rows[i][0].ToString());
                    cbLoaiPhong1.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }

        private void UncheckAllInGrb(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private string GetTienIch()
        {
            var TienIchList = new List<string>();

            if (rb1Giuong.Checked) TienIchList.Add("1 Giường");
            if (rb2Giuong.Checked) TienIchList.Add("2 Giường");
            if (rb3Giuong.Checked) TienIchList.Add("3 Giường");
            if (rb4Giuong.Checked) TienIchList.Add("4 Giường");
            if (ckbBonTam.Checked) TienIchList.Add("bồn tắm");
            if (ckbTuLanh.Checked) TienIchList.Add("tủ lạnh");
            if (ckbHoBoi.Checked) TienIchList.Add("hồ bơi");

            return string.Join(", ", TienIchList);
        }

        private bool CheckText()
        {
            if (string.IsNullOrWhiteSpace(cbLoaiPhong.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
                return false;
            if (string.IsNullOrWhiteSpace(txtGia1Ngay.Text))
                return false;
            return true;

        }

        private bool OptionChecked(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {                
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        private void BtnThem()
        {
            btnThem.Enabled = CheckText() && OptionChecked(grbTienIch);
        }

        private void Refesh()
        {
            txtMaPhong.Text = string.Empty;
            txtMaLoaiPhong.Text = string.Empty;
            cbLoaiPhong.Text = string.Empty;
            txtSoPhong.Text = string.Empty;
            UncheckAllInGrb(grbTienIch);
            txtGia1Ngay.Text = string.Empty;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Phong";
            dataGVPhong.DataSource = KetNoi.Execute(query);
            DataTable dt = KetNoi.Execute(query);
            if (dt.Rows.Count > 0) dataGVPhong.Enabled = true;
            else dataGVPhong.Enabled = false;
        }


        private string TimKiem()
        {
            var qr = new StringBuilder("SELECT * FROM Phong ");

            if (!string.IsNullOrEmpty(cbLoaiPhong1.Text))
            {
                qr.Append("WHERE TenLoaiPhong = N'" + cbLoaiPhong1.Text + "'");
            }
            return qr.ToString();
        }

        //private void LoadLoaiPhong()
        //{
        //    string query = "SELECT * FROM LoaiPhong";
        //    DataTable dataTable = KetNoi.Execute(query);

        //    cbLoaiPhong.Items.Clear();
        //    cbLoaiPhong1.Items.Clear();

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        cbLoaiPhong.Items.Add(row["TenLoaiPhong"].ToString());
        //        cbLoaiPhong1.Items.Add(row["TenLoaiPhong"].ToString());
        //    }
        //}

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string LoaiPhong = cbLoaiPhong.Text;
                string SoPhong = txtSoPhong.Text;
                string TienIch = GetTienIch();
                string Gia1Ngay = txtGia1Ngay.Text;
                string TinhTrang = "Trống";

                string qr = "SELECT MaLoai FROM LoaiPhong WHERE TenLoaiPhong = N'" + LoaiPhong + "'";
                DataTable dt = KetNoi.Execute(qr);
                int MaLoai = Convert.ToInt32(dt.Rows[0]["MaLoai"]);

                string CheckQuery = "SELECT * FROM Phong WHERE TenPhong = N'" + SoPhong + "'";
                DataTable dt1 = KetNoi.Execute(CheckQuery);
                if (dt1.Rows.Count > 0)
                {
                    MessageBox.Show("Số phòng đã tồn tại", "Thông báo");
                }
                else
                {
                    string query = "INSERT INTO Phong VALUES ('" + MaLoai + "', N'" + LoaiPhong + "', N'" + SoPhong + "'," +
                    "N'" + TienIch + "', '" + Gia1Ngay + "', N'" + TinhTrang + "')";
                    KetNoi.ExecuteNonQuery(query);
                    MessageBox.Show("Đã thêm thành công", "Thông báo");
                    LoadData();
                    Refesh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGVPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            int index = dataGVPhong.CurrentRow.Index;
            txtMaPhong.Text = dataGVPhong.Rows[index].Cells[0].Value.ToString();
            txtMaLoaiPhong.Text = dataGVPhong.Rows[index].Cells[1].Value.ToString();
            cbLoaiPhong.Text = dataGVPhong.Rows[index].Cells[2].Value.ToString();
            txtSoPhong.Text = dataGVPhong.Rows[index].Cells[3].Value.ToString();

            UncheckAllInGrb(grbTienIch);
            string TienIch = dataGVPhong.Rows[index].Cells[4].Value.ToString();
            if (TienIch.Contains("1 Giường")) rb1Giuong.Checked = true;
            if (TienIch.Contains("2 Giường")) rb2Giuong.Checked = true;
            if (TienIch.Contains("3 Giường")) rb3Giuong.Checked = true;
            if (TienIch.Contains("4 Giường")) rb4Giuong.Checked = true;
            if (TienIch.Contains("Bồn tắm")) ckbBonTam.Checked = true;
            if (TienIch.Contains("Tủ lạnh")) ckbTuLanh.Checked = true;
            if (TienIch.Contains("Hồ bơi")) ckbHoBoi.Checked = true;

            txtGia1Ngay.Text = dataGVPhong.Rows[index].Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string LoaiPhong = cbLoaiPhong.Text;
                int MaPhong = int.Parse(txtMaPhong.Text);
                string SoPhong = txtSoPhong.Text;
                string TienIch = GetTienIch();
                string Gia1Ngay = txtGia1Ngay.Text;
                string TinhTrang = "Trống";

                string qr = "SELECT MaLoai FROM LoaiPhong WHERE TenLoaiPhong = N'" + LoaiPhong + "'";
                DataTable dt = KetNoi.Execute(qr);
                int MaLoai = Convert.ToInt32(dt.Rows[0]["MaLoai"]);

                string query = "UPDATE Phong SET MaLoai = N'" + MaLoai + "'," +
                    "TenLoaiPhong = N'" + LoaiPhong + "'," +
                    "TenPhong = N'" + SoPhong + "'," +
                    "TienIch = N'" + TienIch + "'," +
                    "Gia1Ngay = N'" + Gia1Ngay + "'," +
                    "TinhTrang = N'" + TinhTrang + "'" +
                    "WHERE MaPhong = " + MaPhong;
                DataTable dt1 = KetNoi.Execute(query);
                if (dt1.Rows.Count > 0) MessageBox.Show("Đã sửa thành công", "Thông báo");                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData();
                Refesh();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int MaPhong = int.Parse(txtMaPhong.Text);
                string query = "DELETE FROM Phong WHERE MaPhong = " + MaPhong;
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    KetNoi.ExecuteNonQuery(query);
                    MessageBox.Show("Đã xóa thành công", "Thông báo");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData();
                Refesh();
            }
        }

        private void picRefesh_MouseEnter(object sender, EventArgs e)
        {
            picRefesh.BackColor = SystemColors.WindowFrame;
        }

        private void picRefesh_MouseLeave(object sender, EventArgs e)
        {
            picRefesh.BackColor = originalColor;
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
            Refesh();
            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string qr = TimKiem();
                dataGVPhong.DataSource = KetNoi.Execute(qr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cbLoaiPhong1.Text = string.Empty;
            }
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                int MaPhong = int.Parse(txtMaPhong.Text);
                string SoPhong = txtSoPhong.Text;
                string qr = "SELECT TinhTrang FROM Phong WHERE MaPhong = " + MaPhong;
                DataTable dt = KetNoi.Execute(qr);
                string TinhTrang = Convert.ToString(dt.Rows[0]["TinhTrang"]);
                if (TinhTrang == "Trống")
                {
                    SharedData.MaPhong = int.Parse(txtMaPhong.Text);
                    SharedData.LoaiPhong = cbLoaiPhong.Text;
                    SharedData.SoPhong = txtSoPhong.Text;

                    MessageBox.Show("Đã đặt thành công " + SoPhong, "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.None);

                    DatPhong frmDatPhong = new DatPhong();
                    frmDatPhong.ShowDialog();
                    this.Hide();
                    this.Close();
                }
                else
                    MessageBox.Show("Phòng đã được đặt trước", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData();
                Refesh();
                cbLoaiPhong1.Text = string.Empty;
            }
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void txtGia1Ngay_TextChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void rb1Giuong_CheckedChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void rb2Giuong_CheckedChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void rb3Giuong_CheckedChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void rb4Giuong_CheckedChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void txtGia1Ngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
