using AcessoDados;
using Entidades;
using Microsoft.EntityFrameworkCore;
using NegocioInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio : NegocioGenerico<Usuario>, IUsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var usuarios = context.Usuarios.ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscaPorId(decimal id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var usuario = context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Adicionar(Usuario usuario)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Editar(Usuario usuario)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Remover(Usuario usuario)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Usuarios.Remove(usuario);
                    context.SaveChanges();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
