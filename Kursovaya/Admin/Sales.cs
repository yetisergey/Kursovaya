using Data;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Admin
{
    public partial class Sales : Form
    {
        private int IdentNum;
        public Sales(int Id)
        {

            IdentNum = Id;
            InitializeComponent();
            comboBox1.DataSource = System.Enum.GetNames(typeof(Namegroup)).ToList(); ;
            if (Id == -1)
            {
                label4.Text = "Создание продукта";
                button2.Text = "Закрыть";
            }
            else {
                button2.Text = "Удалить";
                label4.Text = "Редактирование продукта";
                using (BaseContext db = new BaseContext())
                {
                    var temp = db.Products.Find(Id);
                    textBox1.Text = temp.Name;
                    textBox2.Text = temp.Price.ToString();
                    comboBox1.SelectedIndex = temp.NameGroup.GetHashCode();
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (IdentNum == -1)
            {
                using (BaseContext db = new BaseContext())
                {
                    db.Products.Add(new Product
                    {
                        Name = textBox1.Text,
                        Price = int.Parse(textBox2.Text),
                        NameGroup = (Namegroup)comboBox1.SelectedIndex
                    });
                    db.SaveChanges();
                }

                Close();
                Form1.selfRef.UpdateGrid();
            }
            else {
                using (BaseContext db = new BaseContext())
                {
                    var temp = db.Products.Find(IdentNum);
                    temp.Name = textBox1.Text;
                    temp.Price = int.Parse(textBox2.Text);
                    temp.NameGroup = (Namegroup)comboBox1.SelectedIndex;
                    db.SaveChanges();
                }

                Close();
                Form1.selfRef.UpdateGrid();
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (IdentNum == -1)
            {
                Close();
            }
            else {
                using (BaseContext db = new BaseContext())
                {
                    Product temp = db.Products.First(x => x.IdProduct == IdentNum);
                    db.Products.Remove(temp);
                    db.SaveChanges();
                }

                Close();
                Form1.selfRef.UpdateGrid();
            }
        }
    }
}
