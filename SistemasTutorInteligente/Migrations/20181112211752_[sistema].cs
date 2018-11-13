using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemasTutorInteligente.Migrations
{
    public partial class sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    IDcurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_curso = table.Column<string>(maxLength: 95, nullable: false),
                    nivel = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.IDcurso);
                });

            migrationBuilder.CreateTable(
                name: "DatosCuenta",
                columns: table => new
                {
                    IDusuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Usuario = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosCuenta", x => x.IDusuario);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    IDejercicio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreEjercicio = table.Column<string>(maxLength: 45, nullable: false),
                    Puntaje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.IDejercicio);
                });

            migrationBuilder.CreateTable(
                name: "preguntas_test_inteligencia",
                columns: table => new
                {
                    IDpreguntas_test = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    num_pregunta = table.Column<int>(nullable: false),
                    pregunta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preguntas_test_inteligencia", x => x.IDpreguntas_test);
                });

            migrationBuilder.CreateTable(
                name: "tema_curso",
                columns: table => new
                {
                    IDtemas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_tema = table.Column<string>(maxLength: 95, nullable: false),
                    IDcurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tema_curso", x => x.IDtemas);
                    table.ForeignKey(
                        name: "FK_tema_curso_curso_IDcurso",
                        column: x => x.IDcurso,
                        principalTable: "curso",
                        principalColumn: "IDcurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatosPersonales",
                columns: table => new
                {
                    IDdatos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apaterno = table.Column<string>(nullable: true),
                    Amaterno = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    IDusuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosPersonales", x => x.IDdatos);
                    table.ForeignKey(
                        name: "FK_DatosPersonales_DatosCuenta_IDusuario",
                        column: x => x.IDusuario,
                        principalTable: "DatosCuenta",
                        principalColumn: "IDusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosPersonales_IDusuario",
                table: "DatosPersonales",
                column: "IDusuario");

            migrationBuilder.CreateIndex(
                name: "IX_tema_curso_IDcurso",
                table: "tema_curso",
                column: "IDcurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosPersonales");

            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "preguntas_test_inteligencia");

            migrationBuilder.DropTable(
                name: "tema_curso");

            migrationBuilder.DropTable(
                name: "DatosCuenta");

            migrationBuilder.DropTable(
                name: "curso");
        }
    }
}
