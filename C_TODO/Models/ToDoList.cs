using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace C_TODO.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
