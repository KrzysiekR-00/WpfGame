using System.Windows.Controls;

namespace Project2.Presentation.Views.UserControls
{
    /// <summary>
    /// Interaction logic for StatBar.xaml
    /// </summary>
    public partial class StatBar : ProgressBar
    {
        public StatBar()
        {
            InitializeComponent();

            ValueChanged += StatBarValueChanged;

            tooltip.Text = Value.ToString();
        }

        private void StatBarValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            tooltip.Text = Value.ToString();
        }
    }
}
