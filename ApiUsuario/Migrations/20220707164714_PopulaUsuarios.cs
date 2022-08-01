using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiUsuario.Migrations
{
    public partial class PopulaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Usuarios(Nome, Cpf, Rg, DataNascimento)" +
                "values ('Caio', '31047536870', '347110472', GETDATE())");
            migrationBuilder.Sql("Insert into Usuarios(Nome, Cpf, Rg, DataNascimento)" +
                "values ('Caio2', '31047536870', '347110472', GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Usuarios");
        }
    }
}
