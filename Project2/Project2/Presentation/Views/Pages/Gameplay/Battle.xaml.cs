using System.Windows.Controls;

namespace Project2.Presentation.Views.Pages.Gameplay
{
    /// <summary>
    /// Interaction logic for Battle.xaml
    /// </summary>
    public partial class Battle : Page
    {
        public Battle()
        {
            InitializeComponent();
        }

        private void ScrollToEnd(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox) textBox.ScrollToEnd();
        }
    }
}
