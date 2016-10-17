using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace kursov
{
    public partial class BuyTovar : Form
    {
        private int Price;
        private double CursDol;
        class HelperSelected
        {
            public string name { get; set; }
            public int price { get; set; }
        }
        public BuyTovar(string tempname)
        {
            InitializeComponent();
            label1.Text = tempname;
            CursDol = GET("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            if (tempname == "Бетон")
            {
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "price";
                listBox1.Items.Add(new HelperSelected { name = "2 вид 200", price = 200 });
                listBox1.Items.Add(new HelperSelected { name = "1 вид 100", price = 100 });
                listBox1.SelectedIndex = 0;
            }
            if (tempname == "Керамзитобетон")
            {
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "price";
                listBox1.Items.Add(new HelperSelected { name = "user1", price = 100 });
                listBox1.SelectedIndex = 0;
            }
            if (tempname == "Асфальтобетон")
            {
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "price";
                listBox1.Items.Add(new HelperSelected { name = "user1", price = 100 });
                listBox1.SelectedIndex = 0;
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
                label12.Text =(int.Parse(Count.Text) * Price /  Math.Round(CursDol, 2)).ToString() + "$";
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelperSelected temp = (HelperSelected)listBox1.SelectedItem;
            Count.Text = "0";
            label9.Text = "0";
            label12.Text = "0";
            Price = temp.price;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        private static double GET(string Url)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string xmlString = sr.ReadToEnd();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("ecb", "http://www.ecb.int/vocabulary/2002-08-01/eurofxref");
            nsmgr.AddNamespace("gesmes", "http://www.gesmes.org/xml/2002-08-01");
            XmlNode currencyNode = xml.SelectSingleNode("descendant::ecb:Cube[@currency='RUB']", nsmgr);
            string rate = currencyNode.Attributes.GetNamedItem("rate").Value.Trim().Replace(".",",");
            float drate = float.Parse(rate);
            sr.Close();
            return drate;
        }
    }
}