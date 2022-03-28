using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.ViewModels
{
    public class ItemViewModel
    {
        private readonly RoomItems _roomItems;
        
        public string roomId => _roomItems.Id.ToString();
        public string Name => _roomItems.ItemName;
        public string Note => _roomItems.Note;
        public bool IsDone => _roomItems.IsCompleted;
       // public string DueDate => _roomItems.DueDate.Value.ToShortDateString();
        public string? DueDate => _roomItems.DueDate?.ToShortDateString();
        
        public string LastEdited => _roomItems.CreatedAt.ToShortDateString();
        public ItemViewModel(RoomItems roomItems)
        {
            _roomItems = roomItems;
        }

        
    }
}
