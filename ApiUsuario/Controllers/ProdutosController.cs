using AcessoDados;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegocioInterface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiUsuario.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoNegocio produtoNegocio;

        public ProdutosController(IProdutoNegocio _produtoNegocio)
        {
            produtoNegocio = _produtoNegocio;
        }
        //// GET: api/<ProdutosController>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Listar()
        {
            var produtos = produtoNegocio.Listar();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados!");
            }
            return produtos;
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> BuscaPorId(decimal id)
        {

            var produto = produtoNegocio.BuscaPorId(id);
            if (produto is null)
            {
                return NotFound("Produto não encontrados!");
            }
            return produto;
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public ActionResult Adicionar(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }

            produto = produtoNegocio.Adicionar(produto);

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public ActionResult Editar(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            produto = produtoNegocio.Editar(produto);

            return Ok(produto);
        }

        //// DELETE api/<ProdutosController>/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = produtoNegocio.BuscaPorId(id);
            if (produto is null)
            {
                return NotFound("Produto não encontrados!");
            }
            produto = produtoNegocio.Remover(produto);

            return Ok(produto);
        }
    }
}
