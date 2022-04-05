using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HomeCheckList.Views
{
    public partial class ManageRoomView : UserControl
    {
        public ManageRoomView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
