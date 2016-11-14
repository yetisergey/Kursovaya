using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using hint;
using System;

namespace Admin
{
    public partial class HintForm : Form
    {
        public HintForm()
        {
            InitializeComponent();


            MWArray mas = null;
            MWNumericArray arr1 = new int[] { 1, 2, 3, 4, 5, 6 };
            mas = arr1;


            MWArray mas2 = null;
            MWNumericArray arr2 = new int[] { 10, 30, 50, 34,59, 45 };
            mas2 = arr2;

            MWArray result = null;
            try
            {
                MLHint res = new MLHint();
                result = res.hint(mas,mas2);
                MessageBox.Show(result.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}