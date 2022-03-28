using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCheckList.DTOs
{
    public class CheckListDTO
    {
        [Key]
        public Guid Id { get; set; }
         
    }
}
