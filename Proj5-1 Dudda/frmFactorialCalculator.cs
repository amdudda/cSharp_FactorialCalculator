using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj5_1_Dudda
{
    public partial class frmFactorialCalculator : Form
    {
        public frmFactorialCalculator()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // throw new Exception();
                string toFactorialize = txtNumber.Text;
                if (IsBetween1and20(toFactorialize))
                {
                    Factorialize(toFactorialize);
                }
            }
            catch (OverflowException)
            {
                // our data validation should prevent this from ever happening, but let's be really sure.
                MessageBox.Show("The factorial got too large.  Try a smaller number.", "Overflow Exception");
            }
            catch (Exception ex)
            {
                // hopefully this never happens, but Just In Case...
                string myMsg = "Something unexpected went wrong.  Here's some details you can give to your IT department.\n\n";
                MessageBox.Show(
                    myMsg + ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace,
                    "Oops! An error occurred."
                    );
            }
        }

        private void Factorialize(string toFactorialize)
        {
            short toFactor = Convert.ToInt16(toFactorialize);
            double result = 1;

            for (int i = 1; i <= toFactor; i++)
            {
                result *= i;
            }

            txtFactorial.Text = result.ToString("n0");
        }

        private bool IsBetween1and20(string toCheck)
        {
            short num;
            if (short.TryParse(toCheck, out num) && num > 0 && num < 21) {
                return true;
            }
            else  {
                MessageBox.Show("Please enter a number between 1 and 20 to factorialize.");
                txtNumber.Focus();
                return false;
            }
        }
 
    }
}
