using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banhang
{
    public partial class Form4 : Form
    {
        banhangEntities a = new banhangEntities();

        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Điền ttSTK hoặc để trống";
            comboBox1.ForeColor = Color.Gray;
            comboBox1.BringToFront();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string tenKhachHang = textBox6.Text.Trim();
            string email = textBox1.Text.Trim();
            string soDienThoai = textBox3.Text.Trim();
            string diaChi = textBox4.Text.Trim();
            string matKhau = textBox2.Text.Trim();
            string thanhToan = comboBox1.SelectedItem?.ToString() ?? "Chưa thanh toán";

            // Kiểm tra nhập đầy đủ thông tin
            if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi) ||
                string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email hoặc số điện thoại đã tồn tại chưa
            var existingUser = a.KhachHangs.FirstOrDefault(kh => kh.email == email || kh.so_dienthoai == soDienThoai);
            if (existingUser != null)
            {
                MessageBox.Show("Email hoặc số điện thoại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KhachHang newKhachHang = new KhachHang
            {
                ten_khachhang = tenKhachHang,
                email = email,
                so_dienthoai = soDienThoai,
                diachi = diaChi,
                matkhau_hash = matKhau, // Lưu trực tiếp mật khẩu (không hash)
                ngay_tao = DateTime.Now, // Lưu ngày tạo tự động
                thanhtoan = thanhToan
            };

            a.KhachHangs.Add(newKhachHang);

            try
            {
                a.SaveChanges();
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 h = new Form2();
            h.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
