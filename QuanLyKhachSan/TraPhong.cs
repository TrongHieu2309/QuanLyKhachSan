using System;
using System.Collections;
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
    public partial class TraPhong : Form
    {
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        private int _gia1ngay;
        private int _tratruoc = 0;
        private int _conlai = 0;
        private int _tongtien = 0;
        private Color originalColor;

        public TraPhong()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string qr = "SELECT * FROM TraPhong";
            dataGVTraPhong.DataSource = KetNoi.Execute(qr);
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0) dataGVTraPhong.Enabled = true;
            else dataGVTraPhong.Enabled = false;
        }

        private void Refesh()
        {
            txtMaTK.Text = string.Empty;
            txtMaPhong.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtTenDV.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtLoaiPhong.Text = string.Empty;
            txtSoPhong.Text = string.Empty;
            txtGiaDV.Text = string.Empty;
            dateNgayDen.Value = DateTime.Now;
            dateNgayDi.Value = DateTime.Now;
            txtSdt.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtTenDV.Text = string.Empty;
            txtGiaDV.Text = string.Empty;
            btnThanhToan.Enabled = false;
        }

        private void TraPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            btnThanhToan.Enabled = false;
            picRefesh.BackColor = originalColor;
        }

        private void dataGVTraPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThanhToan.Enabled = true;

            int index = dataGVTraPhong.CurrentRow.Index;
            txtMaTraPhong.Text = dataGVTraPhong.Rows[index].Cells[0].Value.ToString();
            txtMaTK.Text = dataGVTraPhong.Rows[index].Cells[1].Value.ToString();
            txtMaPhong.Text = dataGVTraPhong.Rows[index].Cells[2].Value.ToString();
            txtMaKH.Text = dataGVTraPhong.Rows[index].Cells[3].Value.ToString();
            txtTenKH.Text = dataGVTraPhong.Rows[index].Cells[4].Value.ToString();
            txtLoaiPhong.Text = dataGVTraPhong.Rows[index].Cells[5].Value.ToString();
            txtSoPhong.Text = dataGVTraPhong.Rows[index].Cells[6].Value.ToString();
            txtSoLuong.Text = dataGVTraPhong.Rows[index].Cells[7].Value.ToString();
            dateNgayDen.Text = dataGVTraPhong.Rows[index].Cells[8].Value.ToString();
            dateNgayDi.Text = dataGVTraPhong.Rows[index].Cells[9].Value.ToString();
            txtSdt.Text = dataGVTraPhong.Rows[index].Cells[10].Value.ToString();

            string qrThanhToan = "SELECT * FROM ThanhToan WHERE MaKH = '" + txtMaKH.Text + "' " +
                "AND TinhTrang != N'" + "Đã thanh toán" + "'";
            DataTable dtThanhToan = KetNoi.Execute(qrThanhToan);

            if (dtThanhToan.Rows.Count > 0)
            {
                _tongtien = Convert.ToInt32(dtThanhToan.Rows[0]["TongTien"]);
                _tratruoc = Convert.ToInt32(dtThanhToan.Rows[0]["TraTruoc"]);
                _conlai = Convert.ToInt32(dtThanhToan.Rows[0]["ConLai"]);
            }
            txtTongTien.Text = _tongtien.ToString();
            txtDaTra.Text = _tratruoc.ToString();
            txtConLai.Text = _conlai.ToString();

            // Nếu có sử dụng dịch vụ thì cộng vào tổng tiền
            string MaKH = txtMaKH.Text;
            string MaPhong = txtMaPhong.Text;
            string qrDV = "SELECT TenLoaiDV, GiaLoaiDV FROM DichVu WHERE MaKH = " + MaKH;
            DataTable dtDV = KetNoi.Execute(qrDV);
            if (dtDV.Rows.Count > 0)
            {
                string TenDV = Convert.ToString(dtDV.Rows[0]["TenLoaiDV"]);
                int GiaDV = Convert.ToInt32(dtDV.Rows[0]["GiaLoaiDV"]);
                txtTenDV.Text = TenDV;
                txtGiaDV.Text = GiaDV.ToString();

                //// Tính toán TongTien
                //DateTime ngayDen = DateTime.Parse(dataGVTraPhong.Rows[index].Cells[8].Value.ToString());
                //DateTime ngayDi = DateTime.Parse(dataGVTraPhong.Rows[index].Cells[9].Value.ToString());
                //int SoNgay = (ngayDi - ngayDen).Days;

                //string qr = "SELECT Gia1Ngay FROM Phong WHERE MaPhong = '" + MaPhong + "'";
                //DataTable dt = KetNoi.Execute(qr);
                //if (dt.Rows.Count > 0)
                //{
                //    _gia1ngay = Convert.ToInt32(dt.Rows[0]["Gia1Ngay"]);
                //}

                //int TongTien = (SoNgay * _gia1ngay) + GiaDV;

                //txtTongTien.Text = TongTien.ToString();
            }
            //else
            //{
            //    // Tính toán TongTien
            //    DateTime ngayDen = DateTime.Parse(dataGVTraPhong.Rows[index].Cells[8].Value.ToString());
            //    DateTime ngayDi = DateTime.Parse(dataGVTraPhong.Rows[index].Cells[9].Value.ToString());
            //    int SoNgay = (ngayDi - ngayDen).Days;

            //    string qr = "SELECT Gia1Ngay FROM Phong WHERE MaPhong = '" + MaPhong + "'";
            //    DataTable dt = KetNoi.Execute(qr);
            //    if (dt.Rows.Count > 0)
            //    {
            //        _gia1ngay = Convert.ToInt32(dt.Rows[0]["Gia1Ngay"]);
            //    }

            //    int TongTien = SoNgay * _gia1ngay;

            //    txtTongTien.Text = TongTien.ToString();
            //}
        }        

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string MaTraPhong = txtMaTraPhong.Text;
                string qrTraPh = "SELECT TinhTrang FROM TraPhong WHERE MaTraPhong = " + MaTraPhong;
                DataTable dtTTr = KetNoi.Execute(qrTraPh);
                string TinhTrangTT = dtTTr.Rows[0]["TinhTrang"].ToString();
                if (TinhTrangTT == "Đã thanh toán")
                {
                    MessageBox.Show("Khách hàng đã thanh toán", "Thông báo");
                }
                else
                {
                    string MaKH = txtMaKH.Text;
                    string TenKH = txtTenKH.Text;
                    string LoaiPhong = txtLoaiPhong.Text;
                    string SoPhong = txtSoPhong.Text;
                    string TenDV = txtTenDV.Text;
                    DateTime NgayDen = dateNgayDen.Value;
                    DateTime NgayDi = dateNgayDi.Value;
                    string Sdt = txtSdt.Text;

                    // Đảm bảo ngày tháng được định dạng chính xác cho SQL Server
                    string NgayDenStr = NgayDen.ToString("MM/dd/yyyy");
                    string NgayDiStr = NgayDi.ToString("MM/dd/yyyy");

                    string TinhTrang = "Trống";
                    string TinhTrang1 = "Đã thanh toán";
                    string MaPhong = txtMaPhong.Text;
                    string SoLuong = txtSoLuong.Text;
                    string GiaDV = txtGiaDV.Text;
                    int TongTien = int.Parse(txtTongTien.Text);
                    int TraTruoc = int.Parse(txtDaTra.Text);
                    int ConLai = int.Parse(txtConLai.Text);
                    int Gia1Ngay = 0;
                    string qr1 = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' " +
                        "WHERE MaPhong = '" + MaPhong + "'";
                    string qrGia1Ngay = "SELECT Gia1Ngay FROM Phong WHERE MaPhong = '" + MaPhong + "'";
                    DataTable dt = KetNoi.Execute(qrGia1Ngay);
                    if (dt.Rows.Count > 0)
                    {
                        Gia1Ngay = Convert.ToInt32(dt.Rows[0]["Gia1Ngay"]);
                    }
                    string qr = "UPDATE TraPhong SET TinhTrang = N'" + TinhTrang1 + "' " +
                        "WHERE MaPhong = '" + MaPhong + "'";

                    //string qrThanhToan = "SELECT * FROM ThanhToan WHERE MaKH = '" + MaKH + "'";
                    //DataTable dtThanhToan = KetNoi.Execute(qrThanhToan);
                                        
                    //if (dtThanhToan.Rows.Count > 0)
                    //{
                    //    _tratruoc = Convert.ToInt32(dtThanhToan.Rows[0]["TraTruoc"]);
                    //    _conlai = Convert.ToInt32(dtThanhToan.Rows[0]["ConLai"]);
                    //}

                    string qrHD = "INSERT INTO HoaDon VALUES ('" + MaKH + "', N'" + TenKH + "', N'" + LoaiPhong + "'," +
                        " N'" + SoPhong + "', '" + SoLuong + "', N'" + TenDV + "', '" + GiaDV + "', '" + Gia1Ngay + "'," +
                        " '" + NgayDenStr + "', '" + NgayDiStr + "', '" + Sdt + "', '" + TongTien + "', '" + TraTruoc + "', '" + ConLai + "')";
                    if (TenDV == string.Empty && GiaDV == string.Empty)
                    {
                        DialogResult result = MessageBox.Show("Tổng tiền của quý khách là: " + TongTien + "\nQuý khách có chắc muốn thanh toán?", 
                            "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Cảm ơn quý khách\nXin chào và hẹn gặp lại", "Cảm ơn");
                            dataGVTraPhong.DataSource = KetNoi.Execute(qr);
                            KetNoi.ExecuteNonQuery(qr1);
                            KetNoi.ExecuteNonQuery(qrHD);
                            string qrThanhToan = "UPDATE ThanhToan SET TinhTrang = N'" + TinhTrang1 + "' " +
                                "WHERE MaKH = '" + MaKH + "'";
                            KetNoi.ExecuteNonQuery(qrThanhToan);
                        }
                    }
                    else
                    {
                        DialogResult result1 = MessageBox.Show("Tổng tiền của quý khách bao gồm dịch vụ " + TenDV + "" +
                        " là: " + TongTien + "\nQuý khách có chắc muốn thanh toán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1 == DialogResult.Yes)
                        {
                            MessageBox.Show("Cảm ơn quý khách\nXin chào và hẹn gặp lại", "Cảm ơn");
                            dataGVTraPhong.DataSource = KetNoi.Execute(qr);
                            KetNoi.ExecuteNonQuery(qr1);
                            KetNoi.ExecuteNonQuery(qrHD);
                            string qrThanhToan = "UPDATE ThanhToan SET TinhTrang = N'" + TinhTrang1 + "' " +
                                "WHERE MaKH = '" + MaKH + "'";
                            KetNoi.ExecuteNonQuery(qrThanhToan);
                        }
                    }
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

        private void picRefesh_Click(object sender, EventArgs e)
        {
            Refesh();
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
    }
}
