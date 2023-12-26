namespace Project2.Presentation.ViewModels
{
    internal class NavigableViewModel : ViewModelBase
    {
        protected readonly Navigator _navigator;

        internal NavigableViewModel(Navigator navigator)
        {
            _navigator = navigator;
        }
    }
}
