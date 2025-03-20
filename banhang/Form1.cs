using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace banhang
{
    public partial class Form1 : Form
    {
        banhangEntities a  = new banhangEntities();
        public Form1(KhachHang kh)
        {
            InitializeComponent();
            label6.Text = kh.ten_khachhang;
            button2.Visible = false;          
            button1.Visible = true;


        }

        public Form1()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 h = new Form2();
            h.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var mt = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 1);
            if (mt != null)
            {
                label8.Text = mt.mo_ta;       
            }
            var mt2 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 1);
            if (mt2 != null)
            {
                label9.Text = mt2.mo_ta;
            }
            var mt3 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 1);
            if (mt3 != null)
            {
                label10.Text = mt3.mo_ta;
            }
            var mt4 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 1);
            if (mt4 != null)
            {
                label11.Text = mt4.mo_ta;
            }
            if (label6.Text == "Admin")
            {
                qUẢNLÝHÀNGToolStripMenuItem.Visible = true;
            }    
            listView1.View = View.Details;
            listView1.Columns.Add("Tên sản phẩm", 150);
            listView1.Columns.Add("Giá", 150);
            var sanpham = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 1);
            label1.Text = sanpham.ten_sanpham;
            var sanpham2 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 2);
            label2.Text = sanpham2.ten_sanpham;
            var sanpham3 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 3);
            label3.Text = sanpham3.ten_sanpham;
            var sanpham4 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 4);
            label4.Text = sanpham4.ten_sanpham;
            var mtsanpham = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 1);
            label9.Text = mtsanpham != null ? mtsanpham.gia.ToString() : "N/A";

            var mtsanpham2 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 2);
            label10.Text = mtsanpham2 != null ? mtsanpham2.gia.ToString() : "N/A";

            var mtsanpham3 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 3);
            label11.Text = mtsanpham3 != null ? mtsanpham3.gia.ToString() : "N/A";

            var mtsanpham4 = a.SanPhams.FirstOrDefault(sp => sp.id_sanpham == 4);
            label12.Text = mtsanpham4 != null ? mtsanpham4.gia.ToString() : "N/A";

        }
        private void button3_Click(object sender, EventArgs e)
        {

            string tenSanPham = label1.Text;
            string giaSanPham = label9.Text;

            ListViewItem item = new ListViewItem(tenSanPham);
            item.SubItems.Add(giaSanPham);

            listView1.Items.Add(item);
        }



        private void button1_Click(object sender, EventArgs e)
    {
        Form2 h = new Form2();
        h.Show();
        this.Hide();
    }
    private void điệnThoạiToolStripMenuItem_Click(object sender, EventArgs e)
    {

        }

        private void laptopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void phụKiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
                string tenSanPham = label3.Text;  
                string giaSanPham = label10.Text;  

                ListViewItem item = new ListViewItem(tenSanPham);
                item.SubItems.Add(giaSanPham);

                listView1.Items.Add(item);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tenSanPham = label2.Text;
            string giaSanPham = label11.Text;

            ListViewItem item = new ListViewItem(tenSanPham);
            item.SubItems.Add(giaSanPham);

            listView1.Items.Add(item);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string tenSanPham = label4.Text;
            string giaSanPham = label12.Text;

            ListViewItem item = new ListViewItem(tenSanPham);
            item.SubItems.Add(giaSanPham);

            listView1.Items.Add(item);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) 
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item); 
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double tongTien = 0; 

            foreach (ListViewItem item in listView1.Items)
            {
                tongTien += Convert.ToDouble(item.SubItems[1].Text); 
            }

            label7.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VND"; 
        }

        private void tHÔNGTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var user = a.KhachHangs.FirstOrDefault(x => x.ten_khachhang == label6.Text);

            if (user != null )
            {
                Form3 h = new Form3(user);
                h.Show();
            }

            else
            {
                MessageBox.Show("Bạn chưa đăng nhập");
            }
        }

        private void qUẢNLÝHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 h = new Form6();
            h.Show();
            this.Hide();
        }

        private void dANHMỤCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                    }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 h = new Form5();
            h.Show();
            this.Hide();
        }
    }
}