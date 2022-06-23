using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TpSofttek.Models
{
    public class ModelClient
    {
        public int Id { get; set; }
        [Required(ErrorMessage="el nombre es obligatorio")]
        public String nombre { get; set; }
        [Required(ErrorMessage = "la dirección  es obligatoria")]

        public String direccion { get; set; }
        [Required(ErrorMessage = "la poblacion es  obligatoria")]

        public String poblacion { get; set; }
        [Required(ErrorMessage = "el telefono es obligatorio")]

        public String telefono { get; set; }


    }
}
