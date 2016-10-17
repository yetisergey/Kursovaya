using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursov
{
    public partial class BuyYsl : Form
    {
        public BuyYsl(string tempstr,int price)
        {
            InitializeComponent();
            label1.Text = tempstr;
            label8.Text = price.ToString();
        }
    }
}
