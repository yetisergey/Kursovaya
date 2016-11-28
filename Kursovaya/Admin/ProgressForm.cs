using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class ProgressForm : Form
    {
        public static ProgressForm selfRef { get; set; }
        public ProgressForm()
        {
            InitializeComponent();
            progressBar1.Value = 0;
            selfRef = this;
        }
        public void SetProgress(int i)
        {
            progressBar1.Increment(i);
        }
        public void SetAll()
        {
            progressBar1.Value =100;
            Close();
        }
        public void ShowHideProgress()
        {
            if (progressBar1.Visible == true)
            {

                progressBar1.Hide();
            }
            else {
                progressBar1.Value = 0;
                progressBar1.Show();

            }
        }
    }
}
