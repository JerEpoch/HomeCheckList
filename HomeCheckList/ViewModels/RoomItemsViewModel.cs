using DynamicData;
using HomeCheckList.Commands;
using HomeCheckList.Models;
using HomeCheckList.Stores;
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
    public class RoomItemsViewModel: ViewModelBase
    {

       // private  ObservableCollection<RoomItems> _roomItems;
        private readonly DbHelper _dbHelper;
        private readonly NavigationStore _navigationStore;
        private MainWindowViewModel _mainWindowViewModel;
        private string _buttonContext;
        private bool _showHideBtn;
        //private RoomItems _selectedItem;
        private ItemViewModel _selectedItem;
        //private ObservableCollection<RoomItems> _selectedItem = new ObservableCollection<RoomItems>();
        private bool _canEdit;
        private ObservableCollection<RoomItems> _roomItems;
        //test stuff
        private readonly ObservableCollection<ItemViewModel> _itemsViewModel;
        private readonly ObservableCollection<ItemViewModel> _filteredItemsViewModel;
        private ObservableCollection<RoomItems> _filtered;
        //public IEnumerable<ItemViewModel> Items => _itemsViewModel;

        public IEnumerable<ItemViewModel> Items
        {
            get
            {
                if (!_showHideBtn)
                {
                    return _itemsViewModel;
                }
                return _filteredItemsViewModel;
            } 
        }
        public bool CanEdit
        {
            get => _canEdit;
            set
            {
                _canEdit = value;
                OnPropertyChanged(nameof(CanEdit));
            }
        }
        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                if (_selectedItem != null)
                {
                    _canEdit = true;
                    OnPropertyChanged(nameof(CanEdit));
                }
                else
                {
                    _canEdit = false;
                    OnPropertyChanged(nameof(CanEdit));
                }
                
            }
        }

        public string ButtonContext
        {
            get => _buttonContext;
            //set
            //{
            //    _buttonContext = value;
            //    OnPropertyChanged(nameof(ButtonContext));
            //}
        }

      

        public ICommand LoadRoomItems { get;  }
        public ICommand GoEditItem { get; }
        public ICommand DeleteRoomItem { get; }
        //public ICommand ShowHideCompleted { get; }
        bool CanGoEditItem(object parameter)
        {
            return _selectedItem != null;
        }

        // //public ReactiveCommand<Unit, Unit> GoBack => Router.NavigateBack;
        public RoomItemsViewModel(MainWindowViewModel mainWindowViewModel,DbHelper dbhelper, NavigationStore navigationStore)
        {
            _dbHelper = dbhelper;
            _navigationStore = navigationStore;
            _mainWindowViewModel = mainWindowViewModel;
            _buttonContext = "Hide Completed Items";
            _showHideBtn = false;
            //_roomItems = new ObservableCollection<RoomItems>();
            _itemsViewModel = new ObservableCollection<ItemViewModel>();
            _roomItems = new ObservableCollection<RoomItems>();
            _filtered = new ObservableCollection<RoomItems>();
            _filteredItemsViewModel = new ObservableCollection<ItemViewModel>();
            GoEditItem = new NavigateCommand<EditRoomItemViewModel>(_navigationStore, () => new EditRoomItemViewModel(_dbHelper, _navigationStore, _selectedItem, mainWindowViewModel));
            DeleteRoomItem = new DeleteRoomItemCommand(dbhelper, this, _navigationStore, mainWindowViewModel);
           
            LoadRoomItems = new LoadRoomItemsCommand(this, _dbHelper, _mainWindowViewModel.SelectedRoom.Id);
            this.LoadRoomItems.Execute(null);
        }

        public RoomItemsViewModel(DbHelper dbhelper, NavigationStore navigationStore)
        {
            _dbHelper = dbhelper;
            _navigationStore = navigationStore;

            _itemsViewModel = new ObservableCollection<ItemViewModel>();
        }

    
        public void ShowHideCompleted()
        {
            if (!_showHideBtn)
            {
                _buttonContext = "Show All Items";
                _showHideBtn = true;
                _filteredItemsViewModel.Clear();
                IEnumerable<ItemViewModel> filteredItems = _itemsViewModel.Where(item => item.IsDone == false).ToList();
                //IEnumerable<RoomItems> filtered = _roomItems.Where(item => item.IsCompleted == true).ToList();
                foreach (ItemViewModel item in filteredItems)
                {
                    if (item != null)
                    {
                        _filteredItemsViewModel.Add(item);
                        //_filteredItemsViewModel.Append(item);
                    }

                }
                OnPropertyChanged(nameof(Items));
                OnPropertyChanged(nameof(ButtonContext));
            }
            else
            {
                _showHideBtn = false;
                _buttonContext = "Hide Completed Items";
                OnPropertyChanged(nameof(ButtonContext));
                OnPropertyChanged(nameof(Items));
                
            }
           
        }

        public void LoadRoomAllItems(IEnumerable<RoomItems> roomItems)
        {
            _itemsViewModel.Clear();
            _roomItems.Clear();
            foreach(RoomItems roomItem in roomItems)
            {
                ItemViewModel itemViewModel = new ItemViewModel(roomItem);
                _itemsViewModel.Add(itemViewModel);
                _roomItems.Add(roomItem);
            }

        }

    }
}
