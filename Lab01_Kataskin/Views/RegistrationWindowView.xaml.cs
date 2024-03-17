using System;
using System.Windows.Controls;
using Lab01_Kataskin.ViewModels;
using Lab01_Kataskin.Views;

namespace Lab01_Kataskin
{
    public partial class RegistrationWindowView : UserControl
    {
        private readonly RegistrationWindowViewModel _viewModel;
        
        public RegistrationWindowView()
        {
            _viewModel = new RegistrationWindowViewModel(ProceedAction);
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void ProceedAction()
        {
            Content = new PersonInfoWindowView(_viewModel);
        }
    }
}