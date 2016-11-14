using Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Admin
{
    public partial class Users : Form
    {
        public static Users selfRef;
        public new void Update()
        {
            using (BaseContext db = new BaseContext())
            {
                dataGridView1.DataSource = db.UsersAdmin.ToList();
            }
        }
        public Users()
        {
            selfRef = this;
            InitializeComponent();
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRedaction a = new UserRedaction(-1);
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                UserRedaction a = new UserRedaction(id);
                a.Show();
            }
        }
    }
}
