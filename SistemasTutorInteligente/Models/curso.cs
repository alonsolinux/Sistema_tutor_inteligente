using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasTutorInteligente.Models
{
    public class curso
    {
        [Key]
        public int IDcurso { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(95, MinimumLength = 5, ErrorMessage = "El nombre del curso debe tener de 5 a 95 caracteres")]
        public String nombre_curso { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "El nivel del curso debe tener de 5 a 45 caracteres")]
        public String nivel { get; set; }

        public ICollection<tema_curso> tema_curso { get; set; }
    }
}
