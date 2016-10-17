using System;
using System.Windows.Forms;

namespace Client
{
    public partial class BuyYsl : Form
    {
        public BuyYsl(string tempstr,int price)
        {
            InitializeComponent();
            label1.Text = tempstr;
            label8.Text = price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
