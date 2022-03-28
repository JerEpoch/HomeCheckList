using HomeCheckList.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Models
{
    public class CheckListContext : DbContext
    {
        public CheckListContext(DbContextOptions options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=homechecklist.db");
        //}

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomItems> RoomsItems { get; set; }

    }
}
