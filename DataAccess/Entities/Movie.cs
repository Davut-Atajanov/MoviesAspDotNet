using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class Movie : Record
    {
        [Required]
        [StringLength(150)]
        public String Name { get; set; }

        public short? Year { get; set; }

        public double Revenue { get; set; }
        
        public int? DirectorId { get; set; }

        public Director Director { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }

        override public int Id { get; set; }

        override public string? Guid { get; set; }
    }
}
