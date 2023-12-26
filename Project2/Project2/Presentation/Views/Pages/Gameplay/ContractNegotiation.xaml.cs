using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project2.Presentation.Views.Pages.Gameplay
{
    /// <summary>
    /// Interaction logic for ContractNegotiation.xaml
    /// </summary>
    public partial class ContractNegotiation : Page
    {
        public ContractNegotiation()
        {
            InitializeComponent();
        }

        private void ScrollToEnd(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox) textBox.ScrollToEnd();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
