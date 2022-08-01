using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInterface
{
    public interface IProdutoNegocio : INegocioGenerico<Produto>
    {
        List<Produto> Listar();
        Produto BuscaPorId(decimal id);
        Produto Adicionar(Produto produto);
        Produto Editar(Produto produto);
        Produto Remover(Produto produto);
    }
}
