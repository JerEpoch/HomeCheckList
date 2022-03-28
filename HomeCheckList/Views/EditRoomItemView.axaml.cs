using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HomeCheckList.Views
{
    public partial class EditRoomItemView : UserControl
    {
        public EditRoomItemView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
