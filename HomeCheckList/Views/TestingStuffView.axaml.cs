using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HomeCheckList.Views
{
    public partial class TestingStuffView : UserControl
    {
        public TestingStuffView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
