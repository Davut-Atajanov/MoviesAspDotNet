using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public abstract class Record
    {
        [Required]
        public abstract int Id { get; set; }
        public abstract string? Guid { get; set; }
    }
}
