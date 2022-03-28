using HomeCheckList.Models;
using HomeCheckList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands
{
    public class LoadRoomItemsCommand : AsyncCommandBase
    {
        private RoomItemsViewModel _roomItemsViewModel;
        private DbHelper _dbhelper;
        private int _id;
        public LoadRoomItemsCommand(RoomItemsViewModel roomItemsViewModel, DbHelper dbHelper, int roomId)
        {
            _roomItemsViewModel = roomItemsViewModel;
            _dbhelper = dbHelper;
            _id = roomId;
        }
        public override async Task ExecuteAsync(object paremter)
        {
            try
            {
                //IEnumerable<RoomItems> roomItems = await _dbhelper.GetAllRooms();
                IEnumerable<RoomItems> roomItems = await _dbhelper.GetRoomItems(_id);
                _roomItemsViewModel.LoadRoomAllItems(roomItems);
            }
            catch (Exception)
            {

            }
        }
    }
}
