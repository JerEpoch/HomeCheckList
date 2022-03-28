using HomeCheckList.Models;
using HomeCheckList.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.ViewModels
{
    public class EditRoomItemViewModel : ViewModelBase
    {
        private DbHelper _dbHelper;
        private NavigationStore _navigationStore;
        private ItemViewModel _itemViewModel;

        //private readonly ObservableCollection<ItemViewModel> _itemViewModel;
        //public IEnumerable<ItemViewModel> Items => _itemViewModel;

        public string EditName => _itemViewModel.Name;
        public string EditNote => _itemViewModel.Note;
        //public bool IncludeReminder => _itemViewModel.IsDone;
        public string? EditDueDates => _itemViewModel.DueDate;
        
        public EditRoomItemViewModel(DbHelper dbHelper, NavigationStore navigationStore, ItemViewModel itemViewModel)
        {
            _dbHelper = dbHelper;
            _navigationStore = navigationStore;
            _itemViewModel = itemViewModel;
            //_itemViewModel = new ObservableCollection<ItemViewModel>();
            //_itemViewModel.Add(itemViewModel);
        }
    }
}
