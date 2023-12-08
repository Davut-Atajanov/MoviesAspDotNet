using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Business.Models
{
    public class DirectorModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Retired")]
        public bool IsRetired { get; set; }

        [DisplayName("Retired")]
        public string IsRetiredToString { get; set; }

        [DisplayName("Retired")]
        public string BirthDateToString { get; set; }

        [DisplayName("Name")]
        public string NameToString { get; set; }
    }
}
