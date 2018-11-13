using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemasTutorInteligente.Models
{
    public class Ejercicio
    {
        [Key]
        public int IDejercicio { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "El nombre del curso debe tener de 5 a 95 caracteres")]
        public String NombreEjercicio { get; set; }
        public int Puntaje { get; set; }
    }
}
