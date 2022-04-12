using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.Models
{
    public class RoomItems
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string? Note { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoomId { get; set; }

        public RoomItems() { }

        //public RoomItems(string name, string note, int rId, bool isComplete, DateTime? dueDate)
        //{
        //    // ItemId = new Guid();
        //    ItemName = name;
        //    Note = note;
        //    RoomId = rId;
        //    IsCompleted = isComplete;
        //    DueDate = dueDate;
        //}

        public RoomItems(string name, string note, DateTime? dueDate, int rId)
        {
            ItemName = name;
            Note = note;
            DueDate = dueDate;
            CreatedAt = DateTime.Now;
            RoomId = rId;
        }

        public string FormattedDate()
        {
            if (DueDate.HasValue)
            {
                return DueDate.Value.ToShortDateString();
            }

            return null;
        }
    }
}
