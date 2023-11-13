 using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace The_Equation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double a;
        private double b;
        private double c;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string txta = tb_a.Text;
            string txtb = tb_b.Text;
            string txtc = tb_c.Text;
            if (txta.Contains(','))
            {
                txta = txta.Replace(',', '.');
            }
            if (txtb.Contains(','))
            {
                txtb = txtb.Replace(',', '.');
            }
            if (txtc.Contains(','))
            {
                txtc = txtc.Replace(',', '.');
            }
            if (IsValid(tb_a.Text)&&IsValid(tb_b.Text)&&IsValid(tb_c.Text))
            {
               a= Double.Parse(txta, CultureInfo.GetCultureInfo("en-GB"));
               b = Double.Parse(txtb, CultureInfo.GetCultureInfo("en-GB"));
               c = Double.Parse(txtc, CultureInfo.GetCultureInfo("en-GB"));
                double D =(double) ((b * b) - (4 * a * b));
                if (D<0) 
                {
                    MessageBox.Show("This quadratic equation has no solution !"); 
                }
                else
                {
                    if(D==0)
                    {
                        double x = (double)((-1 * b) / (2 * a));
                        MessageBox.Show("Solution : x="+x.ToString());
                    }
                    else 
                    {
                        double x1 = ((-1 * b) + Math.Sqrt(D))/ (2 * a);
                        double x2 = ((-1 * b) - Math.Sqrt(D)) / (2 * a);
                        MessageBox.Show("Solution : x1=" + x1.ToString()+" x2="+x2.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter valid numbers !");
            }
        }
        public bool IsNumeric(ref string txt)
        {
            decimal d;
            return decimal.TryParse(txt, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-GB"), out d);
        }

        private bool IsValid(string txt)
        {
            if(!string.IsNullOrEmpty(txt) && IsNumeric(ref txt))
                return true;
            else
                return false;
        }
    }
}
