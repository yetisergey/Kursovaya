using Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Admin
{

    public partial class Form1 : Form
    {
        public static Form1 selfRef { get; set; }
        public void UpdateGrid()
        {
            using (BaseContext db = new BaseContext())
            {
                dataGridView1.DataSource = db.Products.Select(u => new
                {
                    IdProduct = u.IdProduct,
                    NameProduct = u.Name,
                    NameGroup = u.NameGroup.ToString(),
                    Price = u.Price,
                    Count = u.Count
                }).ToList();
            }
        }

        public Form1()
        {
            InitializeComponent();
            UpdateGrid();
            selfRef = this;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateGrid();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SalesAll a = new SalesAll();
            a.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sales a = new Sales(-1);
            a.Width = 410;
            a.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Sales a = new Sales(id);
                a.Show();
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Users a = new Users();
            a.Show();
        }
    }
}