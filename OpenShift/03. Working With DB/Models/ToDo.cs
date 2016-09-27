using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloReact.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(512)]
        public string Description { get; set; }

        public bool Complete { get; set; }
    }
}