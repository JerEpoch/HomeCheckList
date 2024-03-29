﻿using HomeCheckList.DbContexts;
using HomeCheckList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Services
{
    public class DatabaseRoomItemsProvider : IRoomItemsProvider
    {
        private readonly HomeCheckListDbContextFactory _contextFactory;

        public DatabaseRoomItemsProvider(HomeCheckListDbContextFactory homeCheckListDbContextFactory)
        {
            _contextFactory = homeCheckListDbContextFactory;
        }

        public async Task<IEnumerable<RoomItems>> GetAllRoomItems()
        {
            
            using (CheckListContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<RoomItems> roomItems = await context.RoomsItems.ToListAsync();

                return roomItems;
            }
        }

        
        public async Task<IEnumerable<RoomItems>> GetItemsByRoom(int roomId)
        {
            using (CheckListContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<RoomItems> roomItems = await context.RoomsItems.Where(
                    x => x.RoomId == roomId).ToListAsync();

                return roomItems;
            }
        }

        //public async Task UpdateRoomItem(RoomItems item)
        //{
        //    using (CheckListContext context = _contextFactory.CreateDbContext())
        //    {
        //        context.Update(item);
        //        context.SaveChanges();
        //    }
        //}

        public async Task<RoomItems> GetRoomItemById(int itemId)
        {
            using (CheckListContext context = _contextFactory.CreateDbContext())
            {
                RoomItems roomItem = await context.RoomsItems.FirstOrDefaultAsync(item => item.Id == itemId);

                return roomItem;
            }
        }
    }
}
