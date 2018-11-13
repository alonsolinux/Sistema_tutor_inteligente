using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemasTutorInteligente.Models
{
    public class DatosPersonales
    {
        [Key]
        public int IDdatos { get; set; }
        public String Nombre { get; set; }
        public String Apaterno { get; set; }
        public String Amaterno { get; set; }
        public int Edad { get; set; }
        public int IDusuario { get; set; }
        public DatosCuenta datosCuenta { get; set; }
    }
}
