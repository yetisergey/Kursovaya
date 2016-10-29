using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (BaseContext db = new BaseContext()) {
                dataGridView1.DataSource = db.Products.Select(u => new {
                    IdProduct = u.IdProduct,
                    NameProduct = u.Name,
                    NameGroup = u.NameGroup.ToString(),
                    Price = u.Price,
                    Count = u.Count
                }).ToList();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
        }
    }
}
