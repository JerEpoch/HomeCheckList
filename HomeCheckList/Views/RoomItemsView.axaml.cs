using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using HomeCheckList.ViewModels;
using ReactiveUI;

namespace HomeCheckList.Views
{
    public partial class RoomItemsView : ReactiveUserControl<RoomItemsViewModel>
    {
        public RoomItemsView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
