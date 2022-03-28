using HomeCheckList.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using Avalonia.Controls;
using System.Reactive;
using System.Text;
using System.Windows.Input;
using System.Reactive.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HomeCheckList.Models;
using HomeCheckList.Stores;
using HomeCheckList.Commands;
using System.ComponentModel;

namespace HomeCheckList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
       
        private ObservableCollection<RoomItems> _roomItems { get; set; }

        private ObservableCollection<Room> _rooms;
        private Room _selectedRoom;
        private bool _canAddRoomItem;
        private readonly DbHelper _dbHelper;
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
                //this.RaisePropertyChanged("Rooms");
            }
        }

        public ObservableCollection<RoomItems> RoomItems
        {
            get { return _roomItems; }
            set
            {
                _roomItems = value;
                OnPropertyChanged(nameof(RoomItems));
            }

        }
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
                if (SelectedRoom != null)
                {
                    _canAddRoomItem = true;
                    OnPropertyChanged(nameof(CanAddRoomItem));
                }
                else
                {
                    _canAddRoomItem = false;
                    OnPropertyChanged(nameof(CanAddRoomItem));
                }
                //this.RaisePropertyChanged(nameof(SelectedRoom));
            }
        }

        public bool CanAddRoomItem
        {
            get => _canAddRoomItem;
            set
            {
                _canAddRoomItem = value;
                OnPropertyChanged(nameof(CanAddRoomItem));
            }
        }


        public ICommand AddItem { get; }
        public ICommand AddRoom { get; }
        public ICommand LoadRooms { get; }
        
        public ICommand GetRoomItems { get; }
        public MainWindowViewModel(DbHelper dbHelper, NavigationStore navigationStore)
        {
            
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChange += OnCurrentViewModelChanged;
            
            _dbHelper = dbHelper;
            _rooms = new ObservableCollection<Room>();
            _roomItems = new ObservableCollection<RoomItems>();
            //LoadRoomItems();
            
            ShowDialog = new Interaction<ThemeTestViewModel, MainWindowViewModel?>();
       

            OpenThemeTest = ReactiveCommand.CreateFromTask(async () =>
            {
                var theme = new ThemeTestViewModel();
                var result = await ShowDialog.Handle(theme);
            });

            LoadRooms = new LoadRoomsCommand(this, _dbHelper);
            
            
            //MainWindowViewModel viewModel = new MainWindowViewModel(dbHelper, navigationStore);
            AddItem = new NavigateCommand<AddItemViewModel>(navigationStore, () => new AddItemViewModel(this,_dbHelper, navigationStore,_selectedRoom));
            AddRoom = new NavigateCommand<AddRoomViewModel>(navigationStore, () => new AddRoomViewModel(this,_dbHelper,navigationStore));
            GetRoomItems = new NavigateCommand<RoomItemsViewModel>(navigationStore, () => new RoomItemsViewModel(this,_dbHelper,navigationStore));
            //GoAddItem = ReactiveCommand.CreateFromObservable(
            //    () => Router.Navigate.Execute(new AddItemViewModel(this))
            //);
            this.LoadRooms.Execute(null);
            
            
        }

        public MainWindowViewModel()
        { }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        

        public void LoadAllRooms(IEnumerable<Room> rooms)
        {
            //Rooms.Add(new Room("Kitchen"));
            //Rooms.Add(new Room("Basement"));
            
            _rooms.Clear();
           // Rooms.Clear();

            foreach(Room room in rooms)
            {
                //_rooms.Add(room);
                Rooms.Add(room);
               // Room roomname = new Room();
            }

        }

        


        public void ShowRoomWindow(Room parameter)
        {
            //int roomId = parameter.Id;
            //var roomwindow = new RoomView
            //{
            //    DataContext = new RoomViewModel(parameter),
            //};
            //roomwindow.Show();
            
            new RoomView(parameter).Show();

        }

        public void ShowThemeTest()
        {
            new ThemeTestWindow().Show();
        }


        public ICommand OpenThemeTest { get; }
        
        public Interaction<ThemeTestViewModel, MainWindowViewModel?> ShowDialog { get; }

        //public Interaction<RoomViewModel, MainWindowViewModel?> ShowRoomDialog { get; }
        //public ICommand OpenRoomView { get; }
    }
    
}
