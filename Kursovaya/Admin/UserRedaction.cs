using Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Admin
{
    public partial class UserRedaction : Form
    {
        private int Ident;
        public UserRedaction(int id)
        {
            Ident = id;
            InitializeComponent();
            if (id != -1)
            {
                using (BaseContext db = new BaseContext())
                {
                    var temp = db.UsersAdmin.Find(id);
                    textBox1.Text = temp.Login;
                    textBox2.Text = temp.Password;
                }
            }
            else {
                button1.Hide();
                button2.Text = "Создать";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BaseContext db = new BaseContext())
            {
                User temp = db.UsersAdmin.First(x => x.Id == Ident);
                db.UsersAdmin.Remove(temp);
                db.SaveChanges();
                Users.selfRef.Update();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Ident != -1)
            {
                using (BaseContext db = new BaseContext())
                {
                    var temp = db.UsersAdmin.Find(Ident);
                    textBox1.Text = temp.Login;
                    textBox2.Text = temp.Password;
                    db.SaveChanges();
                    Users.selfRef.Update();
                    Close();
                }
            }
            else {
                using (BaseContext db = new BaseContext())
                {
                    db.UsersAdmin.Add(new User { Login = textBox1.Text, Password = textBox2.Text });
                    db.SaveChanges();
                    Users.selfRef.Update();
                    Close();
                }
            }
        }
    }
}
