
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linklabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyTovar BuyForm = new BuyTovar(linklabel1.Text);
            BuyForm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyTovar BuyForm = new BuyTovar(linkLabel2.Text);
            BuyForm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyTovar BuyForm = new BuyTovar(linkLabel3.Text);
            BuyForm.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyYsl BuyForm = new BuyYsl(linkLabel4.Text,30000);
            BuyForm.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyYsl BuyForm = new BuyYsl(linkLabel5.Text,40000);
            BuyForm.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyYsl BuyForm = new BuyYsl(linkLabel6.Text,10000);
            BuyForm.Show();
        }
    }
}
