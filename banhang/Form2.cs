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
    public partial class Form2 : Form
    {
        banhangEntities a = new banhangEntities();
        public Form2()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Bạn chưa nhâp đủ thông tin");
            }
            else
            {
                ;
                var user = a.KhachHangs.FirstOrDefault(x => x.email == textBox1.Text);
                var mk = a.KhachHangs.FirstOrDefault(x => x.matkhau_hash == textBox2.Text);


                if (user != null && mk != null)
                {
                    Form1 h = new Form1(user);
                    h.Show();
                    this.Hide();
                    MessageBox.Show("Đăng nhâp thành công");
                }

                else
                {
                    MessageBox.Show("Thông tin khônh chính xác");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form4 h = new Form4();
            h.Show();
            this.Hide();
        }
    }
}    