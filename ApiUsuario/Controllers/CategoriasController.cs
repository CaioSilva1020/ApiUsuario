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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaNegocio categoriaNegocio;

        public CategoriasController(ICategoriaNegocio _categoriaNegocio)
        {
            categoriaNegocio = _categoriaNegocio;
        }
        //// GET: api/<CategoriasController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Listar()
        {
            var categorias = categoriaNegocio.Listar();
            if (categorias is null)
            {
                return NotFound("Categorias não encontrados!");
            }
            return categorias;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> BuscaPorId(decimal id)
        {

            var categoria = categoriaNegocio.BuscaPorId(id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrados!");
            }
            return categoria;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public ActionResult Adicionar(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            categoria = categoriaNegocio.Adicionar(categoria);

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public ActionResult Editar(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            categoria = categoriaNegocio.Editar(categoria);

            return Ok(categoria);
        }

        //// DELETE api/<CategoriasController>/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = categoriaNegocio.BuscaPorId(id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrados!");
            }
            categoria = categoriaNegocio.Remover(categoria);

            return Ok(categoria);
        }
    }
}
