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
    public class AddRoomItemCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly DbHelper _dbHelper;
        private readonly AddItemViewModel _addItemViewModel;
        
        public AddRoomItemCommand(MainWindowViewModel mainWindowView, DbHelper dbHelper, AddItemViewModel addItemViewModel)
        {
            _mainWindowViewModel = mainWindowView;
            _dbHelper = dbHelper;
            _addItemViewModel = addItemViewModel;
            
            _addItemViewModel.PropertyChanged += addItemViewModel_PropertyChanged;
        }

        private void addItemViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AddItemViewModel.InputName))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addItemViewModel.InputName) &&_mainWindowViewModel.SelectedRoom != null  && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object paremter)
        {
            RoomItems roomItem = new();

            if (_mainWindowViewModel.SelectedRoom == null)
            {
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Warning", "Please selected a room to add the item to.");
                await messageBoxStandard.Show();
            }
            else
            {
                if (_addItemViewModel.IncludeReminder)
                {
                    roomItem.ItemName = _addItemViewModel.InputName;
                    roomItem.Note = _addItemViewModel.InputNote;
                    roomItem.DueDate = _addItemViewModel.DueDates;
                    roomItem.RoomId = _mainWindowViewModel.SelectedRoom.Id;

                }
                else
                {
                    roomItem.ItemName = _addItemViewModel.InputName;
                    roomItem.Note = _addItemViewModel.InputNote;
                    
                    roomItem.RoomId = _mainWindowViewModel.SelectedRoom.Id;
                }
            }
       
             

            try
            {
                await _dbHelper.AddRoomItem(roomItem);
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Sucess", "Your item was created.");
                await messageBoxStandard.Show();

                _addItemViewModel.InputName = "";
                _addItemViewModel.InputNote = "";
                _addItemViewModel.IncludeReminder = false;

            }
            catch (Exception )
            {
                var messageBoxStandard = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Error", "Your item was unable to be created. Please try again.");
                await messageBoxStandard.Show();
            }
        }
    }
}
