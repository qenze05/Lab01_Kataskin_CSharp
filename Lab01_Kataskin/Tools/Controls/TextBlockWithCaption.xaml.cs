using System.Windows;
using System.Windows.Controls;

namespace Lab01_Kataskin.Tools.Controls
{
    public partial class TextBlockWithCaption : UserControl
    {
        public static readonly DependencyProperty TbValueProperty = DependencyProperty.Register("TbText", typeof(string), typeof(TextBlockWithCaption), new PropertyMetadata());
        public TextBlockWithCaption()
        {
            InitializeComponent();
        }

        public string TbText
        {
            get => (string)GetValue(TbValueProperty);
            set => SetValue(TbValueProperty, value);
        }
        public string Caption
        {
            get => TbCaption.Text;
            set => TbCaption.Text = value;
        }
    }
}