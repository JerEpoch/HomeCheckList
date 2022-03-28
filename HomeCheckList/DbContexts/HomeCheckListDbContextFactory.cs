using HomeCheckList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.DbContexts
{
    public class HomeCheckListDbContextFactory
    {
        private readonly string _connectionString;

        public HomeCheckListDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CheckListContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new CheckListContext(options);
        }
    }
}
