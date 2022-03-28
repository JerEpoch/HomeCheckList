using HomeCheckList.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.ViewModels
{
    public class RoomsView : ViewModelBase
    {
        //public ObservableCollection<Room> Rooms { get; set; } = new();

        public ReactiveCommand<string, Unit> RoomIndex { get; }

        public RoomsView()
        {
            
        }
    }
}
