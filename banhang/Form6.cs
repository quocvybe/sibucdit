using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace banhang
{
    public partial class Form6 : Form
    {
        banhangEntities a = new banhangEntities();

        public Form6()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = a.SanPhams.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xóa");
            }
            else
            {
                if (a.SanPhams.FirstOrDefault(x => x.id_sanpham == textBox1.TextLength) != null)
                {
                    MessageBox.Show("Sản phẩm muốn xóa không tồn tại");

                }
                else

                {
                  var xoa = a.SanPhams.FirstOrDefault(x => x.id_sanpham == textBox1.TextLength);
                    a.SanPhams.Remove(xoa); 
                    a.SaveChanges();
                    dataGridView1.DataSource = a.SanPhams.ToList();
                    MessageBox.Show("Xóa thành công");

                }
            }
                }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin");
            }
            else
            {
                var sua = a.SanPhams.FirstOrDefault(x => x.id_sanpham == textBox1.TextLength);
                sua.id_sanpham = textBox1.TextLength;
                sua.ten_sanpham = textBox2.Text;
                sua.mo_ta = textBox3.Text;
                sua.gia = int.Parse(textBox4.Text);
                sua.so_luong_kho = int.Parse(textBox5.Text);
                sua.id_danhmuc = textBox6.TextLength;
                a.SaveChanges();
                dataGridView1.DataSource = a.SanPhams.ToList();
                MessageBox.Show("Lưu thông tin thành công");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin");
            }
            else
            {
                if (a.SanPhams.FirstOrDefault(x => x.id_sanpham == textBox1.TextLength) != null)
                {
                    MessageBox.Show("Sản phẩm này đã tồn tại");

                }
                else

                {
                    SanPham sp = new SanPham();
                    sp.id_sanpham = textBox1.TextLength;
                    sp.ten_sanpham = textBox2.Text;
                    sp.mo_ta = textBox3.Text;
                    sp.gia = int.Parse(textBox4.Text);
                    sp.so_luong_kho = int.Parse(textBox5.Text);
                    sp.id_danhmuc = textBox6.TextLength;
                    a.SaveChanges();
                    dataGridView1.DataSource = a.SanPhams.ToList();
                    MessageBox.Show("Thêm thành công");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

