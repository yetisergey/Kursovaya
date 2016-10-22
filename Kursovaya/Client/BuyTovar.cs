using Data;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Client
{
    public partial class BuyTovar : Form
    {
        private Product Glpr;
        private int Price;
        private double CursDol;
        class HelperSelected
        {
            public int id { get; set; }
            public string name { get; set; }
            public int price { get; set; }
        }
        public BuyTovar(string tempname)
        {
            InitializeComponent();
            label1.Text = tempname;
            CursDol = GET("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            listBox1.DisplayMember = "Name";
            //listBox1.ValueMember = "price";
            if (tempname == "Железобетон")
            {
                using (BaseContext db = new BaseContext())
                {
                    foreach (Product u
                        in db.Products
                        .Where(e => e.NameGroup == Namegroup.IronBeton)
                        .ToList())
                    {
                        listBox1.Items.Add(u);
                    };
                    listBox1.SelectedIndex = 0;
                };
            }

            if (tempname == "Керамзитобетон")
            {
                using (BaseContext db = new BaseContext())
                {
                    foreach (Product u in db.Products
                        .Where(e => e.NameGroup == Namegroup.KeramzBeton)
                        .ToList())
                    {
                        listBox1.Items.Add(u);
                    };
                    listBox1.SelectedIndex = 0;
                };
            }

            if (tempname == "Асфальтобетон")
            {
                using (BaseContext db = new BaseContext())
                {
                    foreach (Product u in db.Products
                        .Where(e => e.NameGroup == Namegroup.AsphaltBeton)
                        .ToList())
                    {
                        listBox1.Items.Add(u);
                    };
                    listBox1.SelectedIndex = 0;
                };
            }

            if (tempname == "Силикатный бетон")
            {
                using (BaseContext db = new BaseContext())
                {
                    foreach (Product u in db.Products
                        .Where(e => e.NameGroup == Namegroup.SilicBeton)
                        .ToList())
                    {
                        listBox1.Items.Add(u);
                    };
                    listBox1.SelectedIndex = 0;
                };
            }

            if (tempname == "Гидротехнический бетон")
            {

                using (BaseContext db = new BaseContext())
                {
                    foreach (Product u
                        in db.Products
                        .Where(e => e.NameGroup == Namegroup.HidroBeton)
                        .ToList())
                    {
                        listBox1.Items.Add(u);
                    };
                    listBox1.SelectedIndex = 0;
                };
            }

            if (tempname == "Перлитобетон")
            {
                using (BaseContext db = new BaseContext())
                {
                    foreach (Product u in db.Products
                        .Where(e => e.NameGroup == Namegroup.PerlitBeton)
                        .ToList())
                    {
                        listBox1.Items.Add(u);
                    };
                    listBox1.SelectedIndex = 0;
                };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Count.Text = (int.Parse(Count.Text) + 1).ToString();
            label9.Text = (int.Parse(Count.Text) * Price).ToString() + " руб";
            label12.Text = (int.Parse(Count.Text) * Price / CursDol).ToString() + "$";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(Count.Text) > 1)
            {
                Count.Text = (int.Parse(Count.Text) - 1).ToString();
                label9.Text = (int.Parse(Count.Text) * Price).ToString() + " руб";
                label12.Text = (int.Parse(Count.Text) * Price / Math.Round(CursDol, 2)).ToString() + "$";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product temp = (Product)listBox1.SelectedItem;
            Count.Text = "0";
            label9.Text = "0";
            label12.Text = "0";
            Glpr = temp;
            Price = temp.Price;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || Count.Text == "0")
            {
                MessageBox.Show("Необходимо заполнить все поля!");
            }
            else
            {
                using (BaseContext db = new BaseContext())
                {
                    Purchase obj = new Purchase();
                    obj.Fio = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
                    obj.PasportId = textBox4.Text;
                    obj.Telephone = textBox5.Text;
                    obj.Counttovar = int.Parse(Count.Text);
                    obj.Date = DateTime.Now;
                    obj.IdProduct = Glpr.IdProduct;
                    obj.Price =int.Parse(label9.Text);
                    db.Purchases.Add(obj);
                    db.SaveChanges();
                    MessageBox.Show("Заказ успешно совершён!");
                    Close();
                }
            }
        }

        private static double GET(string Url)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new System.IO.StreamReader(stream);
            string xmlString = sr.ReadToEnd();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("ecb", "http://www.ecb.int/vocabulary/2002-08-01/eurofxref");
            nsmgr.AddNamespace("gesmes", "http://www.gesmes.org/xml/2002-08-01");
            XmlNode currencyNode = xml.SelectSingleNode("descendant::ecb:Cube[@currency='RUB']", nsmgr);
            string rate = currencyNode.Attributes.GetNamedItem("rate").Value.Trim().Replace(".", ",");
            float drate = float.Parse(rate);
            sr.Close();
            return drate;
        }
    }
}