using System.Windows;
using System.Windows.Controls;

namespace Project2.Presentation.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CharacterDetails.xaml
    /// </summary>
    public partial class CharacterDetails : UserControl
    {
        public static readonly DependencyProperty CharacterProperty =
            DependencyProperty.Register
            (
                nameof(Character),
                typeof(object),
                typeof(CharacterDetails),
                new FrameworkPropertyMetadata(null)
            );

        public object Character
        {
            get { return GetValue(CharacterProperty); }
            set { SetValue(CharacterProperty, value); }
        }

        public CharacterDetails()
        {
            InitializeComponent();
        }
    }
}
