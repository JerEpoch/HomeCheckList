using HomeCheckList.Commands;
using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeCheckList.ViewModels
{
    public class ManageRoomViewModel : ViewModelBase
    {
        private Room _selectedRoom;
        private string _roomName;
        
        private ObservableCollection<Room> _rooms;
        private MainWindowViewModel _mainWindowViewModel;

        public String ManageRoomName
        {
            get => _roomName;
            set
            {
                _roomName = value;
                OnPropertyChanged(nameof(ManageRoomName));
            }
        }

      

        public Room SelectedManageRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                if (_selectedRoom != null)
                {
                    _roomName = _selectedRoom.Name;
                    OnPropertyChanged(nameof(ManageRoomName));
                }
                
                OnPropertyChanged(nameof(SelectedManageRoom));
            }
        }

        public ObservableCollection<Room> ManageRooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(ManageRooms));
                //this.RaisePropertyChanged("Rooms");
            }
        }
        public ICommand SaveChanges { get; }
        public ICommand DeleteRoom { get; }
        public ManageRoomViewModel(MainWindowViewModel viewModel, DbHelper dbHelper)
        {
            
            _rooms = viewModel.Rooms;
            _mainWindowViewModel = viewModel;

            SaveChanges = new EditRoomCommand(this, dbHelper);
            DeleteRoom = new DeleteRoomCommand(this, dbHelper);
        }

        public void UpdateRoomList()
        {
            _mainWindowViewModel.UpdateAllRooms();
        }
    }
}
