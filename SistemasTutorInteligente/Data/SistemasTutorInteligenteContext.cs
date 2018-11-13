using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemasTutorInteligente.Models;

namespace SistemasTutorInteligente.Models
{
    public class SistemasTutorInteligenteContext : DbContext
    {
        public SistemasTutorInteligenteContext (DbContextOptions<SistemasTutorInteligenteContext> options)
            : base(options)
        {
        }

        public DbSet<SistemasTutorInteligente.Models.curso> curso { get; set; }

        public DbSet<SistemasTutorInteligente.Models.tema_curso> tema_curso { get; set; }

        public DbSet<SistemasTutorInteligente.Models.DatosCuenta> DatosCuenta { get; set; }

        public DbSet<SistemasTutorInteligente.Models.DatosPersonales> DatosPersonales { get; set; }

        public DbSet<SistemasTutorInteligente.Models.Ejercicio> Ejercicio { get; set; }

        public DbSet<SistemasTutorInteligente.Models.preguntas_test_inteligencia> preguntas_test_inteligencia { get; set; }
    }
}
