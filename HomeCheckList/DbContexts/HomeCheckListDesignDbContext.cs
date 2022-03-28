using HomeCheckList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.DbContexts
{
    public class HomeCheckListDesignDbContext : IDesignTimeDbContextFactory<CheckListContext>
    {
        public CheckListContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=checklist.db").Options;

            return new CheckListContext(options);
        }
    }
}
