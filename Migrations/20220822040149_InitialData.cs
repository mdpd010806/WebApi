using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    tareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    prioridadTarea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.tareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "categoriaId", "descripcion", "nombre", "peso" },
                values: new object[,]
                {
                    { new Guid("e1537fd4-6677-484b-b4f9-dcaf735a2e30"), "Cocinar", "Actividades personales", 50 },
                    { new Guid("f9f478c4-e823-4766-ac30-6570108c2f61"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "tareaId", "categoriaId", "descripcion", "fechaCreacion", "fechaFinal", "prioridadTarea", "titulo" },
                values: new object[,]
                {
                    { new Guid("17d71731-4dbc-4cad-9488-d03cb5e9f9e1"), new Guid("f9f478c4-e823-4766-ac30-6570108c2f61"), "Curso de angular", new DateTime(2022, 8, 21, 23, 1, 49, 608, DateTimeKind.Local).AddTicks(1968), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alta", "Ver cursos de Angular" },
                    { new Guid("1fd0ad0c-f877-43a0-ae29-c88db61ba0e4"), new Guid("e1537fd4-6677-484b-b4f9-dcaf735a2e30"), "Papas fritas, lechuga y crema de mani", new DateTime(2022, 8, 21, 23, 1, 49, 608, DateTimeKind.Local).AddTicks(1970), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media", "Hacer compras semanales" },
                    { new Guid("e66a8239-b479-4028-857a-b6949571c0fa"), new Guid("f9f478c4-e823-4766-ac30-6570108c2f61"), "Curso de API's", new DateTime(2022, 8, 21, 23, 1, 49, 608, DateTimeKind.Local).AddTicks(1955), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alta", "Ver cursos de .NET" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_categoriaId",
                table: "Tarea",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
