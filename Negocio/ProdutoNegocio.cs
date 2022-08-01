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
    public class ProdutoNegocio : NegocioGenerico<Produto>, IProdutoNegocio
    {
        public List<Produto> Listar()
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var produtos = context.Produtos.ToList();
                    return produtos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto BuscaPorId(decimal id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var produto = context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
                    return produto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto Adicionar(Produto produto)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Produtos.Add(produto);
                    context.SaveChanges();
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto Editar(Produto produto)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto Remover(Produto produto)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Produtos.Remove(produto);
                    context.SaveChanges();
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
