using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeCheckList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands.Tests
{
    [TestClass()]
    public class LoadRoomsCommandTests
    {
        private const string CONNECTION_STRING = "Data Source=checklist.db";
        
        [TestMethod()]
        public void ExecuteAsyncTest()
        {
            
            DbContexts.HomeCheckListDbContextFactory _homeCheckListDbContextFactory = new DbContexts.HomeCheckListDbContextFactory(CONNECTION_STRING);
            ViewModels.MainWindowViewModel viewModel = new ViewModels.MainWindowViewModel();
            Services.Creators.IRoomCreator roomCreator = new Services.Creators.DatabaseRoomCreator(_homeCheckListDbContextFactory);

            Services.IRoomItemsProvider itemProvider = new Services.DatabaseRoomItemsProvider(_homeCheckListDbContextFactory);
            Services.Creators.IRoomItemCreator roomItemCreator = new Services.Creators.DatabaseItemCreator(_homeCheckListDbContextFactory);
            
            Services.IRoomsProvider roomsProvider = new Services.DatabaseRoomProviders(_homeCheckListDbContextFactory);
            Models.DbHelper dbHelper = new Models.DbHelper(roomsProvider, roomCreator, itemProvider, roomItemCreator);
            LoadRoomsCommand test = new LoadRoomsCommand(viewModel, dbHelper);
            test.Execute(null);
            Assert.Fail();
        }
    }
}