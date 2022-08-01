Foi craido o projeto

Para criar, fui ao visual studio e lá criei um novo projeto dotnet. core 3.1
sem criar com a pasta na mesma pasta da solução.
Dentro do projeto criei as pastas de api e class library.

PAssei o projeto para a pasta api e dentro de class library criei acesso a dados, entidade, negocio e negocio interface,
e coloquei a connection string

continuar os estudos depois

coloquei os db context e as entidades em projetos clas library separados.
para o code first funcionar com o dotnet migrations deve-se acrescentar isso ao program.cs ou startup cs nos casos mais antigos


string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseSqlServer(mySqlConnection, b => b.MigrationsAssembly("ApiUsuario")));

se não separar os projetos, ou seja se as entidades e contexto forem criados no projeto da api entçai deve ser assim
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseSqlServer(mySqlConnection));

migrations

instalar o dotnet ef no projeto 
usar a migation depois de criar a entidade com os dados que entrarão na tabela


nova migration
dotnet ef migrations add TabelaInicial
remover migration
dotnet ef migrations remove TabelaInicial
atualizar o banco com novas tabelas ou mudanças
dotnet ef database update


pode-se colocar dados iniciais atraves de migrations tb
cria-se uma nova migration, se nao houverem mudanças em nenhuma entidade só irá criar uma classe com metodos up e down

coloca-se os dados que querem acrescentar
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

da um update
