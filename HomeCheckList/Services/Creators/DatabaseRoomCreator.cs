using HomeCheckList.DbContexts;
using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Services.Creators
{
    public class DatabaseRoomCreator : IRoomCreator
    {
        private readonly HomeCheckListDbContextFactory _contextFactory;

        public DatabaseRoomCreator(HomeCheckListDbContextFactory dbContext)
        {
            _contextFactory = dbContext;
        }

        public async Task CreateRoom(Room room)
        {
            using CheckListContext context = _contextFactory.CreateDbContext();
            
            Room _room = new Room()
            {
                Name = room.Name,
            };

            context.Rooms.Add(_room);
            await context.SaveChangesAsync();
        }

        //public async Task CreateRoomItem(RoomItems roomItem)
        //{
        //    using CheckListContext context = _contextFactory.CreateDbContext();

        //    RoomItems _roomItem = new RoomItems()
        //    {
        //        ItemName = roomItem.ItemName,
        //        Note = roomItem.Note,
        //        RoomId = roomItem.RoomId,
        //    };
        //}
    }
}
