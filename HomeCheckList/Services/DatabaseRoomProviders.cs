using HomeCheckList.DbContexts;
using HomeCheckList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Services
{
    public class DatabaseRoomProviders : IRoomsProvider
    {
        private readonly HomeCheckListDbContextFactory _contextFactory;

        public DatabaseRoomProviders(HomeCheckListDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            using (CheckListContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Room> rooms = await context.Rooms.ToListAsync();

                return rooms;
            }
        }

        public async Task<Room> GetRoomById(int id)
        {
            using (CheckListContext context = _contextFactory.CreateDbContext())
            {
                Room room = await context.Rooms.SingleOrDefaultAsync(r => r.Id == id);

                return room;
            }
        }
    }
}
