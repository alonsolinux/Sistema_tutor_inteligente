using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasTutorInteligente.Models
{
    public class tema_curso
    {
        [Key]
        public int IDtemas { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(95, MinimumLength = 5, ErrorMessage = "El nombre del tema debe tener de 5 a 95 caracteres")]
        public String nombre_tema { get; set; }
        public int IDcurso { get; set; }
        public curso curso { get; set; }
        
    }
}
