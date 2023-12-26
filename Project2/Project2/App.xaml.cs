using Project2.Presentation.ViewModels;
using Project2.Presentation.Views.Windows;
using System.Windows;

namespace Project2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow();
            var viewModel = new MainWindowViewModel(new Navigator());
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
