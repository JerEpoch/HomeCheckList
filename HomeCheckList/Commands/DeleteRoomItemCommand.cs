using HomeCheckList.Models;
using HomeCheckList.Stores;
using HomeCheckList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands
{
    public class DeleteRoomItemCommand : AsyncCommandBase
    {
        private DbHelper _dbHelper;
        private RoomItemsViewModel _itemViewModel;
        private NavigationStore _navigationStore;
        private MainWindowViewModel _mainWindowViewModel;
        public DeleteRoomItemCommand(DbHelper dbhelper, RoomItemsViewModel itemViewModel, NavigationStore navStore, MainWindowViewModel mainWindowViewModel)
        {
            _dbHelper = dbhelper;
            _itemViewModel = itemViewModel;
            _navigationStore = navStore;
            _mainWindowViewModel = mainWindowViewModel;
        }
        public override async Task ExecuteAsync(object paremter)
        {
            var roomItem = await _dbHelper.GetRoomItemById(_itemViewModel.SelectedItem.itemId);
            if (roomItem != null)
            {
                await _dbHelper.DeleteRoomItem(roomItem);

                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                   .GetMessageBoxStandardWindow("Success", "Your item was deleted.");
                await messageBoxStandard.Show();

                _navigationStore.CurrentViewModel = new RoomItemsViewModel(_mainWindowViewModel, _dbHelper, _navigationStore);
            }
            else
            {
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                   .GetMessageBoxStandardWindow("Error", "Your item was unable to be deleted.");
                await messageBoxStandard.Show();
            }
        }
    }
}
