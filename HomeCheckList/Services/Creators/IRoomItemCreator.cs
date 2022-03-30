using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Services.Creators
{
    public interface IRoomItemCreator
    {
        Task CreateRoomItem(RoomItems roomItem);
        Task UpdateRoomItem(RoomItems roomItem);
        Task DeleteRoomItem(RoomItems roomItem);
    }
}
