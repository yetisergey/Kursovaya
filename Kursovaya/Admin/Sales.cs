using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
                    label5.Text = temp.Count.ToString();

                    //статистика
                    var list = db.Purchases.Where(p => p.IdProduct == IdentNum).ToList();
                    var temparr = from i in list
                                  group i by new { i.Date.Month,i.Date.Year } into grp
                                  select new { Month = grp.Key, Count = grp.Sum(i => i.Counttovar) };

                    var res = temparr.ToList().OrderBy(u => u.Month.Month).OrderBy(u => u.Month.Year).Take(5);
                        

                    Series series = chart1.Series.Add(temp.Name);

                    foreach (var u in res)
                    {
                        series.Points.Add(u.Count);
                    }
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
                        NameGroup = (Namegroup)comboBox1.SelectedIndex,
                        Count = int.Parse(label5.Text)                        
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
                    temp.Count = int.Parse(label5.Text);
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

        private void button4_Click(object sender, System.EventArgs e)
        {
            label5.Text = (int.Parse(label5.Text)+1).ToString();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            label5.Text = (int.Parse(label5.Text) - 1).ToString();

        }
    }
}