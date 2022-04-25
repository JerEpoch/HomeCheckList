using HomeCheckList.Commands;
using HomeCheckList.Models;
using HomeCheckList.Services;
using HomeCheckList.Stores;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeCheckList.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {


        //   public ReactiveCommand<Unit, Unit> GoBack => Router.NavigateBack;
        private string _itemName;
        private string _itemNote;
        private Room _selectedRoom;
        private bool _includeReminder;
        
        public string InputName
        {
            get => _itemName;
            set 
            {   
                _itemName = value;
                OnPropertyChanged(nameof(InputName));
            }
            
        }

        public string InputNote
        {
            get => _itemNote;
            set
            {
                _itemNote = value;
                OnPropertyChanged(nameof(InputNote));
            }
        }

        private DateTime _dueDate = DateTime.Today;
       
        
        public DateTime DueDates
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDates));
            }
        }
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set => this.RaiseAndSetIfChanged(ref _selectedRoom, value);
        }

        public bool IncludeReminder
        {
            get => _includeReminder;
            set
            {
                _includeReminder = value;
                OnPropertyChanged(nameof(IncludeReminder));
            }
        }
        public ICommand GoRoomItems { get;}
        public ICommand AddItem { get; }

        public AddItemViewModel(MainWindowViewModel mainWindowViewModel, DbHelper dbhelper, NavigationStore navigationStore, Room room)
        {
            _selectedRoom = room;
            
            
            AddItem = new AddRoomItemCommand(mainWindowViewModel, dbhelper, this);
            //GoRoomItems = new NavigateCommand<RoomItemsViewModel>(navigationStore, () => new RoomItemsViewModel(mainWindowViewModel, dbhelper, navigationStore));
            //GoRoomItems = new NavigateCommand<MainWindowViewModel>(navigationStore, () => new MainWindowViewModel(dbhelper, navigationStore));
        }
       
    }
}
