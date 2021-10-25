using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Web.DTO
{
    public class LivroDTO
    {
        public Guid UID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Codigo { get; set; }

    }
}
