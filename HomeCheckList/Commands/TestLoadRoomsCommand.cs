using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Commands
{
    public class TestLoadRoomsCommand : AsyncCommandBase
    {
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        public override async Task ExecuteAsync(object paremter)
        {
            
            
            
        }


    }
}
