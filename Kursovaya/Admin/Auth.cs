using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Admin
{
    public partial class Auth : Form
    {
        private static List<User> abc;
        public Auth()
        {
            InitializeComponent();
            using (BaseContext db = new BaseContext()) {
                abc = db.UsersAdmin.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {
                if (abc.Where(u => u.Login == textBox1.Text&& u.Password == textBox2.Text).Count()==1)
                {
                    Form1 a = new Form1();
                    a.Show();
                    Hide();
                }
                else {
                    MessageBox.Show("Не верный логин или пароль", "Уведомление");
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                }

            }
            else {
                MessageBox.Show("Не верный логин или пароль", "Уведомление" );
            }
        }
    }
}
