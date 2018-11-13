using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemasTutorInteligente.Models
{
    public class DatosCuenta
    {
        [Key]
        public int IDusuario { get; set; }
        public String Usuario { get; set; }
        public String Password { get; set; }
        public ICollection<DatosPersonales> datosPersonales { get; set; }
    }
}
