using HomeCheckList.Services;
using HomeCheckList.Services.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Models
{
    public class DbHelper
    {
        private readonly IRoomsProvider _roomsProvider;
        private readonly IRoomItemsProvider _roomItemsProvider;
        private readonly IRoomCreator _roomCreator;
        private readonly IRoomItemCreator _itemCreator;

        public DbHelper(IRoomsProvider roomsProvider, IRoomCreator roomCreator, IRoomItemsProvider roomItemsProvider, IRoomItemCreator roomItemCreator)
        {
            _roomCreator = roomCreator;
            _roomsProvider = roomsProvider;
            _roomItemsProvider = roomItemsProvider;
            _itemCreator = roomItemCreator;
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _roomsProvider.GetAllRooms();
        }

        public async Task AddRoom(Room room)
        {
            await _roomCreator.CreateRoom(room);
        }

        public async Task AddRoomItem(RoomItems roomItems)
        {
             await _itemCreator.CreateRoomItem(roomItems);
        }

        public async Task<IEnumerable<RoomItems>> GetAllRooms()
        {
            return await _roomItemsProvider.GetAllRoomItems();
        }

        public async Task<IEnumerable<RoomItems>> GetRoomItems(int roomId)
        {
            return await _roomItemsProvider.GetItemsByRoom(roomId);
        }

        public async Task UpdateRoomItem(RoomItems item)
        {
           
            await _itemCreator.UpdateRoomItem(item);
            
        }

        public async Task<RoomItems> GetRoomItemById(int roomId)
        {
            return await _roomItemsProvider.GetRoomItemById(roomId);
        }

        public async Task DeleteRoomItem(RoomItems roomItem)
        {
            await _itemCreator.DeleteRoomItem(roomItem);
        }
    }
}
