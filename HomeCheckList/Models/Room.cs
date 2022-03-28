using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Models
{
    public class Room
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        

        public Room(string roomName)
        {
            
            Name = roomName;

        }

        public Room() { }
    }
}
