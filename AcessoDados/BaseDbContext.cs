using Entidades;
using Microsoft.EntityFrameworkCore;

namespace AcessoDados
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }

        public MyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KDJJEAI\\SQLEXPRESS;Initial Catalog=ApiCatalogDb;Integrated Security=true", b => b.MigrationsAssembly("ApiUsuario"));
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}