using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInterface
{
    public interface ICategoriaNegocio : INegocioGenerico<Categoria>
    {
        List<Categoria> Listar();
        Categoria BuscaPorId(decimal id);
        Categoria Adicionar(Categoria categoria);
        Categoria Editar(Categoria categoria);
        Categoria Remover(Categoria categoria);
    }
}
