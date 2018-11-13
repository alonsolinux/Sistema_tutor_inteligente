using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SistemasTutorInteligente.Models
{
    public class preguntas_test_inteligencia
    {
        [Key]
        public int IDpreguntas_test { get; set; }
        public int num_pregunta { get; set; }
        public String pregunta { get; set; }
    }
}
