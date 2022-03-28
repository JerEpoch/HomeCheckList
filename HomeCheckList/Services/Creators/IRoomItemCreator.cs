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
    }
}
