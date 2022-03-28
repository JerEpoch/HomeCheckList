using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HomeCheckList.Views
{
    public partial class AddRoomView : UserControl
    {
        public AddRoomView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
