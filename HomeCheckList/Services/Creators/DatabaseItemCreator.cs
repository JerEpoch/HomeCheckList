using HomeCheckList.DbContexts;
using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Services.Creators
{
    public class DatabaseItemCreator : IRoomItemCreator
    {
        private readonly HomeCheckListDbContextFactory _contextFactory;

        public DatabaseItemCreator(HomeCheckListDbContextFactory dbContext)
        {
            _contextFactory = dbContext;
        }
        public async Task CreateRoomItem(RoomItems roomItem)
        {
            using CheckListContext context = _contextFactory.CreateDbContext();

            RoomItems _roomItem = new()
            {
                ItemName = roomItem.ItemName,
                Note = roomItem.Note,
                RoomId = roomItem.RoomId,
                CreatedAt = DateTime.Now,
                DueDate = roomItem.DueDate
            };

            context.RoomsItems.Add(_roomItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateRoomItem(RoomItems roomItem)
        {
            using CheckListContext context = _contextFactory.CreateDbContext();

            context.Update(roomItem);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRoomItem(RoomItems roomItem)
        {
            using CheckListContext context = _contextFactory.CreateDbContext();
            context.Remove(roomItem);
            context.SaveChanges();
        }
    }
}
