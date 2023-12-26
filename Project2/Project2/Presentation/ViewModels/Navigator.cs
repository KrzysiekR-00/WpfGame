using System;

namespace Project2.Presentation.ViewModels
{
    internal class Navigator
    {
        internal ViewModelBase? CurrentViewModel { get; private set; }

        internal ViewModelBase? PreviousViewModel { get; private set; }

        internal Action? CurrentViewModelChanged { get; set; }

        internal void NavigateTo(ViewModelBase viewModel)
        {
            PreviousViewModel = CurrentViewModel;

            CurrentViewModel = viewModel;

            CurrentViewModelChanged?.Invoke();
        }
    }
}
