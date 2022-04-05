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
    public class DeleteRoomCommand : AsyncCommandBase
    {
        private ManageRoomViewModel _viewModel;
        private DbHelper _dbHelper;

        public DeleteRoomCommand(ManageRoomViewModel viewModel, DbHelper dbHelper)
        {
            _viewModel = viewModel;
            _dbHelper = dbHelper;
        }

        public override async Task ExecuteAsync(object paremter)
        {
            var messageBoxConfirm = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
              new MessageBoxStandardParams
              {
                  ButtonDefinitions = ButtonEnum.OkCancel,
                  CanResize = true,
                  ContentTitle = "Confirm",
                  ContentMessage = "Are you sure you wish to delete the room? WARNING: You will lose all items tied to the room."
              });

            var result = await messageBoxConfirm.Show();

            if (result != ButtonResult.Cancel)
            {
                var roomToDelete = await _dbHelper.GetRoomById(_viewModel.SelectedManageRoom.Id);

                if (roomToDelete != null)
                {
                    await _dbHelper.DeleteRoom(roomToDelete);

                    _viewModel.UpdateRoomList();
                    _viewModel.ManageRoomName = "";
                }
            }

            
        }
        
       
    }
}
