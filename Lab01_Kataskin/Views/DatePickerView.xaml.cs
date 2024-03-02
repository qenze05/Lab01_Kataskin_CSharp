using System.Windows.Controls;
using Lab01_Kataskin.ViewModels;

namespace Lab01_Kataskin
{
    public partial class DatePickerView : UserControl
    {
        private DatePickerViewModel _viewModel = new DatePickerViewModel();
        
        public DatePickerView()
        {
            InitializeComponent();
            DataContext = _viewModel;

        }
    }
}