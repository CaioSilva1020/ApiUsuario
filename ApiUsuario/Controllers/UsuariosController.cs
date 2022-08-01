using AcessoDados;
using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegocioInterface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiUsuario.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioNegocio usuarioNegocio;

        public UsuariosController(IUsuarioNegocio _usuarioNegocio)
        {
            usuarioNegocio = _usuarioNegocio;
        }
        //// GET: api/<UsuariosController>
        [HttpGet]
        //[Authorize]
        public ActionResult<IEnumerable<Usuario>> Listar()
        {
            var usuarios = usuarioNegocio.Listar();
            if (usuarios is null)
            {
                return NotFound("Usuarios não encontrados!");
            }
            return usuarios;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id:int}", Name = "ObterUsuario")]
        public ActionResult<Usuario> BuscaPorId(decimal id)
        {

            var usuario = usuarioNegocio.BuscaPorId(id);
            if (usuario is null)
            {
                return NotFound("Usuario não encontrados!");
            }
            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public ActionResult Adicionar(Usuario usuario)
        {
            if (usuario is null)
            {
                return BadRequest();
            }

            usuario = usuarioNegocio.Adicionar(usuario);

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = usuario.UsuarioId }, usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public ActionResult Editar(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            usuario = usuarioNegocio.Editar(usuario);

            return Ok(usuario);
        }

        //// DELETE api/<UsuariosController>/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var usuario = usuarioNegocio.BuscaPorId(id);
            if (usuario is null)
            {
                return NotFound("Usuario não encontrados!");
            }
            usuario = usuarioNegocio.Remover(usuario);

            return Ok(usuario);
        }
    }
}
