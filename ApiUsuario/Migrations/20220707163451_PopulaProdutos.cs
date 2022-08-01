using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiUsuario.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)"+
                "values ('Coca-Cola Diet', 'Refrigerante de Coca 250 ml', 4.45, 'cocacola.jpg', 50, GETDATE(), 1)");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "values ('Lanche de atum', 'atum com maionese', 15.45, 'atum.jpg', 50, GETDATE(), 1)");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "values ('Pudim 100 gm', 'pudim de leite', 3.45, 'pudim.jpg', 50, GETDATE(), 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
