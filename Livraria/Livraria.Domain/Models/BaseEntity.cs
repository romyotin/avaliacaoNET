using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid UID { get; set; }
    }
}
