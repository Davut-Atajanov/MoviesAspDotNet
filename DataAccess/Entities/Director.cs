using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Director : Record
    {
        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        [StringLength(50)]
        public String Surname { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsRetired { get; set; }

        public List<Movie> Movies { get; set; }

        override public int Id { get; set; }

        override public string? Guid { get; set; }
    }
}
