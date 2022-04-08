using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeCheckList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeCheckList.Models;

namespace HomeCheckList.Services.Tests
{
    [TestClass()]
    public class TestGetAllRoomsTests
    {
        class MockTestRep : IRoomsProvider
        {
            public async Task<IEnumerable<Room>> GetAllRooms()
            {
                IEnumerable<Room> rooms = new List<Room>();

                rooms.Append(new Room("Basement"));
                rooms.Append(new Room("Basement 2"));
                return rooms;
            }

            public async Task<Room> GetRoomById(int id)
            {
                Room room = new Room("Basement");
                return room;
            }
        }
        [TestMethod()]
        public void GetAllRoomsTest()
        {
            var testLoad = new MockTestRep();
            //var testLoadAll = new TestGetAllRooms();
            var result = testLoad.GetAllRooms();
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRoomByIdTest()
        {
            Assert.Fail();
        }
    }
}