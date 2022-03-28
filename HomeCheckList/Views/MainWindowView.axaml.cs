using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using HomeCheckList.Models;
using HomeCheckList.ViewModels;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HomeCheckList.Views
{
    public partial class MainWindowView : ReactiveWindow<MainWindowViewModel>
    {
        //public List<Room> Rooms { get; set; } = new();
        public MainWindowView()
        {
            //this.WhenActivated(disposables => { });
            InitializeComponent();
           // this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
            //this.WhenActivated(d => d(ViewModel!.ShowRoomDialog.RegisterHandler(DoShowRoomDialog)));
        }

        private void InitializeComponent()
        {
            
            AvaloniaXamlLoader.Load(this);


        }

        //private async Task DoShowDialogAsync(InteractionContext<ThemeTestViewModel, MainWindowViewModel?> interaction)
        //{
        //    var dialog = new ThemeTestWindow();
        //    dialog.DataContext = interaction.Input;

        //    var result = await dialog.ShowDialog<MainWindowViewModel?>(this);
        //    interaction.SetOutput(result);
        //}

        //private async Task DoShowRoomDialog(InteractionContext<RoomViewModel, MainWindowViewModel?> interaction)
        //{
        //    var dialog = new RoomView();
        //    dialog.DataContext = interaction.Input;

        //    var result = await dialog.ShowDialog<MainWindowViewModel?>(this);
        //    interaction.SetOutput(result);

        //}

       
    }
}
