using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HomeCheckList.Views
{
    public partial class ThemeTestWindow : Window
    {
        public ThemeTestWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
