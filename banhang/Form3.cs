using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banhang
{
    public partial class Form3 : Form
    {
        banhangEntities a = new banhangEntities();

        public Form3(KhachHang kh)
        {
            InitializeComponent();
            label6.Text = kh.ten_khachhang;
            label7.Text = kh.email;
            label8.Text = kh.so_dienthoai;
            label9.Text = kh.ngay_tao.Value.ToString();
            label10.Text = kh.thanhtoan;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 h = new Form1();
            h.Show();
            this.Hide();
        }
    }
}
