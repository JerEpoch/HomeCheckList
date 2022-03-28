using HomeCheckList.Models;
using HomeCheckList.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands
{
    public class MakeRoomCommand : AsyncCommandBase
    {
        private readonly AddRoomViewModel _addRoomViewModel;
        //private readonly DbHelper _dbHelper = new DbHelper();
        private readonly DbHelper _dbHelper;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly LoadRoomsCommand _loadRoomsCommand;
        public MakeRoomCommand(MainWindowViewModel mainWindowViewModel,DbHelper dbhelper, AddRoomViewModel addRoomViewModel)
        {
            _addRoomViewModel = addRoomViewModel;
            _dbHelper = dbhelper;
            _mainWindowViewModel = mainWindowViewModel;
            _loadRoomsCommand = new LoadRoomsCommand(_mainWindowViewModel, _dbHelper);
            _addRoomViewModel.PropertyChanged += _addRoomViewModel_PropertyChanged;
            
        }

        

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addRoomViewModel.InputRoomName) && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            Room room = new(
                _addRoomViewModel.InputRoomName
                ); 
            try
            {
                await _dbHelper.AddRoom(room);
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Sucess", "New room created.");

                await messageBoxStandard.Show();
                _loadRoomsCommand.Execute(null);
                //rooms = await _dbHelper.GetAll();
                //_mainWindowViewModel.LoadRoomItems(rooms);
            }
            catch (Exception )
            {
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Error", "There was a problem getting rooms.");

                await messageBoxStandard.Show();
            }
        }

        private void _addRoomViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AddRoomViewModel.InputRoomName))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
