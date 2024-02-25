using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Textdisplay = "";
        private string history = "";
        private bool decimalInsertable = true;
        private void updateDisplay(string recentInput)
        {
            history = Textdisplay;
            Textdisplay = history + recentInput;
            Display.Text = Textdisplay;
        }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputNum(object sender, RoutedEventArgs e)
        {
            var keyword = (e.Source as Button).Content.ToString();
            updateDisplay(keyword);
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            Textdisplay = string.Empty;
            history = string.Empty;
            updateDisplay(string.Empty);
        }

        private void InputMath(object sender, RoutedEventArgs e)
        {
            var keyword = (e.Source as Button).Content.ToString();
            updateDisplay(keyword);
            decimalInsertable = true;
        }

        private void DoMath(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable();

            try
            {
                object result = dataTable.Compute(Textdisplay, "");

                double numericResult = Convert.ToDouble(result);
                Textdisplay = string.Empty;
                history = string.Empty;
                updateDisplay(string.Empty);
                updateDisplay(numericResult.ToString());
                Console.WriteLine($"Result: {numericResult}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the evaluation
                Display.Text =($"Error: {ex.Message}");
            }
            
        }

        private void InputDecim(object sender, RoutedEventArgs e)
        {
            if (decimalInsertable)
            {
                var keyword = (e.Source as Button).Content.ToString();
                updateDisplay(keyword);
                decimalInsertable = false;
            }
        }

       
    }
}
