using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab01_Kataskin.Tools.Controls
{
    public partial class DatePickerBlockWithCaption : UserControl
    {
        public static readonly DependencyProperty DpValueProperty = DependencyProperty.Register("DpDate", typeof(DateTime), typeof(DatePickerBlockWithCaption), new PropertyMetadata());

        public DatePickerBlockWithCaption()
        {
            InitializeComponent();
        }
        
        public DateTime DpDate
        {
            get => (DateTime)GetValue(DpValueProperty);
            set => SetValue(DpValueProperty, value);
        }
        
        public string Caption
        {
            get => TbCaption.Text;
            set => TbCaption.Text = value;
        }
    }
}