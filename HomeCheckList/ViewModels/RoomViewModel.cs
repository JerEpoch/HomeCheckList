using HomeCheckList.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeCheckList.ViewModels
{
    public class RoomViewModel : ViewModelBase
    {
        //private readonly RoomItems _roomitem;
        public ObservableCollection<RoomItems> RoomItems
        {
            get;
            set;
        }

        
        //public string ItemId => _roomitem.ItemId.ToString();
        //public string ItemName => _roomitem.ItemName;
       // public string Test { get; set; } = "Test String";
        //public string roomname = "blakjd";
        //public string roomNameTest
        //{
        //    get => _room.Name;
        //}
        //public Room _room;
        public RoomViewModel()
        {
            //LoadRoomItems();
        }

        //public void LoadRoomItems()
        //{
        //    ObservableCollection<RoomItems> items = new ObservableCollection<RoomItems>();

        //    items.Add(new RoomItems(1, "Item 1", 1));
        //    items.Add(new RoomItems(2, "Item 2", 1));
        //    items.Add(new RoomItems(2, "Item 3", 1));
        //    RoomItems = items;
        //}


    }
}
