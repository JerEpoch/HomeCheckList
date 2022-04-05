using HomeCheckList.Models;
using HomeCheckList.Stores;
using HomeCheckList.ViewModels;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands
{
    public class EditRoomItemCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly EditRoomItemViewModel _editRoomItemViewModel;
        private readonly NavigationStore _navStore;
        private readonly DbHelper _dbHelper;

        public EditRoomItemCommand(EditRoomItemViewModel editRoomItemViewModel, DbHelper dbHelper, MainWindowViewModel mainWindowViewModel, NavigationStore navStore)
        {
            _editRoomItemViewModel = editRoomItemViewModel;
            _mainWindowViewModel = mainWindowViewModel;
            _navStore = navStore;
            _dbHelper = dbHelper;
        }

        public override async Task ExecuteAsync(object paremter)
        {
          

            var roomItemEdit = await _dbHelper.GetRoomItemById(_editRoomItemViewModel.ItemId);

            if (roomItemEdit != null)
            {
                roomItemEdit.Note = _editRoomItemViewModel.EditNote;
                roomItemEdit.ItemName = _editRoomItemViewModel.EditName;
                roomItemEdit.IsCompleted = _editRoomItemViewModel.IsDone;
                roomItemEdit.CreatedAt = DateTime.Now;
                roomItemEdit.DueDate = _editRoomItemViewModel.EditDueDates;

                await _dbHelper.UpdateRoomItem(roomItemEdit);

                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Success", "Changes saved.");
                await messageBoxStandard.Show();

                _navStore.CurrentViewModel = new RoomItemsViewModel(_mainWindowViewModel,_dbHelper,_navStore);
            }
            else
            {
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Error", "Unable to save changes.");
                await messageBoxStandard.Show();
            }
        }
    }
}
