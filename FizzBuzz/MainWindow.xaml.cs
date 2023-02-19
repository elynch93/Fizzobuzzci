using System;
using System.Collections.Generic;
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

namespace FizzBuzz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FizzBuzzGenerator FizzBuzzGen = new();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void NumTermsText_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid and non-negative integer.
            if (int.TryParse(NumTermsText.Text, out int i) && i >= 0)
            {
                FizzBuzzGen.NumTerms = (uint)i;
            }
            else
            {
                // If invalid, just override to the previous value.
                NumTermsText.Text = FizzBuzzGen.NumTerms.ToString();
            }
        }

        private void FizzString_LostFocus(object sender, RoutedEventArgs e)
        {
            FizzBuzzGen.FizzString = FizzStringText.Text;
        }

        private void FizzDiv_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid integer.
            if (int.TryParse(FizzDivText.Text, out int i))
            {
                if (i != 0)
                {
                    FizzBuzzGen.FizzDivisor = i;
                }
                else
                {
                    // If invalid, just override to the previous value.
                    FizzDivText.Text = FizzBuzzGen.FizzDivisor.ToString();
                }
            }
            else
            {
                // Error print? For now, just override to the previous value.
                FizzDivText.Text = FizzBuzzGen.FizzDivisor.ToString();
            }
        }

        private void BuzzString_LostFocus(object sender, RoutedEventArgs e)
        {
            FizzBuzzGen.BuzzString = BuzzStringText.Text;
        }

        private void BuzzDiv_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid integer.
            if (int.TryParse(BuzzDivText.Text, out int i))
            {
                if (i != 0)
                {
                    FizzBuzzGen.BuzzDivisor = i;
                }
                else
                {
                    // Error print? For now, just override to the previous value.
                    BuzzDivText.Text = FizzBuzzGen.BuzzDivisor.ToString();
                }
            }
            else
            {
                // Error print? For now, just override to the previous value.
                BuzzDivText.Text = FizzBuzzGen.BuzzDivisor.ToString();
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text = GetOutputString();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            FizzBuzzGen.Reset();

            NumTermsText.Text = FizzBuzzGen.NumTerms.ToString();

            FizzDivText.Text = FizzBuzzGen.FizzDivisor.ToString();
            BuzzDivText.Text = FizzBuzzGen.BuzzDivisor.ToString();

            FizzStringText.Text = FizzBuzzGen.FizzString;
            BuzzStringText.Text = FizzBuzzGen.BuzzString;
        }

        private string GetOutputString()
        {
            return FizzBuzzGen.GenerateOutputString();
        }
    }
}
