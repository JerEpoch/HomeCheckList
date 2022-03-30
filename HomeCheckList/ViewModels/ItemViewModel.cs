using HomeCheckList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly RoomItems _roomItems;
        
        public string roomId => _roomItems.Id.ToString();
        public int itemId => _roomItems.Id;
        //public string Name => _roomItems.ItemName;
        public string Name
        {
            get => _roomItems.ItemName;
            set
            {
                _roomItems.ItemName = value;
                OnPropertyChanged(nameof(Name));
            }
        }
       // public string Note => _roomItems.Note;
        public string Note
        {
            get => _roomItems.Note;
            set
            {
                _roomItems.Note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
        //public bool IsDone => _roomItems.IsCompleted;
        public bool IsDone
        {
            get => _roomItems.IsCompleted;
            set
            {
                _roomItems.IsCompleted = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }
       
       // public string? DueDate => _roomItems.DueDate?.ToShortDateString();
        public DateTime? DueDate
        {
            get => _roomItems.DueDate;
            set
            {

                _roomItems.DueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        public string LastEdited => _roomItems.CreatedAt.ToShortDateString();
        public ItemViewModel(RoomItems roomItems)
        {
            _roomItems = roomItems;
        }

        
    }
}
