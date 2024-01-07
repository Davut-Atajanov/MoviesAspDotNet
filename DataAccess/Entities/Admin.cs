using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public String Email { get; set; }

        [Required]
        [StringLength(20)]
        public String Password { get; set; }
    }
}
