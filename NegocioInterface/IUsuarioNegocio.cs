using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInterface
{
    public interface IUsuarioNegocio : INegocioGenerico<Usuario>
    {
        List<Usuario> Listar();
        Usuario BuscaPorId(decimal id);
        Usuario Adicionar(Usuario usuario);
        Usuario Editar(Usuario usuario);
        Usuario Remover(Usuario usuario);
    }
}
