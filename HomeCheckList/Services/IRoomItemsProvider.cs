using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Services
{
    public interface IRoomItemsProvider
    {
        Task<IEnumerable<RoomItems>> GetAllRoomItems();
        Task<IEnumerable<RoomItems>> GetItemsByRoom(int roomId);
        
        Task<RoomItems> GetRoomItemById(int roomId);
    }
}
