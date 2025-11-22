using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.DTOs
{
    public class ToDodto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTimeOffset CreatedAt { get; set; } 
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
