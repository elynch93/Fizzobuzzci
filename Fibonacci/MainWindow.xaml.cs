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

namespace Fibonacci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FibonacciGenerator FibonacciGen = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumTermsText_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid and non-negative integer.
            if (int.TryParse(NumTermsText.Text, out int i) && i >= 0)
            {
                FibonacciGen.NumTerms = (uint)i;
            }
            else
            {
                // If invalid, just override to the previous value.
                NumTermsText.Text = FibonacciGen.NumTerms.ToString();
            }
        }

        private void Y_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid and non-negative integer.
            if (int.TryParse(YText.Text, out int i) && i >= 0)
            {
                FibonacciGen.Y = (uint)i;
            }
            else
            {
                // If invalid, just override to the previous value.
                YText.Text = FibonacciGen.Y.ToString();
            }
        }

        private void Z_LostFocus(object sender, RoutedEventArgs e)
        {
            // Ensure string is a valid and non-negative integer.
            if (int.TryParse(ZText.Text, out int i) && i >= 0)
            {
                FibonacciGen.Z = (uint)i;
            }
            else
            {
                // If invalid, just override to the previous value.
                ZText.Text = FibonacciGen.Z.ToString();
            }
        }
        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text = GetOutputString();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            FibonacciGen.Reset();

            NumTermsText.Text = FibonacciGen.NumTerms.ToString();

            YText.Text = FibonacciGen.Y.ToString();
            ZText.Text = FibonacciGen.Z.ToString();
        }

        private string GetOutputString()
        {
            return FibonacciGen.GenerateOutputString();
        }
    }
}
