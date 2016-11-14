
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Index : Form
    {
        public Index()
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

    }
}
