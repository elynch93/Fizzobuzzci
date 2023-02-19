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

namespace Fizzobuzzci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FizzobuzzciGenerator FizzobuzzciGen = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumTermsText_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid and non-negative integer.
            if (int.TryParse(NumTermsText.Text, out int i) && i >= 0)
            {
                FizzobuzzciGen.NumTerms = (uint)i;
            }
            else
            {
                // If invalid, just override to the previous value.
                NumTermsText.Text = FizzobuzzciGen.NumTerms.ToString();
            }
        }

        private void Y_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid and non-negative integer.
            if (int.TryParse(YText.Text, out int i) && i >= 0)
            {
                FizzobuzzciGen.Y = (uint)i;
            }
            else
            {
                // If invalid, just override to the previous value.
                YText.Text = FizzobuzzciGen.Y.ToString();
            }
        }

        private void Z_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid and non-negative integer.
            if (int.TryParse(ZText.Text, out int i) && i >= 0)
            {
                FizzobuzzciGen.Z = (uint)i;
            }
            else
            {
                // If invalid, just override to the previous value.
                ZText.Text = FizzobuzzciGen.Z.ToString();
            }
        }

        private void FizzString_LostFocus(object sender, RoutedEventArgs e)
        {
            FizzobuzzciGen.FizzString = FizzStringText.Text;
        }

        private void FizzDiv_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid integer.
            if (int.TryParse(FizzDivText.Text, out int i))
            {
                if (i != 0)
                {
                    FizzobuzzciGen.FizzDivisor = i;
                }
                else
                {
                    // If invalid, just override to the previous value.
                    FizzDivText.Text = FizzobuzzciGen.FizzDivisor.ToString();
                }
            }
            else
            {
                // Error print? For now, just override to the previous value.
                FizzDivText.Text = FizzobuzzciGen.FizzDivisor.ToString();
            }
        }

        private void BuzzString_LostFocus(object sender, RoutedEventArgs e)
        {
            FizzobuzzciGen.BuzzString = BuzzStringText.Text;
        }

        private void BuzzDiv_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid integer.
            if (int.TryParse(BuzzDivText.Text, out int i))
            {
                if (i != 0)
                {
                    FizzobuzzciGen.BuzzDivisor = i;
                }
                else
                {
                    // Error print? For now, just override to the previous value.
                    BuzzDivText.Text = FizzobuzzciGen.BuzzDivisor.ToString();
                }
            }
            else
            {
                // Error print? For now, just override to the previous value.
                BuzzDivText.Text = FizzobuzzciGen.BuzzDivisor.ToString();
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text = GetOutputString();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            FizzobuzzciGen.Reset();

            NumTermsText.Text = FizzobuzzciGen.NumTerms.ToString();

            YText.Text = FizzobuzzciGen.Y.ToString();
            ZText.Text = FizzobuzzciGen.Z.ToString();
        }

        private string GetOutputString()
        {
            return FizzobuzzciGen.GenerateOutputString();
        }
    }
}
