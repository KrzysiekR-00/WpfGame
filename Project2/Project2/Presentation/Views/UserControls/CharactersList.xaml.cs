using System.Windows;
using System.Windows.Controls;

namespace Project2.Presentation.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CharactersList.xaml
    /// </summary>
    public partial class CharactersList : DataGrid
    {
        public static readonly DependencyProperty AttributesVisibilityProperty =
            DependencyProperty.Register
            (
                nameof(AttributesVisibility),
                typeof(Visibility),
                typeof(CharactersList),
                new FrameworkPropertyMetadata(null)
            );

        public Visibility AttributesVisibility
        {
            get { return (Visibility)GetValue(AttributesVisibilityProperty); }
            set { SetValue(AttributesVisibilityProperty, value); }
        }

        public static readonly DependencyProperty StateVisibilityProperty =
            DependencyProperty.Register
            (
                nameof(StateVisibility),
                typeof(Visibility),
                typeof(CharactersList),
                new FrameworkPropertyMetadata(null)
            );

        public Visibility StateVisibility
        {
            get { return (Visibility)GetValue(StateVisibilityProperty); }
            set { SetValue(StateVisibilityProperty, value); }
        }

        public static readonly DependencyProperty ContractVisibilityProperty =
            DependencyProperty.Register
            (
                nameof(ContractVisibility),
                typeof(Visibility),
                typeof(CharactersList),
                new FrameworkPropertyMetadata(null)
            );

        public Visibility ContractVisibility
        {
            get { return (Visibility)GetValue(ContractVisibilityProperty); }
            set { SetValue(ContractVisibilityProperty, value); }
        }

        public CharactersList()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                if (AttributesVisibility != Visibility.Visible)
                {
                    datagrid.Columns[3].Visibility = Visibility.Collapsed;
                    datagrid.Columns[4].Visibility = Visibility.Collapsed;
                    datagrid.Columns[5].Visibility = Visibility.Collapsed;
                    datagrid.Columns[6].Visibility = Visibility.Collapsed;
                }
                if (StateVisibility != Visibility.Visible)
                {
                    datagrid.Columns[7].Visibility = Visibility.Collapsed;
                    datagrid.Columns[8].Visibility = Visibility.Collapsed;
                }
                if (ContractVisibility != Visibility.Visible)
                {
                    datagrid.Columns[9].Visibility = Visibility.Collapsed;
                    datagrid.Columns[10].Visibility = Visibility.Collapsed;
                }
            };
        }
    }
}
