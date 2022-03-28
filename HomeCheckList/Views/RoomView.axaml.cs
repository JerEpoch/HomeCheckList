using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using HomeCheckList.Models;
using HomeCheckList.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HomeCheckList.Views
{
    public partial class RoomView : Window
    {
        public RoomView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }
  
        
        //public ObservableCollection<RoomViewModel> roomitems { get; set; } = new();
        public RoomView(Room room)
        {
            
            
            InitializeComponent();
            this.DataContext = new RoomViewModel();
            //_room = room;
            //TextBlock txtblk = this.Find<TextBlock>("Blah");
           // txtblk.Text = _room.Name;
           // roomitems.Add(new RoomItems(1, "Item 1", _room.Id));
            //roomitems.Add(new RoomItems(1, "Item 2", _room.Id));
            //this.DataContext = roomitems;
            //roomname = room.Name;

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            

        }
    }
}
