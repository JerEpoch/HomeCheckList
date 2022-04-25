using HomeCheckList.Models;
using HomeCheckList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands
{
    public class EditRoomCommand : AsyncCommandBase
    {
        private ManageRoomViewModel _viewModel;
        private DbHelper _dbHelper;
        public EditRoomCommand(ManageRoomViewModel viewModel, DbHelper dbHelper)
        {
            _viewModel = viewModel;
            _dbHelper = dbHelper;
        }
        public override async Task ExecuteAsync(object paremter)
        {
            var roomToEdit = await _dbHelper.GetRoomById(_viewModel.SelectedManageRoom.Id);

            if (roomToEdit != null)
            {
                roomToEdit.Name = _viewModel.ManageRoomName;

                try
                {
                    await _dbHelper.UpdateRoom(roomToEdit);

                    _viewModel.UpdateRoomList();
                    _viewModel.ManageRoomName = "";

                    var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Success", "Your changes were saved.");
                    await messageBoxStandard.Show();
                }
                catch
                {
                    var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", "Unable to save changes.");
                    await messageBoxStandard.Show();
                }
                
            }
        }
    }
}
