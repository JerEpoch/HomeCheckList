using HomeCheckList.Commands;
using HomeCheckList.Models;
using HomeCheckList.Stores;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeCheckList.ViewModels
{
    public class AddRoomViewModel : ViewModelBase
    {
        private string _roomName;

        public string InputRoomName
        {
            get => _roomName;
            set
            {
                _roomName = value;
                OnPropertyChanged(nameof(InputRoomName));
            }

        }

        public ICommand AddRoom { get; }

        public AddRoomViewModel(MainWindowViewModel mainWindowViewModel, DbHelper dbhelper, NavigationStore navigationStore)
        {
            AddRoom = new MakeRoomCommand(mainWindowViewModel,dbhelper, this);

        }
    }
}
