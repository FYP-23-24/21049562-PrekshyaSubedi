using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitraNepAdven.Models
{
    public class Package
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        public string Description { get; set; }

        public int NumberOfPeople { get; set; }

        public string ImageUrl { get; set; }

        public string MapImageUrl { get; set; }
    }
}



