using System.Windows.Controls;
using Lab01_Kataskin.Models;
using Lab01_Kataskin.ViewModels;

namespace Lab01_Kataskin.Views
{
    public partial class PersonInfoWindowView : UserControl
    {
        private readonly PersonInfoWindowViewModel _viewModel;
        public PersonInfoWindowView(RegistrationWindowViewModel regViewModel)
        {
            _viewModel = new PersonInfoWindowViewModel(regViewModel.User);
            InitializeComponent();
            DataContext = _viewModel;
        }
        
    }
}