using HomeCheckList.Commands;
using HomeCheckList.Models;
using HomeCheckList.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeCheckList.ViewModels
{
    public class EditRoomItemViewModel : ViewModelBase
    {
        //private DbHelper _dbHelper;
        //private NavigationStore _navigationStore;
        private ItemViewModel _itemViewModel;
        private MainWindowViewModel _mainWindowViewModel;

        
        //private readonly ObservableCollection<ItemViewModel> _itemViewModel;
        //public IEnumerable<ItemViewModel> Items => _itemViewModel;

        public int ItemId => _itemViewModel.itemId;
        public string EditName
        {
            get => _itemViewModel.Name;
            set
            {
                _itemViewModel.Name = value;
                OnPropertyChanged(nameof(EditName));
            }
        }
       // public string EditNote => _itemViewModel.Note;
        public string EditNote
        {
            get => _itemViewModel.Note;
            set
            {
                _itemViewModel.Note = value;
              //  _editNote = value;
                OnPropertyChanged(nameof(EditNote));
            }
        }

        public bool IsDone
        {
            get => _itemViewModel.IsDone;
            set
            {
                _itemViewModel.IsDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }
        //public bool IncludeReminder => _itemViewModel.IsDone;
        //public DateTime? EditDueDates => _itemViewModel.DueDate;
        public DateTime? EditDueDates
        {
            get => _itemViewModel.DueDate;
            set
            {
                _itemViewModel.DueDate = value;
                OnPropertyChanged(nameof(EditDueDates));
            }
        }
        
        public ICommand SaveItem { get; }
        public EditRoomItemViewModel(DbHelper dbHelper, NavigationStore navigationStore, ItemViewModel itemViewModel, MainWindowViewModel mainWindowViewModel)
        {
            //_dbHelper = dbHelper;
            //_navigationStore = navigationStore;
            _mainWindowViewModel = mainWindowViewModel;
            _itemViewModel = itemViewModel;

            SaveItem = new EditRoomItemCommand(this, dbHelper, _mainWindowViewModel, navigationStore);
            //_itemViewModel = new ObservableCollection<ItemViewModel>();
            //_itemViewModel.Add(itemViewModel);
        }
    }
}
