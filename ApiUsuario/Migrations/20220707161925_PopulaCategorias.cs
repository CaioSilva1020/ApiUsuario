using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiUsuario.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Lanches', 'lanches.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Sobremesas', 'sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
