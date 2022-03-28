using HomeCheckList.Models;
using HomeCheckList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands
{
    public class LoadRoomsCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly DbHelper _dbHelper;

        public LoadRoomsCommand(MainWindowViewModel viewModel, DbHelper dbhelper)
        {
            _viewModel = viewModel;
            _dbHelper = dbhelper;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Room> rooms = await _dbHelper.GetAll();
                _viewModel.LoadAllRooms(rooms);
            }
            catch (Exception)
            {
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Error", "There was a problem getting rooms.");

                messageBoxStandard.Show();
            }
        }
    }
}
