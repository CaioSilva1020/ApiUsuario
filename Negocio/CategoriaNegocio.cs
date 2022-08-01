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
    public class CategoriaNegocio : NegocioGenerico<Categoria>, ICategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var categorias = context.Categorias.ToList();
                    return categorias;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria BuscaPorId(decimal id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var categoria = context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
                    return categoria;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria Adicionar(Categoria categoria)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Categorias.Add(categoria);
                    context.SaveChanges();
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria Editar(Categoria categoria)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(categoria).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria Remover(Categoria categoria)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Categorias.Remove(categoria);
                    context.SaveChanges();
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
